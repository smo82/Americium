using System;

/// <summary>
/// This is the class that is used for the connection with the console interface
/// </summary>
public class ConsoleInterface : IUserInterface
{
    /// <summary>
    /// Indicates if the user has entered a single letter
    /// </summary>
    public event EventHandler SingleLetterEntered;

    /// <summary>
    /// Indicates if the user has requested help
    /// </summary>
    public event EventHandler HelpRequest;

    /// <summary>
    /// Indicates if the user has requested for the HighScore board to be displayed
    /// </summary>
    public event EventHandler HighscoreRequest;

    /// <summary>
    /// Indicates if the user has requested for the game to be restarted
    /// </summary>
    public event EventHandler GameRestart;

    /// <summary>
    /// Indicates if the user has requested to exit the application
    /// </summary>
    public event EventHandler GameExit;

    /// <summary>
    /// Indicates if the user has entered an incorrect input
    /// </summary>
    public event EventHandler IncorrectInput;

    /// <summary>
    /// Reads and processed the user input
    /// </summary>
    /// <param name="wordData">The data object that holds information for the current word</param>
    public void GetUserInput(WordData wordData)
    {
        Console.WriteLine("The secret word is " + wordData.HiddenWord);

        Console.Write("Enter your guess: ");
        string inputString = Console.ReadLine();
        this.ProcessInput(inputString);
    }

    /// <summary>
    /// Reads a single line from the console
    /// </summary>
    /// <returns>Returns the string that was read from the console</returns>
    public string ReadSingleInputLine()
    {
        return Console.ReadLine();
    }

    /// <summary>
    /// Writes an output line to the console
    /// </summary>
    /// <param name="output">The string that we want to write on the console</param>
    public void WriteSingleOutputLine(string output)
    {
        Console.WriteLine(output);
    }

    /// <summary>
    /// Clears the console
    /// </summary>
    public void Clear()
    {
        Console.Clear();
    }

    /// <summary>
    /// Processes the user input and triggers the appropriate event
    /// </summary>
    /// <param name="inputString">The user input</param>
    private void ProcessInput(string inputString)
    {
        if (inputString == null)
        {
            if (this.IncorrectInput != null)
            {
                this.IncorrectInput(this, new EventArgs());
            }

            return;
        }

        char inputLetter = '-';

        if (inputString.Length == 1)
        {
            inputLetter = inputString[0];
        }

        if (inputString.Length == 1 && char.IsLetter(char.ToLower(inputLetter)))
        {
            if (this.SingleLetterEntered != null)
            {
                this.SingleLetterEntered(this, new SingleLetterEventArgs(inputLetter));
            }
        }
        else
        {
            this.ProcessCommand(inputString);
        }
    }
    
    /// <summary>
    /// Processes the command entered by the user
    /// </summary>
    /// <param name="command">The command entered by the user</param>
    private void ProcessCommand(string command)
    {
        switch (command)
        {
            case "help":
                if (this.HelpRequest != null)
                {
                    this.HelpRequest(this, new EventArgs());
                }

                break;

            case "highscore":
                if (this.HighscoreRequest != null)
                {
                    this.HighscoreRequest(this, new EventArgs());
                }

                break;

            case "restart":
                if (this.GameRestart != null)
                {
                    this.GameRestart(this, new EventArgs());
                }

                break;

            case "exit":
                if (this.GameExit != null)
                {
                    this.GameExit(this, new EventArgs());
                }

                break;

            default:
            {
                if (this.IncorrectInput != null)
                {
                    this.IncorrectInput(this, new EventArgs());
                }

                break;
            }
        }
    }
}