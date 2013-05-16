using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

internal class Engine
{
    private static readonly string[] WORDS_REPOSITORY =
        {
            "computer",
            "programmer",
            "software",
            "debugger",
            "compiler",
            "developer",
            "algorithm",
            "array",
            "method",
            "variable"
        };

    private static HighScoreBoard highScoreBoard = new HighScoreBoard();
    private Word currentWord;
    private int currentMistakesCount = 0;
    private bool NotUseHelp = true;
    private bool restart = false;
    private IUserInterface userInterface;

    public Engine(IUserInterface userInterface)
    {
        this.userInterface = userInterface;
    }

    public void InitializeEngine()
    {
    }

    public void Run()
    {
        while (true)
        {
            string welcomeMessage =
                "\nWelcome to “Hangman” game.Please try to guess my secret word.\nUse 'top' to view the top scoreboard,'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.\n";
            this.userInterface.WriteSingleOutputLine(welcomeMessage);

            this.currentMistakesCount = 0;

            string PlayedWord = GetRandomWord();
            this.currentWord = new Word(PlayedWord);

            while (!currentWord.WordIsFound())
            {
                this.userInterface.GetUserInput(new WordData(this.currentWord));
                if (this.restart)
                {
                    this.restart = false;
                    break;
                }
            }

            if (currentWord.WordIsFound())
            {
                ProcessWin();

                this.currentMistakesCount = 0;
                NotUseHelp = true;
            }
        }
    }

    public void ProcessSingleLetterEntered(SingleLetterEventArgs singleLetterEventArgs)
    {
        char inputLetterToLower = singleLetterEventArgs.Letter;
        if (this.currentWord.CheckForLetter(inputLetterToLower))
        {
            this.currentWord.WriteTheLetter(inputLetterToLower);
            string revealMessage = "Good job! You revealed " + this.currentWord.NumberOfMatches(inputLetterToLower) + " letter";
            this.userInterface.WriteSingleOutputLine(revealMessage);
        }
        else
        {
            string wrongLetterMessage = "Sorry! There are no unrevealed letters " + "\"" + inputLetterToLower + "\"";
            this.userInterface.WriteSingleOutputLine(wrongLetterMessage);
            this.currentMistakesCount++;
        }
    }

    public void ProcessHelpRequest()
    {
        char revealedLetter = this.currentWord.RevealLetter();
        string helpMessage = "OK, I reveal for you the next letter \"" + revealedLetter + "\"";
        this.userInterface.WriteSingleOutputLine(helpMessage);
        NotUseHelp = false;
    }

    public void ProcessHighscoreRequest()
    {
        this.userInterface.WriteSingleOutputLine("Scoreboard: ");

        if (highScoreBoard.HighScoreCount == 0)
        {
            this.userInterface.WriteSingleOutputLine("Scoreboard is empty");
        }
        else
        {
            IList<TopPlayer> highScorePlayerList = highScoreBoard.HighScores;
            int highScoreCount = highScoreBoard.HighScoreCount;
            for (int playersNumber = 0; playersNumber < highScoreCount; playersNumber++)
            {
                string playerScoreMessage = highScorePlayerList[playersNumber].PlayerScore.ToString() 
                    + " " + highScorePlayerList[playersNumber].PlayerName;
                this.userInterface.WriteSingleOutputLine(playerScoreMessage);
            } 
        }
    }

    public void ProcessGameRestart()
    {
        this.userInterface.WriteSingleOutputLine("Game is Restarted");
        this.restart = true;
    }

    public void ProcessGameExit()
    {
        Environment.Exit(0);
    }

    public void ProcessIncorrectInput()
    {
        this.userInterface.WriteSingleOutputLine("Incorrect input");
        this.currentMistakesCount++;
    }

    private static string GetRandomWord()
    {
        Random RandomWord = new Random();
        string PlayedWord = WORDS_REPOSITORY[RandomWord.Next(0, WORDS_REPOSITORY.Length)];
        return PlayedWord;
    }

    private void ProcessWin()
    {
        this.userInterface.WriteSingleOutputLine("The secret word is " + this.currentWord.GetHiddenWord());
        this.userInterface.WriteSingleOutputLine("\nYou won with " + this.currentMistakesCount + " mistakes");

        bool BetterThanLast = highScoreBoard.IsResultHighScore(this.currentMistakesCount);

        if (NotUseHelp && BetterThanLast)
        {
            this.userInterface.WriteSingleOutputLine("\nPlease enter your name for the top scoreboard: ");

            TopPlayer newTopPlayer = new TopPlayer()
                {
                    PlayerName = this.userInterface.ReadSingleInputLine(),
                    PlayerScore = this.currentMistakesCount
                };

            highScoreBoard.AddPlayer(newTopPlayer);

            ProcessHighscoreRequest();
        }
        else if (!BetterThanLast)
        {
            this.userInterface.WriteSingleOutputLine(" but your result is lower than top scores\n");
        }
        else
        {
            this.userInterface.WriteSingleOutputLine(" but you have cheated. \nYou are not allowed to enter into the scoreboard.\n");
        }
    }
}