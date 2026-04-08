namespace MitchfenSite.Models;

public class Project
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string? Link { get; set; }
    public bool IsRedacted { get; set; }
    public bool IsSelfHosted { get; set; }
    public bool IsCli { get; set; }
    public bool IsCloudHosted { get; set; }
}
