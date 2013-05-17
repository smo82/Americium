using System;

/// <summary>
/// Represents the User interfaces used for the Hangman game
/// </summary>
public interface IUserInterface
{
    /// <summary>
    /// Indicates if the user has entered a single letter
    /// </summary>
    event EventHandler SingleLetterEntered;

    /// <summary>
    /// Indicates if the user has requested help
    /// </summary>
    event EventHandler HelpRequest;

    /// <summary>
    /// Indicates if the user has requested for the HighScore board to be displayed
    /// </summary>
    event EventHandler HighscoreRequest;

    /// <summary>
    /// Indicates if the user has requested for the game to be restarted
    /// </summary>
    event EventHandler GameRestart;

    /// <summary>
    /// Indicates if the user has requested to exit the application
    /// </summary>
    event EventHandler GameExit;

    /// <summary>
    /// Indicates if the user has entered an incorrect input
    /// </summary>
    event EventHandler IncorrectInput;

    /// <summary>
    /// Reads and processed the user input from the User interface
    /// </summary>
    /// <param name="wordData">The data object that holds information for the current word</param>
    void GetUserInput(WordData wordData);

    /// <summary>
    /// Reads a single line from the User interface
    /// </summary>
    /// <returns>Returns the string that was read</returns>
    string ReadSingleInputLine();

    /// <summary>
    /// Writes an output line to the User interface
    /// </summary>
    /// <param name="output">The string that we want to write</param>
    void WriteSingleOutputLine(string output);

    /// <summary>
    /// Clears the User interface
    /// </summary>
    void Clear();
}
