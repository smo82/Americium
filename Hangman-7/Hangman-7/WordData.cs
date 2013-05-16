using System;

public struct WordData
{
    public WordData(Word originalWord) : this ()
    {
        this.ToPrint = originalWord.GetHiddenWord();
    }

    public string ToPrint { get; private set; }
}