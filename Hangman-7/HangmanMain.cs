using System;

public class HangmanMain
{
    private static void Main()
    {
        IUserInterface consoleInterface = new ConsoleInterface();
        Engine gameEngine = new Engine(consoleInterface);

        consoleInterface.SingleLetterEntered += (sender, eventInfo) =>
        {
            gameEngine.ProcessSingleLetterEntered(eventInfo as SingleLetterEventArgs);
        };

        consoleInterface.HelpRequest += (sender, eventInfo) =>
        {
            gameEngine.ProcessHelpRequest();
        };

        consoleInterface.HighscoreRequest += (sender, eventInfo) =>
        {
            gameEngine.ProcessHighscoreRequest();
        };

        consoleInterface.GameRestart += (sender, eventInfo) =>
        {
            gameEngine.ProcessGameRestart();
        };

        consoleInterface.GameExit += (sender, eventInfo) =>
        {
            gameEngine.ProcessGameExit();
        };

        consoleInterface.IncorrectInput += (sender, eventInfo) =>
        {
            gameEngine.ProcessIncorrectInput();
        };
        
        gameEngine.InitializeEngine();
        gameEngine.Run();
    }
}
