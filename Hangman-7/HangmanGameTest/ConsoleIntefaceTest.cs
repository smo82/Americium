namespace HangmanGameTest
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleIntefaceTest
    {
        [TestMethod]
        public void TestSingleLetterEvent()
        {
            bool isTriggered = false;
            IUserInterface consoleInterface = new ConsoleInterface();
            consoleInterface.SingleLetterEntered += (sender, eventInfo) =>
                {
                    isTriggered = true;
                };

            Word currentWord = new Word("test");
            WordData currentWordDate = new WordData(currentWord);

            string inputString = string.Format("a{0}", Environment.NewLine);
            using (StringReader sr = new StringReader(inputString))
            {
                Console.SetIn(sr);

                consoleInterface.GetUserInput(currentWordDate);
            }

            Assert.IsTrue(isTriggered);
        }

        [TestMethod]
        public void TestHelpRequestEvent()
        {
            bool isTriggered = false;
            IUserInterface consoleInterface = new ConsoleInterface();
            consoleInterface.HelpRequest += (sender, eventInfo) =>
            {
                isTriggered = true;
            };

            Word currentWord = new Word("test");
            WordData currentWordDate = new WordData(currentWord);

            string inputString = string.Format("help{0}", Environment.NewLine);
            using (StringReader sr = new StringReader(inputString))
            {
                Console.SetIn(sr);

                consoleInterface.GetUserInput(currentWordDate);
            }

            Assert.IsTrue(isTriggered);
        }

        [TestMethod]
        public void TestHighscoreRequestEvent()
        {
            bool isTriggered = false;
            IUserInterface consoleInterface = new ConsoleInterface();
            consoleInterface.HighscoreRequest += (sender, eventInfo) =>
            {
                isTriggered = true;
            };

            Word currentWord = new Word("test");
            WordData currentWordDate = new WordData(currentWord);

            string inputString = string.Format("highscore{0}", Environment.NewLine);
            using (StringReader sr = new StringReader(inputString))
            {
                Console.SetIn(sr);

                consoleInterface.GetUserInput(currentWordDate);
            }

            Assert.IsTrue(isTriggered);
        }

        [TestMethod]
        public void TestGameRestartEvent()
        {
            bool isTriggered = false;
            IUserInterface consoleInterface = new ConsoleInterface();
            consoleInterface.GameRestart += (sender, eventInfo) =>
            {
                isTriggered = true;
            };

            Word currentWord = new Word("test");
            WordData currentWordDate = new WordData(currentWord);

            string inputString = string.Format("restart{0}", Environment.NewLine);
            using (StringReader sr = new StringReader(inputString))
            {
                Console.SetIn(sr);

                consoleInterface.GetUserInput(currentWordDate);
            }

            Assert.IsTrue(isTriggered);
        }

        [TestMethod]
        public void TestGameExitEvent()
        {
            bool isTriggered = false;
            IUserInterface consoleInterface = new ConsoleInterface();
            consoleInterface.GameExit += (sender, eventInfo) =>
            {
                isTriggered = true;
            };

            Word currentWord = new Word("test");
            WordData currentWordDate = new WordData(currentWord);

            string inputString = string.Format("exit{0}", Environment.NewLine);
            using (StringReader sr = new StringReader(inputString))
            {
                Console.SetIn(sr);

                consoleInterface.GetUserInput(currentWordDate);
            }

            Assert.IsTrue(isTriggered);
        }

        [TestMethod]
        public void TestIncorrectInputEvent()
        {
            bool isTriggered = false;
            IUserInterface consoleInterface = new ConsoleInterface();
            consoleInterface.IncorrectInput += (sender, eventInfo) =>
            {
                isTriggered = true;
            };

            Word currentWord = new Word("test");
            WordData currentWordDate = new WordData(currentWord);

            string inputString = string.Format("12313{0}", Environment.NewLine);
            using (StringReader sr = new StringReader(inputString))
            {
                Console.SetIn(sr);

                consoleInterface.GetUserInput(currentWordDate);
            }

            Assert.IsTrue(isTriggered);
        }

        [TestMethod]
        public void TestIncorrectInputEventEmptyString()
        {
            bool isTriggered = false;
            IUserInterface consoleInterface = new ConsoleInterface();
            consoleInterface.IncorrectInput += (sender, eventInfo) =>
            {
                isTriggered = true;
            };

            Word currentWord = new Word("test");
            WordData currentWordDate = new WordData(currentWord);

            string inputString = string.Format("{0}", Environment.NewLine);
            using (StringReader sr = new StringReader(inputString))
            {
                Console.SetIn(sr);

                consoleInterface.GetUserInput(currentWordDate);
            }

            Assert.IsTrue(isTriggered);
        }
    }
}
