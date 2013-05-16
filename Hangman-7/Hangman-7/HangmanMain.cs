/// <summary>
/// The Hangman game entry point
/// </summary>
public class HangmanMain
{
    /// <summary>
    /// This is the main method of the application. Here we create the User interface and the game engine objects
    /// After that the game engine is initialized and launched
    /// </summary>
    private static void Main()
    {
        IUserInterface consoleInterface = new ConsoleInterface();
        Engine gameEngine = new Engine(consoleInterface);
        
        gameEngine.InitializeEngine();
        gameEngine.Run();
    }
}
