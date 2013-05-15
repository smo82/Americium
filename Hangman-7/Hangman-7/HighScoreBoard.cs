using System;
using System.Collections.Generic;
using System.Linq;

public class HighScoreBoard
{
    private const int HIGHSCORE_NUMBER_OF_RESULTS = 5;

    private List<TopPlayer> highscores;

    public HighScoreBoard()
    {
        this.highscores = new List<TopPlayer>();
    }

    public List<TopPlayer> HighScores
    { 
        get
        {
            return this.highscores;
        }
        private set
        {
             this.highscores=value;
        }
    }

    public int HighScoreCount
    {
        get
        {
            return this.HighScores.Count;
        }
    }

    
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

    public void AddPlayer(TopPlayer newPlayer)
    {
        if (IsResultHighScore(newPlayer.PlayerScore))
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
                this.HighScores=this.HighScores.OrderBy(x => x.PlayerScore).ToList();
            }
        }
    }

}