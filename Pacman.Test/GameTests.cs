using NUnit.Framework;
using Pacman;
using System;
using System.IO;
using System.Text;

namespace Pacman.Test
{
    public class GameTests
    {
        private StringBuilder output;

        private string GetTestFile(string testData)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BoardPositions", testData);
            return File.ReadAllText(path);
        }

        [SetUp]
        public void Setup()
        {
            output = new StringBuilder();
            var outputWriter = new StringWriter(output);

            Console.SetOut(outputWriter);
        }

        [Test]
        public void GameSetupTest()
        {
            // Arrange
            var game = new Game();

            // Act
            game.Display();


            // Assert
            var expectedOutput = GetTestFile("SetupBoard.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }
    }
}