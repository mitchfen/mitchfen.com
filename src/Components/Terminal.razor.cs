using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace MitchfenSite.Components;

public partial class Terminal
{
    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

    private string currentInput = "";
    private ElementReference inputElement;
    private List<string> OutputLines = new();
    private bool _shouldScroll = false;

    protected override void OnInitialized()
    {
        OutputLines.Add(Header);
        OutputLines.Add(""); 
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await FocusInput();
            await AutoTypeWelcome();
        }

        if (_shouldScroll)
        {
            _shouldScroll = false;
            await ScrollToBottom();
        }
    }

    private async Task AutoTypeWelcome()
    {
        await Task.Delay(500);
        string cmd = "welcome";
        foreach (var c in cmd)
        {
            currentInput += c;
            StateHasChanged();
            await Task.Delay(100);
        }
        await Task.Delay(300);
        ExecuteCommand();
        StateHasChanged();
    }

    private async Task FocusInput() => await inputElement.FocusAsync();

    private async Task ScrollToBottom() => await JSRuntime.InvokeVoidAsync("scrollToBottom");

    private void HandleKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
        {
            ExecuteCommand();
        }
    }

    private void ExecuteCommand()
    {
        var cmd = currentInput;
        var encodedCmd = System.Net.WebUtility.HtmlEncode(cmd);
        OutputLines.Add($"<div class='executed-cmd'><span class='prompt'>guest <span class='prompt-char'>$</span></span> {encodedCmd}</div>");

        if (!string.IsNullOrWhiteSpace(cmd))
        {
            ProcessCommand(cmd.Trim().ToLower());
        }
        else
        {
             OutputLines.Add("");
        }

        currentInput = "";
        _shouldScroll = true;
    }
}
