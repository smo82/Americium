using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class WordTests
{
    [TestMethod]
    public void WriteTheLetterTest()
    {
        Word word = new Word("array");
        string expected = "a _ _ a _ ";
        string actual = word.WriteTheLetter('a');
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void NumberOfMatchesTest()
    {
        Word word = new Word("array");
        int expected = 2;
        int actual = word.NumberOfMatches('a');
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void WordIsFoundTest()
    {
        Word word = new Word("array");
        bool expected = true;
        string currentPrint = word.WriteTheLetter('a');
        currentPrint = word.WriteTheLetter('r');
        currentPrint = word.WriteTheLetter('y');
        bool actual = word.WordIsFound();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void CheckForLetterTest()
    {
        Word word = new Word("array");
        bool expected = true;
        bool actual = word.CheckForLetter('a');
        Assert.AreEqual(expected, actual);
    }
}

