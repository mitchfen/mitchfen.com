using MitchfenSite.Models;

namespace MitchfenSite.Components;

public partial class Terminal
{
    private const string Header = "<span class='comment'>welcome [guest] to [mitchfen.com]</span>";

    private List<Project> Projects = new()
    {
        new Project { 
            Name = "mitchfen.com", 
            Description = "This Blazor-powered terminal", 
            Link = "https://github.com/mitchfen/mitchfen.com" 
        },
        new Project { 
            Name = "nanoleaf-controller", 
            Description = "Webapp running in my homelab to control my lights", 
            Link = "https://github.com/mitchfen/nanoleaf-controller" 
        },
        new Project { 
            Name = "DailyTodo", 
            Description = "Todo webapp that resets every night. Hosted on my homelab", 
            Link = "https://github.com/mitchfen/DailyTodo" 
        },
        new Project { 
            Name = "osrs-herb-run-helper", 
            Description = "Little tool to quickly find the most profitable herb to farm.", 
            Link = "https://github.com/mitchfen/osrs-herb-run-helper" 
        },
        new Project { 
            Name = "HomeLab", 
            Description = "Upcoming project", 
            IsRedacted = true 
        }
    };
}
