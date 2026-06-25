using NUnit.Framework;
using OTS2026_PT1_GrupaA.Exceptions;
using OTS2026_PT1_GrupaA.Models;
using System;
using static OTS2026_PT1_GrupaA.Game;

namespace OTS2026_PT1_GrupaA.Test
{
    [TestFixture]
    public class GameTest
    {
        [TestCaseSource(typeof(IncomeParser), "GetTestCaseDatas", new object[] { "PICT_Rezultati.txt" })]
        public void CalculateIncome_SuccessCalculate(int amountOfFish, int amountOfBait, bool hasBoat, string score) 
        {
            //ARRANGE
            Game game = new Game(new Position(0, 0), new Position(30, 30));
            game.Player.AmountOfFish = amountOfFish;
            game.Player.AmountOfBait = amountOfBait;
            game.Player.HasBoat = hasBoat;

            //ACT
            Score gameScore = game.CalculateIncome();

            //ASSERT
            Assert.That(gameScore.ToString(), Is.EqualTo(score));
        }

        [Test]
        public void Exception_1() 
        {
            //ARRANGE
            Position po1 = new Position(0, 0);
            Position po2 = new Position(10, 10);
            

            Game g = new Game(po1, po2);

            g.Map.Fields[po1.X, po1.Y].Zone = Zone.Invalid;
            g.Map.Fields[po2.X, po2.Y].Zone = Zone.Invalid;

            //ACT
            Exception e1 = Assert.Throws<InvalidPlayerPositionException>((TestDelegate)(() => new Game(po1, po2)));

            //ASSERT
            Assert.That(e1.Message, Is.EqualTo("Player and boat must be in the Land zone!"));
        }

        [Test]
        public void Move_Player_Method() 
        {
            //ARRANGE
            Position p1 = new Position(10, 10);
            Position p2 = new Position(15, 15);
            Game game = new Game(p1, p2);

            //ACT
        //    game.Player.Move = Move.Up;

            //ASSERT
       //     Assert.That(game.MovePlayer(Move.Up), Is.EqualTo("U"));

        }

        [Test]
        public void Validate_Position_Method()
        {
            //ARRANGE
            Position p = new Position(0, 0);
            Game g = new Game(null, null);

            //ACT
            bool l = g.ValidatePosition(null);

            //ASSERT
            Assert.That(l, Is.EqualTo(false));
        }

        [Test]
        public void Validate_Position()
        {
            //ARRANGE
            Position p = new Position(10, 13);
            Position p2 = new Position(0, 0);
            Game g = new Game(p, p2);

            //ACT
            

            //ASSERT
        }

    }
}
