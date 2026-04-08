using MitchfenSite.Models;

namespace MitchfenSite.Components;

public partial class Terminal
{
    private const string Header = "<span class='comment'>welcome to the mitchfen.com's TTY interface</span>";

    private List<Project> Projects = new()
    {
        new Project { 
            Name = "Nanoleaf Aurora Controller", 
            Description = "", 
            Link = "https://github.com/mitchfen/nanoleaf-controller",
            IsSelfHosted = true
        },
        new Project { 
            Name = "WiZ Controller", 
            Description = "", 
            Link = "https://github.com/mitchfen/wiz-controller",
            IsSelfHosted = true
        },
        new Project { 
            Name = "Momentum", 
            Description = "", 
            Link = "https://github.com/mitchfen/momentum",
            IsSelfHosted = true
        },
        new Project { 
            Name = "Weight Tracker", 
            Description = "", 
            Link = "https://github.com/mitchfen/weight-tracker",
            IsSelfHosted = true
        },
        new Project { 
            Name = "mitchfen.com", 
            Description = "", 
            Link = "https://github.com/mitchfen/mitchfen.com",
            IsCloudHosted = true
        },
        new Project { 
            Name = "OSRS herb run helper", 
            Description = "", 
            Link = "https://github.com/mitchfen/osrs-herb-run-helper",
            IsCli = true
        },
        new Project { 
            Name = "Highsec Ore Price Checker", 
            Description = "", 
            Link = "https://github.com/mitchfen/highsec-ore-price-checker",
            IsCli = true
        },
        new Project { 
            Name = "Update Arch", 
            Description = "", 
            Link = "https://github.com/mitchfen/update-arch",
            IsCli = true
        }
    };
}
