﻿using System;
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

    public string GetWord()
    {
        return this.word;
    }

    public string GetHiddenWord()
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

    public bool WordIsFound()
    {
        return !this.GetHiddenWord().Contains('_');
    }

    public char RevealLetter()
    {
        int firstMissingLetter = this.GetHiddenWord().IndexOf('_');
        char revealedLetter = this.GetWord()[firstMissingLetter / 2];
        this.WriteTheLetter(revealedLetter);
        return revealedLetter;
    }

    private string GenerateHiddenWordString()
    {
        StringBuilder hiddenWord = new StringBuilder();
        for (int index = 0; index < this.word.Length; index++)
        {
            hiddenWord.Append("_ ");
        }
        hiddenWord = hiddenWord.Remove(hiddenWord.Length - 1, 1);
        return hiddenWord.ToString();
    }
}

