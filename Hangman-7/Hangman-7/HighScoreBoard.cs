using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The players HighScore board class
/// </summary>
public class HighScoreBoard
{
    /// <summary>
    /// The number of results that the HighScore board holds
    /// </summary>
    private const int HIGHSCORE_NUMBER_OF_RESULTS = 5;

    /// <summary>
    /// Initializes a new instance of the <see cref="HighScoreBoard" /> class.
    /// </summary>
    public HighScoreBoard()
    {
        this.HighScores = new List<TopPlayer>();
    }

    /// <summary>
    /// Gets the list of HighScores
    /// </summary>
    public List<TopPlayer> HighScores { get; private set; }
    
    /// <summary>
    /// Gets the HighScore count
    /// </summary>
    public int HighScoreCount
    {
        get
        {
            return this.HighScores.Count;
        }
    }

    /// <summary>
    /// Checks if a given score is good enough to be added to the HighScore board
    /// </summary>
    /// <param name="score">The score checked</param>
    /// <returns>Returns true if the score is good enough or false otherwise </returns>
    public bool IsResultHighScore(int score)
    {
        bool isResultHighScore = false;

        if (this.HighScoreCount < HIGHSCORE_NUMBER_OF_RESULTS)
        {
            isResultHighScore = true;
        }
        else
        {
            isResultHighScore = this.HighScores.Last().PlayerScore > score;
        }

        return isResultHighScore;
    }

    /// <summary>
    /// Adds a player to the HighScore board
    /// </summary>
    /// <param name="newPlayer">The player to be added to the HighScore board</param>
    public void AddPlayer(TopPlayer newPlayer)
    {
        if (this.IsResultHighScore(newPlayer.PlayerScore))
        {
            int newHighScoreIndex = this.HighScoreCount;
            if (this.HighScoreCount == HIGHSCORE_NUMBER_OF_RESULTS)
            {
                newHighScoreIndex = this.HighScoreCount - 1;
                this.HighScores[newHighScoreIndex] = newPlayer;
            }
            else
            {
                this.HighScores.Add(newPlayer);
            }

            if (this.HighScoreCount > 1)
            {
                this.HighScores = this.HighScores.OrderBy(x => x.PlayerScore).ToList();
            }
        }
    }
}