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

    public void EnterCommand(string _newCommand)
    {
        if (string.IsNullOrEmpty(_newCommand)) return;
        this.InputCommands.Add("> " + _newCommand);
        switch(this.PlayerLocation)
        {
            case Location.Clearing:
                Clearing(_newCommand);
                break;
            case Location.Forest:
                Forest(_newCommand);
                break;
        }
    }

    public void Clearing(string _newCommand)
    {
        if (_newCommand == "look") 
        {
            this.InputCommands.Add("You are in a small clearing. There is a small mailbox here.");
        }
        if (_newCommand == "Open the mailbox") 
        {
            this.InputCommands.Add("You open the mailbox. There is a small leaflet inside.");
        }
        if (_newCommand == "Forest")
        {
            this.InputCommands.Add("Going to forest...");
            this.PlayerLocation = Location.Forest;
        }
    }

    public void Forest(string _newCommand)
    {
        if (_newCommand == "look")
        {
            this.InputCommands.Add("You are in a forest. The trees are very tall here.");
        }
        if (_newCommand == "Clearing")
        {
            this.InputCommands.Add("Going to clearing...");
            this.PlayerLocation = Location.Clearing;
        }
    }
}
