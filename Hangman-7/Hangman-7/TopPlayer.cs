/// <summary>
/// The class that hold a player and his scores
/// </summary>
public class TopPlayer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TopPlayer" /> class.
    /// </summary>
    public TopPlayer()
        : this(null, 0)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TopPlayer" /> class.
    /// </summary>
    /// <param name="playerName">The player name</param>
    /// <param name="playerScore">The player score</param>
    public TopPlayer(string playerName, int playerScore)
    {
        this.PlayerName = playerName;
        this.PlayerScore = playerScore;
    }

    /// <summary>
    /// Gets or sets the player name
    /// </summary>
    public string PlayerName { get; set; }

    /// <summary>
    /// Gets or sets the player score
    /// </summary>
    public int PlayerScore { get; set; }
}