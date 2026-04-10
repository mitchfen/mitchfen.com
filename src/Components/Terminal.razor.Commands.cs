using MitchfenSite.Models;

namespace MitchfenSite.Components;

public partial class Terminal
{
    private void ProcessCommand(string cmd)
    {
        switch (cmd)
        {
            case "help":
                OutputLines.Add("  <span class='cyan'>about</span> - get info about me");
                OutputLines.Add("  <span class='cyan'>projects</span> - hobby projects I've done");
                OutputLines.Add("  <span class='cyan'>socials</span> - find me elsewhere online");
                break;
            
            case "about":
                OutputLines.Add("I'm a Senior Cloud Operations engineer and homelab enthusiast.");
                OutputLines.Add("Web development isn't my specialty, I just put this together for fun.");
                OutputLines.Add("Typically I'm focused on infra, kubernetes, networking, etc.");
                break;

            case "welcome":
                OutputLines.Add("<span class='cyan'>Welcome to Mitchell Fenner's personal website 🤗</span>");
                OutputLines.Add("<span class='comment'>Hint: type help to view commands</span>");
                break;

            case "projects":
                DisplayProjects(Projects);
                break;
            
            case "socials":
                OutputLines.Add("• <a href='https://github.com/mitchfen' target='_blank'>GitHub</a>");
                OutputLines.Add("• <a href='https://linkedin.com/in/mitchfen' target='_blank'>LinkedIn</a>");
                OutputLines.Add("• <a href='mailto:mitch@mitchfen.com' target='_blank'>Send me an email</a>");
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
                break;
        }
    }

    private void DisplayProjects(List<Project> projects, int indent = 0)
    {
        foreach (var project in projects)
        {
            var tags = new List<string>();
            if (project.IsSelfHosted)
                tags.Add("<span class='green'>[self hosted]</span>");
            if (project.IsCli)
                tags.Add("<span class='prompt-char'>[cli]</span>");
            if (project.IsCloudHosted)
                tags.Add("<span class='yellow'>[cloud hosted]</span>");
            
            var tagString = tags.Count > 0 ? string.Join(" ", tags) + " " : "";
            var indentation = new string(' ', indent * 2);
            
            if (project.IsRedacted)
            {
                OutputLines.Add($"{indentation}• {tagString}<span class='comment'>[REDACTED]</span>");
            }
            else if (!string.IsNullOrEmpty(project.Link))
            {
                OutputLines.Add($"{indentation}• {tagString}<a href='{project.Link}' target='_blank'>{project.Name}</a>");
            }
            else
            {
                OutputLines.Add($"{indentation}• {tagString}<span class='green'>{project.Name}</span>");
            }

            if (project.Children.Count > 0)
            {
                DisplayProjects(project.Children, indent + 1);
            }
        }
    }
}
