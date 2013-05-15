public class TopPlayer
{
    public string PlayerName { get; set; }
    public int PlayerScore { get; set; }

    public TopPlayer()
        : this(null, 0)
    {
    }

    public TopPlayer(string playerName, int playerScore)
    {
        this.PlayerName = playerName;
        this.PlayerScore = playerScore;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is TopPlayer))
        {
            return false;
        }

        TopPlayer otherPlayer = obj as TopPlayer;
        if (otherPlayer.PlayerName!=this.PlayerName)
        {
            return false;
        }

        if (otherPlayer.PlayerScore != this.PlayerScore)
        {
            return false;
        }

        return true;
    }
}