namespace MitchfenSite;

public enum Location { Clearing, House, Forest }

public class GameState
{
    public List<string> InputCommands { get; set; }

    public Location PlayerLocation { get; set; }

    public GameState()
    {
        this.PlayerLocation = Location.Clearing;
        InputCommands = new List<string>();
    }
}
