using System;

/// <summary>
/// The struct that represents the data for a single Word
/// </summary>
public class SingleLetterEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SingleLetterEventArgs" /> class.
    /// </summary>
    /// <param name="letter">The letter</param>
    public SingleLetterEventArgs(char letter)
    {
        this.Letter = letter;
    }

    /// <summary>
    /// Gets the event argument letter
    /// </summary>
    public char Letter { get; private set; }
}