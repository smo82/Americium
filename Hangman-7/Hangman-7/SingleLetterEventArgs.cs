using System;

public class SingleLetterEventArgs : EventArgs
{
    public SingleLetterEventArgs(char letter)
    {
        this.Letter = letter;
    }

    public char Letter { get; private set; }
}