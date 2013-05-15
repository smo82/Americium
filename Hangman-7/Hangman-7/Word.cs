using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Word
{
    private string word;
    private StringBuilder printedWord = new StringBuilder();

    public Word(string word)
    {
        this.word = word;
        string hiddenWord = GenerateHiddenWordString();
        this.printedWord.Append(hiddenWord);
    }

    public string GetPlayedWord()
    {
        return this.word;
    }

    public string GetPrintedWord()
    {
        return this.printedWord.ToString();
    }

    public bool CheckForLetter(char letter)
    {
        if (word.Contains(char.ToLower(letter)))
        {
            return true;
        }
        else return false;
    }

    public string WriteTheLetter(char letter)
    {
        char lowerLetter = char.ToLower(letter);

        for (int index = 0; index < this.word.Length; index++)
        {
            if (lowerLetter == this.word[index])
            {
                this.printedWord[index * 2] = lowerLetter;
            }
        }

        return printedWord.ToString();
    }

    public int NumberOfMatches(char letter)
    {
        int result = 0;
        char lowerLetter = char.ToLower(letter);
        for (int index = 0; index < word.Length; index++)
        {
            if (this.word[index] == lowerLetter)
            {
                result++;
            }
        }
        return result;
    }

    private string GenerateHiddenWordString()
    {
        StringBuilder hiddenWord = new StringBuilder();
        for (int index = 0; index < this.word.Length; index++)
        {
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
        int firstMissingLetter = this.GetPrintedWord().IndexOf('_');
        char revealedLetter = this.GetPlayedWord()[firstMissingLetter / 2];
        //  this.WriteTheLetter(revealedLetter);
        return revealedLetter;
    }
}

