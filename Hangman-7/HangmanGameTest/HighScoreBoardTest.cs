using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTest
{
    [TestClass]
    public class HighScoreBoardTest
    {
        [TestMethod]
        public void AddPlayerTest1Players()
        {
            TopPlayer player1 = new TopPlayer("Vasil", 5);
            
            HighScoreBoard highScoreBoard = new HighScoreBoard();
            highScoreBoard.AddPlayer(player1);
            Assert.AreEqual(player1, highScoreBoard.HighScores[0]);
        }

        [TestMethod]
        public void AddPlayerTest3Players()
        {
            TopPlayer player1 = new TopPlayer("Vasil", 5);
            TopPlayer player2 = new TopPlayer("Pesho", 1);
            TopPlayer player3 = new TopPlayer("Vesko", 4);
            HighScoreBoard highScoreBoard = new HighScoreBoard();
            highScoreBoard.AddPlayer(player1);
            highScoreBoard.AddPlayer(player2);
            highScoreBoard.AddPlayer(player3);
            Assert.AreEqual(player2, highScoreBoard.HighScores[0]);
            Assert.AreEqual(player3, highScoreBoard.HighScores[1]);
            Assert.AreEqual(player1, highScoreBoard.HighScores[2]);
        }

        [TestMethod]
        public void AddPlayerTest7Players()
        {
            TopPlayer player1 = new TopPlayer("Vasil", 5);
            TopPlayer player2 = new TopPlayer("Pesho", 1);
            TopPlayer player3 = new TopPlayer("Vesko", 4);
            TopPlayer player4 = new TopPlayer("Nasko", 2);
            TopPlayer player5 = new TopPlayer("Nasko", 8);
            TopPlayer player6 = new TopPlayer("Nasko", 7);
            TopPlayer player7 = new TopPlayer("Nasko", 0);
            HighScoreBoard highScoreBoard = new HighScoreBoard();
            highScoreBoard.AddPlayer(player1);
            highScoreBoard.AddPlayer(player2);
            highScoreBoard.AddPlayer(player3);
            highScoreBoard.AddPlayer(player4);
            highScoreBoard.AddPlayer(player5);
            highScoreBoard.AddPlayer(player6);
            highScoreBoard.AddPlayer(player7);

            Assert.AreEqual(player7, highScoreBoard.HighScores[0]);
            Assert.AreEqual(player2, highScoreBoard.HighScores[1]);
            Assert.AreEqual(player4, highScoreBoard.HighScores[2]);
            Assert.AreEqual(player3, highScoreBoard.HighScores[3]);
            Assert.AreEqual(player1, highScoreBoard.HighScores[4]);
        }
    }
}
