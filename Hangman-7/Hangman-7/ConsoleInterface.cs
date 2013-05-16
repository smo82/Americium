using System;
using System.Text;

public class ConsoleInterface : IUserInterface
{
    public void GetUserInput(WordData wordData)
    {
        Console.WriteLine("The secret word is " + wordData.ToPrint);

        Console.Write("Enter your guess: ");
        string inputString = Console.ReadLine();
        ProcessInput(inputString);
    }

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
            inputLetter = (inputString[0]);
        }

        if (inputString.Length == 1 && Char.IsLetter(char.ToLower(inputLetter)))
        {
            if (this.SingleLetterEntered != null)
            {
                this.SingleLetterEntered(this, new SingleLetterEventArgs(inputLetter));
            }
        }
        else
        {
            ProcessCommand(inputString);
        }
    }

    public string ReadSingleInputLine()
    {
        return Console.ReadLine();
    }

    public void WriteSingleOutputLine(string output)
    {
        Console.WriteLine(output);
    }
    
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

            case "top":
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

    public event EventHandler SingleLetterEntered;

    public event EventHandler HelpRequest;

    public event EventHandler HighscoreRequest;

    public event EventHandler GameRestart;

    public event EventHandler GameExit;

    public event EventHandler IncorrectInput;
}