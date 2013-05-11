using System;

internal interface IUserInterface
{
    event EventHandler SingleLetterEntered;

    event EventHandler HelpRequest;

    event EventHandler HighscoreRequest;

    event EventHandler GameRestart;

    event EventHandler GameExit;

    event EventHandler IncorrectInput;

    void ProcessInput(WordData wordData);

    string ReadSingleInputLine();

    void WriteSingleOutputLine(string message);
}
