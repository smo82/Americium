using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The class that holds a single hidden word
/// </summary>
public class Word
{
    /// <summary>
    /// The original word string
    /// </summary>
    private string word;

    /// <summary>
    /// Holds the hidden representation of the current word
    /// </summary>
    private StringBuilder printedWord = new StringBuilder();

    /// <summary>
    /// Initializes a new instance of the <see cref="Word" /> class.
    /// </summary>
    /// <param name="word">The original word string</param>
    public Word(string word)
    {
        this.word = word;
        string hiddenWord = this.GenerateHiddenWordString();
        this.printedWord.Append(hiddenWord);
    }

    /// <summary>
    /// Gets the original word string
    /// </summary>
    public string GetWord
    {
        get
        {
            return this.word;
        }
    }
    
    /// <summary>
    /// Gets the hidden word string
    /// </summary>
    public string GetHiddenWord
    {
        get
        {
            return this.printedWord.ToString();
        }
    }

    /// <summary>
    /// Check if a given letter is present in the word
    /// </summary>
    /// <param name="letter">The letter to be checked</param>
    /// <returns>Returns true if the letter is present in the word and false otherwise </returns>
    public bool CheckForLetter(char letter)
    {
        if (this.word.Contains(char.ToLower(letter)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Writes a single letter in the hidden word.
    /// All occurrences of the letter are revealed
    /// </summary>
    /// <param name="letter">The letter to be written</param>
    /// <returns>Returns the hidden word with the all occurrences of the new letter revealed</returns>
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

        return this.printedWord.ToString();
    }

    /// <summary>
    /// Get how many times a letter is found in the word
    /// </summary>
    /// <param name="letter">The letter to be searched</param>
    /// <returns>The number of occurrences</returns>
    public int NumberOfMatches(char letter)
    {
        int result = 0;
        char lowerLetter = char.ToLower(letter);
        for (int index = 0; index < this.word.Length; index++)
        {
            if (this.word[index] == lowerLetter)
            {
                result++;
            }
        }

        return result;
    }

    /// <summary>
    /// Checks if all the letters of the hidden word are revealed
    /// </summary>
    /// <returns>Returns true if all letters are revealed and false otherwise</returns>
    public bool WordIsFound()
    {
        return !this.GetHiddenWord.Contains('_');
    }

    /// <summary>
    /// Reveals the first hidden letter from the hidden word and writes it in the hidden word
    /// </summary>
    /// <returns>Returns the letter that is revealed</returns>
    public char RevealLetter()
    {
        int firstMissingLetter = this.GetHiddenWord.IndexOf('_');
        if (firstMissingLetter == -1)
        {
            throw new InvalidOperationException("There are no hidden words in this letter");
        }

        char revealedLetter = this.GetWord[firstMissingLetter / 2];
        this.WriteTheLetter(revealedLetter);
        return revealedLetter;
    }

    /// <summary>
    /// Generates the hidden representation of the original word
    /// </summary>
    /// <returns>Returns the hidden representation of the original word</returns>
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
