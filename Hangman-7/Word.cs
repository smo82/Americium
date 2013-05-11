using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class Word
{
    private string w;
    private StringBuilder PrintedWord = new StringBuilder();

    public Word(string word)
    {
        this.w = word;
        string hiddenWord = GenerateHiddenWordString();
        this.PrintedWord.Append(hiddenWord);
    }

    public string GetPlayedWord()
    {
        return this.w;
    }
    
    public string GetPrintedWord()
    {
        return this.PrintedWord.ToString();
    }

    public bool CheckForLetter(char TheLetter)
    {
        if (w.Contains(char.ToLower(TheLetter)))
        {
            return true;
        }
        else return false;
    }

    public string WriteTheLetter(char TheLetter)
    {

        for (int WordLenght = 0; WordLenght < w.Length - 1; WordLenght++)
        {
            if (this.w.IndexOf(char.ToLower(TheLetter), WordLenght) >= 0)
            {
                this.PrintedWord[this.w.IndexOf(char.ToLower(TheLetter), WordLenght) * 2] = TheLetter;
            }
        }

        return PrintedWord.ToString();
    }

    public int NumberOfMatches(char TheLetter)
    {
        int Number = 0;
        for (int WordLenght = 0; WordLenght < w.Length; WordLenght++)
        {
            if (this.w[WordLenght].Equals(char.ToLower(TheLetter)))
                Number++;
        }
        return Number;
    }

    private string GenerateHiddenWordString()
    {
        StringBuilder hiddenWord = new StringBuilder();
        for (int WordLenght = 0; WordLenght < this.w.Length; WordLenght++)
        {
            //makes _ _ _ _ _...
            hiddenWord.Append("_ ");
        }
        return hiddenWord.ToString();
    }

    public bool WordIsFound()
    {
        return !this.GetPrintedWord().Contains('_');
    }

    public char RevealLetter()
    {
        int FirstMissingLetter = this.GetPrintedWord().IndexOf('_');
        char revealedLetter = this.GetPlayedWord()[FirstMissingLetter / 2];
        this.WriteTheLetter(revealedLetter);
        return revealedLetter;
    }
}

