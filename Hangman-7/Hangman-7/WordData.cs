using System;

internal struct WordData
{
    public WordData(Word originalWord) : this ()
    {
        this.ToPrint = originalWord.GetPrintedWord();
    }

    public string ToPrint { get; private set; }
}