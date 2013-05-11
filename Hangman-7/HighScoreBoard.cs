using System;
using System.Linq;

internal class HighScoreBoard
{
    private const int HIGHSCORE_NUMBER_OF_RESULTS = 6;

    private TopPlayer[] highscores;

    public HighScoreBoard(int numberResults = HIGHSCORE_NUMBER_OF_RESULTS)
    {
        this.highscores = new TopPlayer[numberResults];
    }

    public TopPlayer[] HighScores { 
        get
        {
            return this.highscores;
        } 
    }

    public int HighScoreCount
    {
        get
        {
            return this.GetHighScoreCount();
        }
    }

    public int GetHighScoreCount()
    {
        int count = 0;

        for (int i = 0; i < this.highscores.Length; i++)
        {
            if (this.highscores[i] != null)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        return count;
    }

    public bool IsResultAHighScore(int score)
    {
        bool isResultAHighScore = false;

        if (this.HighScoreCount < 6)
        {
            isResultAHighScore = true;
        }
        else
        {
            isResultAHighScore = this.HighScores[this.HighScoreCount - 1].PlayerScore > score;
        }

        return isResultAHighScore;
    }

    public void AddPlayer(TopPlayer newPlayer)
    {
        if (IsResultAHighScore(newPlayer.PlayerScore))
        {
            int newHighScoreIndex = this.HighScoreCount;
            if (this.HighScoreCount == this.highscores.Length)
            {
                newHighScoreIndex = this.HighScoreCount - 1;
            }

            this.highscores[newHighScoreIndex] = newPlayer;
            if (this.HighScoreCount > 1)
            {
                HighScoresSort();
            }
        }
    }

    private void HighScoresSort()
    {
        TopPlayer[] currectHighScores = this.HighScores;


        for (int i = 1; i < this.HighScoreCount; i++)
        {
            for (int j = i; j > 0; j--)
            {
                int currentPlayerScore = currectHighScores[j].PlayerScore;
                int previousPlayerScore = currectHighScores[j - 1].PlayerScore;
                if (currentPlayerScore.CompareTo(previousPlayerScore) < 0)
                {
                    var intermediateValue = currectHighScores[j];
                    currectHighScores[j] = currectHighScores[j - 1];
                    currectHighScores[j - 1] = intermediateValue;
                }
            }
        }

        this.highscores = currectHighScores;
    }
}