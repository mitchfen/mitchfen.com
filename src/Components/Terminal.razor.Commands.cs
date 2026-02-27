namespace MitchfenSite.Components;

public partial class Terminal
{
    private void ProcessCommand(string cmd)
    {
        switch (cmd)
        {
            case "help":
                OutputLines.Add("  <span class='cyan'>about</span> - get info about me");
                OutputLines.Add("  <span class='cyan'>projects</span> - see what I'm working on");
                OutputLines.Add("  <span class='cyan'>socials</span> - find me elsewhere online");
                OutputLines.Add("  <span class='cyan'>clear</span> - clear the screen");
                break;
            
            case "about":
                OutputLines.Add("I'm <span class='green'>Mitchell Fenner</span>, a Senior Cloud Operations Engineer and homelab enthusiast.");
                break;

            case "welcome":
                OutputLines.Add("<span class='green'>Welcome to Mitchell Fenner's personal website 🤗</span>");
                OutputLines.Add("<span class='comment'>Hint: type help to view commands</span>");
                break;



            case "projects":
                foreach (var project in Projects)
                {
                    if (project.IsRedacted)
                    {
                        OutputLines.Add($"• <span class='comment'>[REDACTED]</span> - {project.Description}");
                    }
                    else if (!string.IsNullOrEmpty(project.Link))
                    {
                        OutputLines.Add($"• <a href='{project.Link}' target='_blank'>{project.Name}</a> - {project.Description}");
                    }
                    else
                    {
                        OutputLines.Add($"• <span class='green'>{project.Name}</span> - {project.Description}");
                    }
                }
                break;
            
            case "socials":
                OutputLines.Add("• <a href='https://github.com/mitchfen' target='_blank'>GitHub</a>");
                OutputLines.Add("• <a href='https://linkedin.com/in/mitchfen' target='_blank'>LinkedIn</a>");
                OutputLines.Add("• <a href='mailto:mitch@mitchfen.com' target='_blank'>Send me an email</a>");
                break;

            case "clear":
                OutputLines.Clear();
                OutputLines.Add(Header);
                OutputLines.Add(""); 
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
}
