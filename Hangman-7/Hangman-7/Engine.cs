using System;
using System.Collections.Generic;

/// <summary>
/// The Hangman game engine class
/// </summary>
internal class Engine
{
    /// <summary>
    /// The welcome message when the game starts
    /// </summary>
    private const string WELCOME_MESSAGE =
                "\nWelcome to “Hangman” game.Please try to guess my secret word.\n" +
                "Use 'top' to view the top scoreboard,'restart' to start a new game, \n" +
                "'help' to cheat and 'exit' to quit the game.\n";

    /// <summary>
    /// Holds the array of words to be used by the game engine
    /// </summary>
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

    /// <summary>
    /// The user interface object to be used
    /// </summary>
    private readonly IUserInterface USER_INTERFACE;

    /// <summary>
    /// The current HighScore board of the game
    /// </summary>
    private HighScoreBoard highScoreBoard = new HighScoreBoard();

    /// <summary>
    /// The current word used in the game
    /// </summary>
    private Word currentWord = null;

    /// <summary>
    /// The number of mistakes that the player have made during the current session of the game
    /// </summary>
    private int currentMistakesCount = 0;

    /// <summary>
    /// Holds a boolean value if the user has used any help during the current session of the game
    /// </summary>
    private bool usedHelp = false;

    /// <summary>
    /// Holds a boolean value which indicates if the game should be restarted
    /// </summary>
    private bool restart = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="Engine" /> class.
    /// </summary>
    /// <param name="userInterface">This is the user interface that the engine will be using</param>
    public Engine(IUserInterface userInterface)
    {
        this.USER_INTERFACE = userInterface;
        this.ConnectEngineWithUserInterface();
    }

    /// <summary>
    /// This methods is used for returning the engine in its initial state 
    /// </summary>
    public void InitializeEngine()
    {
        this.highScoreBoard = new HighScoreBoard();
        this.currentWord = null;
        this.currentMistakesCount = 0;
        this.usedHelp = false;
        this.restart = false;
    }

    /// <summary>
    /// Runs the game engine
    /// </summary>
    public void Run()
    {
        while (true)
        {
            this.USER_INTERFACE.WriteSingleOutputLine(WELCOME_MESSAGE);

            this.currentMistakesCount = 0;

            string randomWord = GetRandomWord();
            this.currentWord = new Word(randomWord);

            while (!this.currentWord.WordIsFound())
            {
                this.USER_INTERFACE.GetUserInput(new WordData(this.currentWord));
                if (this.restart)
                {
                    this.restart = false;
                    break;
                }
            }

            if (this.currentWord.WordIsFound())
            {
                this.ProcessWin();

                this.currentMistakesCount = 0;
                this.usedHelp = false;
            }
        }
    }

    /// <summary>
    /// Processes the event Single letter entered by the user
    /// Checks if the letter is present in the current word and prints at the User interface the appropriate message
    /// </summary>
    /// <param name="singleLetterEventArgs">The single letter entered by the user</param>
    public void ProcessSingleLetterEntered(SingleLetterEventArgs singleLetterEventArgs)
    {
        this.USER_INTERFACE.Clear();
        char inputLetterToLower = singleLetterEventArgs.Letter;
        if (this.currentWord.CheckForLetter(inputLetterToLower))
        {
            this.currentWord.WriteTheLetter(inputLetterToLower);
            string revealMessage = "Good job! You revealed " + this.currentWord.NumberOfMatches(inputLetterToLower) + " letter";
            this.USER_INTERFACE.WriteSingleOutputLine(revealMessage);
        }
        else
        {
            string wrongLetterMessage = "Sorry! There are no unrevealed letters " + "\"" + inputLetterToLower + "\"";
            this.USER_INTERFACE.WriteSingleOutputLine(wrongLetterMessage);
            this.currentMistakesCount++;
        }
    }

    /// <summary>
    /// Processes the event Help request entered by the user.
    /// Reveals a single letter from the current word. 
    /// Raises the flag that the user has used help.
    /// </summary>
    public void ProcessHelpRequest()
    {
        this.USER_INTERFACE.Clear();
        char revealedLetter = this.currentWord.RevealLetter();
        string helpMessage = "OK, I reveal for you the next letter \"" + revealedLetter + "\"";
        this.USER_INTERFACE.WriteSingleOutputLine(helpMessage);
        this.usedHelp = true;
    }

    /// <summary>
    /// Processes the event HighScore display request entered by the user.
    /// Displays the current HighScore
    /// </summary>
    public void ProcessHighscoreRequest()
    {
        this.USER_INTERFACE.Clear();
        this.USER_INTERFACE.WriteSingleOutputLine("Scoreboard: ");

        if (this.highScoreBoard.HighScoreCount == 0)
        {
            this.USER_INTERFACE.WriteSingleOutputLine("Scoreboard is empty");
        }
        else
        {
            IList<TopPlayer> highScorePlayerList = this.highScoreBoard.HighScores;
            int highScoreCount = this.highScoreBoard.HighScoreCount;
            for (int playersNumber = 0; playersNumber < highScoreCount; playersNumber++)
            {
                string playerScoreMessage = highScorePlayerList[playersNumber].PlayerScore.ToString() 
                    + " " + highScorePlayerList[playersNumber].PlayerName;
                this.USER_INTERFACE.WriteSingleOutputLine(playerScoreMessage);
            } 
        }
    }

    /// <summary>
    /// Processes the event Game restart entered by the user.
    /// Restarts the game.
    /// </summary>
    public void ProcessGameRestart()
    {
        this.USER_INTERFACE.Clear();
        this.USER_INTERFACE.WriteSingleOutputLine("Game is Restarted");
        this.restart = true;
    }

    /// <summary>
    /// Processes the event Exit request entered by the user.
    /// Exits the application
    /// </summary>
    public void ProcessGameExit()
    {
        this.USER_INTERFACE.Clear();
        Environment.Exit(0);
    }

    /// <summary>
    /// Processes the event Incorrect input entered by the user.
    /// Prints an appropriate message at the User interface
    /// </summary>
    public void ProcessIncorrectInput()
    {
        this.USER_INTERFACE.Clear();
        this.USER_INTERFACE.WriteSingleOutputLine("Incorrect input");
        this.currentMistakesCount++;
    }

    /// <summary>
    /// Gets a random word from the Words repository
    /// </summary>
    /// <returns>Returns the word</returns>
    private static string GetRandomWord()
    {
        Random randomWordGenerator = new Random();
        string randomWord = WORDS_REPOSITORY[randomWordGenerator.Next(0, WORDS_REPOSITORY.Length)];
        return randomWord;
    }

    /// <summary>
    /// Performs the initial link between the User interface and the Game engine
    /// </summary>
    private void ConnectEngineWithUserInterface()
    {
        this.USER_INTERFACE.SingleLetterEntered += (sender, eventInfo) =>
        {
            this.ProcessSingleLetterEntered(eventInfo as SingleLetterEventArgs);
        };

        this.USER_INTERFACE.HelpRequest += (sender, eventInfo) =>
        {
            this.ProcessHelpRequest();
        };

        this.USER_INTERFACE.HighscoreRequest += (sender, eventInfo) =>
        {
            this.ProcessHighscoreRequest();
        };

        this.USER_INTERFACE.GameRestart += (sender, eventInfo) =>
        {
            this.ProcessGameRestart();
        };

        this.USER_INTERFACE.GameExit += (sender, eventInfo) =>
        {
            this.ProcessGameExit();
        };

        this.USER_INTERFACE.IncorrectInput += (sender, eventInfo) =>
        {
            this.ProcessIncorrectInput();
        };
    }

    /// <summary>
    /// Processes the Game win event
    /// Writes an appropriate message on the User interface and updates the HighScore
    /// </summary>
    private void ProcessWin()
    {
        this.USER_INTERFACE.WriteSingleOutputLine("The secret word is " + this.currentWord.GetHiddenWord);
        this.USER_INTERFACE.WriteSingleOutputLine("\nYou won with " + this.currentMistakesCount + " mistakes");

        bool betterThanLast = this.highScoreBoard.IsResultHighScore(this.currentMistakesCount);

        if (!this.usedHelp && betterThanLast)
        {
            this.USER_INTERFACE.WriteSingleOutputLine("\nPlease enter your name for the top scoreboard: ");

            string playerName = this.USER_INTERFACE.ReadSingleInputLine();
            int playerScore = this.currentMistakesCount;
            TopPlayer newTopPlayer = new TopPlayer(playerName, playerScore);

            this.highScoreBoard.AddPlayer(newTopPlayer);

            this.ProcessHighscoreRequest();
        }
        else if (!betterThanLast)
        {
            this.USER_INTERFACE.WriteSingleOutputLine(" but your result is lower than top scores\n");
        }
        else
        {
            this.USER_INTERFACE.WriteSingleOutputLine(" but you have cheated. \nYou are not allowed to enter into the scoreboard.\n");
        }
    }
}