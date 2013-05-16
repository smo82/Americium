using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanGameTest
{
    [TestClass]
    public class TopPlayerTest
    {
        [TestMethod]
        public void TestTopPlayerCreation()
        {
            TopPlayer topPlayer = new TopPlayer("Player1",10);

            string playerName = topPlayer.PlayerName;
            Assert.AreEqual(playerName, "Player1");

            int playerScore = topPlayer.PlayerScore;
            Assert.AreEqual(playerScore, 10);
        }
    }
}
