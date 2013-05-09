using System;
using System.Linq;
using System.Text;

internal class GameEngine
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

    private const int ONE_LETTER = 1;
    private const double NOT_REAL_PLAYER = 1000000000.5;
    private const int HIGHSCORE_NUMBER_OF_RESULTS = 6;
    private static TopPlayer DefaultTopPlayer = new TopPlayer { PlayerName = "", PlayerScore = NOT_REAL_PLAYER };
    private static TopPlayer[] HighScore = new TopPlayer[HIGHSCORE_NUMBER_OF_RESULTS];


    private static char InputLetter;
    private static bool NotUseHelp = true;
    private static int GameCounter = 0;

    private static void Main()
    {
        InitializeEngine();

        while (true)
        {
            //main loop, used to restart game automatically

            Console.Write("\nWelcome to “Hangman” game.Please try to guess my secret word.\nUse 'top' to view the top scoreboard,"
                          + "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.\n");

            int PlayerMistakes = 0;
            Random RandomWord = new Random();
            string PlayedWord = WORDS_REPOSITORY[RandomWord.Next(0, WORDS_REPOSITORY.Length)];
            StringBuilder PrintedWord = new StringBuilder();
            StringBuilder InputString = new StringBuilder();

            for (int WordLenght = 0; WordLenght < PlayedWord.Length; WordLenght++)
            {
                //makes _ _ _ _ _...
                PrintedWord.Append("_ ");
            }

            Word WordsInGame = new Word();
            WordsInGame.SetPlayedWord(PlayedWord);
            WordsInGame.SetPrintedWord(PrintedWord);

            while (WordsInGame.GetPrintedWord().Contains('_'))
            {
                //start new game

                Console.WriteLine("The secret word is " + WordsInGame.GetPrintedWord());

                Console.Write("Enter your guess: ");
                InputString.Clear();
                InputString.Append(Console.ReadLine());

                if (InputString.Length == ONE_LETTER)
                {
                    InputLetter = (InputString[0]);
                }

                if (InputString.Length == ONE_LETTER && WordsInGame.Isletter(char.ToLower(InputLetter)))
                {
                    if (WordsInGame.CheckForLetter(char.ToLower(InputLetter)))
                    {
                        WordsInGame.WriteTheLetter(char.ToLower(InputLetter));
                        Console.WriteLine("Good job! You revealed " + WordsInGame.NumberOfInput(InputLetter) + " letter");
                    }
                    else
                    {
                        Console.WriteLine("Sorry! There are no unrevealed letters " + "\"" + char.ToLower(InputLetter) +
                                          "\"");
                        PlayerMistakes++;
                    }
                }
                else
                {
                    bool Restart = false;

                    switch (InputString.ToString())
                    {
                        case "help":
                            Help(WordsInGame);
                            break;

                        case "exit":
                            Environment.Exit(0);
                            break;

                        case "restart":
                            Restart = true;
                            break;

                        case "top":
                            Top();
                            break;

                        default:
                            {
                                Console.WriteLine("Incorect input");
                                PlayerMistakes++;
                                break;
                            }
                    }

                    if (Restart)
                    {
                        Console.WriteLine("Game is Restarted");
                        break;
                    }
                }
            } //end of while

            if (!WordsInGame.GetPrintedWord().Contains('_'))
            {
                Console.WriteLine("The secret word is " + WordsInGame.GetPrintedWord());
                Console.Write("\nYou won with " + PlayerMistakes + " mistakes");

                bool BetterThanLast = HighScore[4].PlayerScore > PlayerMistakes;
                if (NotUseHelp && BetterThanLast)
                {
                    Console.Write("\nPlease enter your name for the top scoreboard: ");

                    HighScore[GameCounter] = new TopPlayer
                        {
                            PlayerName = Console.ReadLine(),
                            PlayerScore = PlayerMistakes
                        };

                    if (GameCounter < 5)
                    {
                        GameCounter++;
                    }

                    Array.Sort(HighScore,
                               (TopPlayer1, topPlayer2) => TopPlayer1.PlayerScore.CompareTo(topPlayer2.PlayerScore));
                    Top();
                }
                else if (!BetterThanLast)
                {
                    Console.Write(" but your result is lower than top scores\n");
                }
                else
                {
                    Console.Write(" but you have cheated. \nYou are not allowed to enter into the scoreboard.\n");
                }

                PlayerMistakes = 0;
                NotUseHelp = true;
            }
        } //end of master loop
    }

    private static void InitializeEngine()
    {
        for (int playersNumber = 0; playersNumber < HIGHSCORE_NUMBER_OF_RESULTS; playersNumber++)
        {
            HighScore[playersNumber] = DefaultTopPlayer;
        }
    }

    private static void Top()
    {
        Console.WriteLine("Scoreboard: ");
        for (int playersNumber = 0; playersNumber < 5; playersNumber++)
        {
            if (HighScore[playersNumber].PlayerScore != NOT_REAL_PLAYER)
            {
                Console.WriteLine(HighScore[playersNumber].PlayerScore.ToString() + " " +
                                  HighScore[playersNumber].PlayerName);
            }
        }
        if (GameCounter == 0)
        {
            Console.WriteLine("Scoreboard is empty");
        }
    }

    private static void Help(Word Game)
    {
        Console.WriteLine("OK, I reveal for you the next letter " + "\""
                          + Game.GetPlayedWord()[Game.GetPrintedWord().IndexOf('_') / 2] + "\"");
        int FirstMissingLetter = Game.GetPrintedWord().IndexOf('_');
        Game.WriteTheLetter(Game.GetPlayedWord()[FirstMissingLetter / 2]);
        NotUseHelp = false;
    }
}