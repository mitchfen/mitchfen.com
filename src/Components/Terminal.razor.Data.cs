using MitchfenSite.Models;

namespace MitchfenSite.Components;

public partial class Terminal
{
    private const string Header = "<span class='comment'>welcome to the mitchfen.com's TTY interface</span>";

    private List<Project> Projects = new()
    {
        new Project { 
            Name = "Nanoleaf Aurora Controller", 
            Description = "Let anyone on my network control the lights.", 
            Link = "https://github.com/mitchfen/nanoleaf-controller" 
        },
        new Project { 
            Name = "Momentum", 
            Description = "Help me start my day with momentum.", 
            Link = "https://github.com/mitchfen/momentum" 
        },
        new Project { 
            Name = "mitchfen.com", 
            Description = "This website.", 
            Link = "https://github.com/mitchfen/mitchfen.com" 
        },
       new Project { 
            Name = "osrs-herb-run-helper", 
            Description = "Quickly find the most profitable herb to farm.", 
            Link = "https://github.com/mitchfen/osrs-herb-run-helper" 
        },
 
  };
}
