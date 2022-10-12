namespace MitchfenSite;

public enum Location { clearing, house, forest }

public class GameState
{
    public List<string> InputCommands { get; set; }

    public Location PlayerLocation { get; set; }

    public GameState()
    {
        this.PlayerLocation = Location.clearing;
        InputCommands = new List<string>();
    }
}
