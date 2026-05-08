namespace MitchfenSite.Components;

public partial class Terminal
{
    private void ProcessCommand(string cmd)
    {
        if (cmd.StartsWith("sudo "))
        {
            OutputLines.Add("<span class='red'>User is not in the sudoers file. This incident will be reported.</span>");
            return;
        }

        switch (cmd)
        {
            case "welcome":
                OutputLines.Add("<span class='green'>Welcome to Mitchell Fenner's personal website 🫡</span>");
                OutputLines.Add("I'm a Senior Cloud Operations engineer and homelab enthusiast.");
                OutputLines.Add("My work centers around Azure, Kubernetes, release management, Microsoft Sentinel, and automation of all kinds.");
                OutputLines.Add("When I'm not working I'm often playing with my own bare metal server and home network. Check it out at <a href='https://github.com/mitchfen/homelab' target='_blank' rel='noopener noreferrer'>github.com/mitchfen/homelab</a>");
                break;
            
            case "links":
                OutputLines.Add("• <a href='https://github.com/mitchfen' target='_blank' rel='noopener noreferrer'>github.com/mitchfen</a>");
                OutputLines.Add("• <a href='https://linkedin.com/in/mitchfen' target='_blank' rel='noopener noreferrer'>linkedin.com/in/mitchfen</a>");
                OutputLines.Add("• <a href='mailto:mitch@mitchfen.com' target='_blank' rel='noopener noreferrer'>mitch@mitchfen.com</a>");
                break;

            case "clear":
                OutputLines.Clear();
                break;
                
            case "sudo":
                OutputLines.Add("<span class='red'>User is not in the sudoers file. This incident will be reported.</span>");
                break;
            
            case "global thermonuclear war":
                OutputLines.Add("<span class='comment'>A STRANGE GAME.</span>");
                OutputLines.Add("<span class='comment'>THE ONLY WINNING MOVE IS NOT TO PLAY.</span>");
                break;

            default:
                var encodedCmd = System.Net.WebUtility.HtmlEncode(cmd);
                OutputLines.Add($"<span class='red'>Command not found: {encodedCmd}</span>");
                OutputLines.Add("");
                OutputLines.Add("<span class='comment'>Available commands:</span>");
                OutputLines.Add("  <span class='cyan'>welcome</span> - about me");
                OutputLines.Add("  <span class='cyan'>links</span> - find me elsewhere online");
                OutputLines.Add("  <span class='cyan'>clear</span> - clear the screen");
                OutputLines.Add("  <span class='cyan'>sudo</span> - run a command as root");
                OutputLines.Add("  <span class='cyan'>global thermonuclear war</span> - shall we play a game?");
                break;
        }
    }

}
