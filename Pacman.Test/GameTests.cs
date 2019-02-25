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
        public void SetupBoard()
        {
            // Arrange
            var game = new Game();

            // Act
            game.Display();


            // Assert
            var expectedOutput = GetTestFile("SetupBoard.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void PacmanMovingRightNoWall()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(5, 5);
            game.Pacman.Direction = Direction.Right;

            // Act
            game.Tick();
            game.Display();

            // Assert
            Assert.AreEqual(game.Pacman.Direction, Direction.Right);
            Assert.AreEqual(6, game.Pacman.Position.X);
            Assert.AreEqual(5, game.Pacman.Position.Y);

            var expectedOutput = GetTestFile("PacmanMovingRightNoWall.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void PacmanMovingLeftNoWall()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(5, 5);
            game.Pacman.Direction = Direction.Left;

            // Act
            game.Tick();
            game.Display();

            // Assert
            Assert.AreEqual(game.Pacman.Direction, Direction.Left);
            Assert.AreEqual(4, game.Pacman.Position.X);
            Assert.AreEqual(5, game.Pacman.Position.Y);

            var expectedOutput = GetTestFile("PacmanMovingLeftNoWall.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void PacmanMovingUpNoWall()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(5, 5);
            game.Pacman.Direction = Direction.Up;

            // Act
            game.Tick();
            game.Display();

            // Assert
            Assert.AreEqual(game.Pacman.Direction, Direction.Up);
            Assert.AreEqual(5, game.Pacman.Position.X);
            Assert.AreEqual(4, game.Pacman.Position.Y);

            var expectedOutput = GetTestFile("PacmanMovingUpNoWall.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void PacmanMovingDownNoWall()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(5, 5);
            game.Pacman.Direction = Direction.Down;

            // Act
            game.Tick();
            game.Display();

            // Assert
            Assert.AreEqual(game.Pacman.Direction, Direction.Down);
            Assert.AreEqual(5, game.Pacman.Position.X);
            Assert.AreEqual(6, game.Pacman.Position.Y);

            var expectedOutput = GetTestFile("PacmanMovingDownNoWall.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }


        [Test]
        public void PacmanMovingRightAWall()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(9, 5);
            game.Pacman.Direction = Direction.Right;

            // Act
            game.Tick();
            game.Display();

            // Assert
            Assert.AreEqual(game.Pacman.Direction, Direction.Right);
            Assert.AreEqual(9, game.Pacman.Position.X);
            Assert.AreEqual(5, game.Pacman.Position.Y);

            var expectedOutput = GetTestFile("PacmanMovingRightAWall.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void PacmanMovingLeftAWall()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(0, 5);
            game.Pacman.Direction = Direction.Left;

            // Act
            game.Tick();
            game.Display();

            // Assert
            Assert.AreEqual(game.Pacman.Direction, Direction.Left);
            Assert.AreEqual(0, game.Pacman.Position.X);
            Assert.AreEqual(5, game.Pacman.Position.Y);

            var expectedOutput = GetTestFile("PacmanMovingLeftAWall.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void PacmanMovingUpAWall()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(5, 0);
            game.Pacman.Direction = Direction.Up;

            // Act
            game.Tick();
            game.Display();

            // Assert
            Assert.AreEqual(game.Pacman.Direction, Direction.Up);
            Assert.AreEqual(5, game.Pacman.Position.X);
            Assert.AreEqual(0, game.Pacman.Position.Y);

            var expectedOutput = GetTestFile("PacmanMovingUpAWall.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void PacmanMovingDownAWall()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(5, 9);
            game.Pacman.Direction = Direction.Down;

            // Act
            game.Tick();
            game.Display();

            // Assert
            Assert.AreEqual(game.Pacman.Direction, Direction.Down);
            Assert.AreEqual(5, game.Pacman.Position.X);
            Assert.AreEqual(9, game.Pacman.Position.Y);

            var expectedOutput = GetTestFile("PacmanMovingDownAWall.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void CollectCoin()
        {
            // Arrange
            var game = new Game();
            game.Pacman.Position = new Position(5, 5);
            game.Pacman.Direction = Direction.Right;

            foreach (var field in game.Fields)
            {
                field.HasCoin = true;
            }

            game.Fields[5, 5].HasCoin = false;
            
            // Act
            game.Tick();
            game.Display();
            
            // Arrange
            var expectedOutput = GetTestFile("PacmanCollectsCoin.txt");
            Assert.AreEqual(expectedOutput, output.ToString());
        }
    }
}