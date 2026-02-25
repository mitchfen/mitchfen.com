namespace MitchfenSite.Models;

public class Project
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string? Link { get; set; }
    public bool IsRedacted { get; set; }
}
