using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTest
{
    [TestClass]
    public class WordTest
    {
        [TestMethod]
        public void TestGetWord()
        {
            Word word = new Word("test");

            string originalWord = word.GetWord();
            Assert.AreEqual(originalWord, "test");
        }

        [TestMethod]
        public void TestGetHiddenWord()
        {
            Word word = new Word("test");

            string hiddenWord = word.GetHiddenWord();
            Assert.AreEqual(hiddenWord, "_ _ _ _");
        }

        [TestMethod]
        public void TestCheckForLetter()
        {
            Word word = new Word("test");

            bool isLetterFound = word.CheckForLetter('t');
            Assert.IsTrue(isLetterFound);
        }

        [TestMethod]
        public void TestCheckForLetterMissing()
        {
            Word word = new Word("test");

            bool isLetterFound = word.CheckForLetter('o');
            Assert.IsFalse(isLetterFound);
        }

        [TestMethod]
        public void TestWriteTheLetter()
        {
            Word word = new Word("test");

            string resultHiddenLetter = word.WriteTheLetter('t');
            Assert.AreEqual(resultHiddenLetter, "t _ _ t");

            resultHiddenLetter = word.WriteTheLetter('e');
            Assert.AreEqual(resultHiddenLetter, "t e _ t");
        }

        [TestMethod]
        public void TestWriteTheLetterMissing()
        {
            Word word = new Word("test");

            string resultHiddenLetter = word.WriteTheLetter('o');
            Assert.AreEqual(resultHiddenLetter, "_ _ _ _");
        }

        [TestMethod]
        public void TestNumberOfMatches()
        {
            Word word = new Word("test");

            int resultNumberOfMatches = word.NumberOfMatches('t');
            Assert.AreEqual(resultNumberOfMatches, 2);

            resultNumberOfMatches = word.NumberOfMatches('e');
            Assert.AreEqual(resultNumberOfMatches, 1);

            resultNumberOfMatches = word.NumberOfMatches('o');
            Assert.AreEqual(resultNumberOfMatches, 0);
        }

        [TestMethod]
        public void TestWordIsFound()
        {
            Word word = new Word("test");

            bool wordIsFound = word.WordIsFound();
            Assert.IsFalse(wordIsFound);

            string resultHiddenLetter = word.WriteTheLetter('t');
            wordIsFound = word.WordIsFound();
            Assert.IsFalse(wordIsFound);

            resultHiddenLetter = word.WriteTheLetter('e');
            wordIsFound = word.WordIsFound();
            Assert.IsFalse(wordIsFound);

            resultHiddenLetter = word.WriteTheLetter('s');
            wordIsFound = word.WordIsFound();
            Assert.IsTrue(wordIsFound);
        }

        [TestMethod]
        public void TestRevealLetter()
        {
            Word word = new Word("test");

            char revealedLetter = word.RevealLetter();
            Assert.AreEqual(revealedLetter, 't');

            string hiddenWord = word.GetHiddenWord();
            Assert.AreEqual(hiddenWord, "t _ _ t");
        }
    }
}
