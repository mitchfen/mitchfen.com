using MitchfenSite.Models;

namespace MitchfenSite.Components;

public partial class Terminal
{
    private const string Header = "<span class='comment'>welcome [guest] to [mitchfen.com]</span>";

    private List<Project> Projects = new()
    {
       new Project { 
            Name = "HomeLab", 
            Description = "Upcoming project", 
            IsRedacted = true 
        },
       new Project { 
            Name = "Nanoleaf aurora controller", 
            Description = "Webapp running in my homelab to control my lights.", 
            Link = "https://github.com/mitchfen/nanoleaf-controller" 
        },
       new Project { 
            Name = "Old School Runescape herb run helper", 
            Description = "Find the most profitable herb.", 
            Link = "https://github.com/mitchfen/osrs-herb-run-helper" 
        },
       new Project { 
            Name = "mitchfen.com", 
            Description = "This Blazor-powered website.", 
            Link = "https://github.com/mitchfen/mitchfen.com" 
        },
       new Project { 
            Name = "Daily todo tracker", 
            Description = "Webapp running on my homelab to track daily tasks.", 
            Link = "https://github.com/mitchfen/DailyTodo" 
        }
   };
}
