using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarseMover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarseMover.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass()]
    public class AlphaRoverTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void IsTurnedTest()
        {
            RoverModel rover = null;
            rover = new AlphaRover();

            int roverOne = rover.AddRover(101, 2, 3, 'e');
            int areaOne = rover.AddArea(102, 0, 0, 5, 5);

            int roverFromNorth = rover.AddRover(102, 4, 4,'N');

            int roverTrunFromWest = rover.AddRover(103, 5, 5, 'W');

            int areaIntoRover = rover.AddRoverIntoArea(roverOne, areaOne);


            bool isTurneLeft = rover.IsTurned(rover.GetRover(roverOne),'L');
            bool isAnyUnexpectedChar = rover.IsTurned(rover.GetRover(roverOne), 'M');
            bool isTurneRight = rover.IsTurned(rover.GetRover(roverOne), 'R');
            bool isTurnedFromNorth = rover.IsTurned(rover.GetRover(roverFromNorth), 'l');
            bool isContainAnySpecialChar = rover.IsTurned(rover.GetRover(roverFromNorth), ',');
            bool isContainAnyNumber = rover.IsTurned(rover.GetRover(roverFromNorth), '1');
            bool isTurnedFromWest = rover.IsTurned(rover.GetRover(roverTrunFromWest), 'r');

            Assert.IsTrue(isTurneLeft);
            Assert.IsTrue(isTurneRight);
            Assert.IsTrue(isTurnedFromNorth);
            Assert.IsTrue(isTurnedFromWest);
            Assert.IsFalse(isAnyUnexpectedChar);
            Assert.IsFalse(isContainAnySpecialChar);
            Assert.IsFalse(isContainAnyNumber);

        }

        [TestMethod()]
        public void IsMovesTest()
        {
            RoverModel rover = null;
            rover = new AlphaRover();

            // Create Rovers
            int roverFromEast = rover.AddRover(101, 2, 3, 'E');
            int roverFromNorth = rover.AddRover(102, 2, 3, 'n');
            int roverFromWest = rover.AddRover(103, 5, 5, 'W');
            int roverFromSouth = rover.AddRover(104, 3, 4, 's');

            // check into boundary rovers
            int west = rover.AddRover(105, 0, 4, 'w');
            int south = rover.AddRover(106, 4, 0, 's');
            int areaOne = rover.AddArea(107, 0, 0, 5, 5);
            int boundaryArea = rover.AddArea(108, 0, 0, 1, 1);

            // check in pointed to another rover
            int checkAnotherRoverIntoEast = rover.AddRover(109, 2, 3, 'E');
            int checkAnotherroverIntoNorth = rover.AddRover(110, 2, 3, 'n');
            int checkAnotherroverIntoWest = rover.AddRover(111, 5, 5, 'W');
            int checkAnotherroverIntoSouth = rover.AddRover(110, 3, 4, 's');

            int isUnexpectedCommand = rover.AddRover(110, 3, 3, 'G');

            // add rover into areaOne location
            rover.AddRoverIntoArea(roverFromEast,areaOne);
            rover.AddRoverIntoArea(roverFromNorth, areaOne);
            rover.AddRoverIntoArea(roverFromSouth, areaOne);
            rover.AddRoverIntoArea(roverFromWest, areaOne);
            rover.AddRoverIntoArea(checkAnotherRoverIntoEast, areaOne);
            rover.AddRoverIntoArea(checkAnotherroverIntoNorth, areaOne);
            rover.AddRoverIntoArea(checkAnotherroverIntoWest, areaOne);
            rover.AddRoverIntoArea(checkAnotherroverIntoSouth, areaOne);

            // check successive movement
            bool isMoveFromEast = rover.IsMoved(rover.GetRover(roverFromEast), rover.GetArea(areaOne));
            bool isMoveFromWest = rover.IsMoved(rover.GetRover(roverFromWest), rover.GetArea(areaOne));
            bool isMoveFromNorth = rover.IsMoved(rover.GetRover(roverFromNorth), rover.GetArea(areaOne));
            bool isMoveFromsouth = rover.IsMoved(rover.GetRover(roverFromSouth), rover.GetArea(areaOne));

            //check boundary value
            bool isBoundaryInEast = rover.IsMoved(rover.GetRover(roverFromEast), rover.GetArea(boundaryArea));
            bool isBoundaryInNorth = rover.IsMoved(rover.GetRover(roverFromNorth), rover.GetArea(boundaryArea));
            bool isBoundaryInWest = rover.IsMoved(rover.GetRover(west), rover.GetArea(boundaryArea));
            bool isBoundaryInsouth = rover.IsMoved(rover.GetRover(south), rover.GetArea(boundaryArea));

            // check another rover in this point
            bool checkEast = rover.IsMoved(rover.GetRover(checkAnotherRoverIntoEast), rover.GetArea(areaOne));
            bool checkNorth = rover.IsMoved(rover.GetRover(checkAnotherroverIntoNorth), rover.GetArea(areaOne));
            bool checkWest = rover.IsMoved(rover.GetRover(checkAnotherroverIntoWest), rover.GetArea(areaOne));
            bool checkSouth = rover.IsMoved(rover.GetRover(checkAnotherroverIntoSouth), rover.GetArea(areaOne));

            // check unexpected char
            bool checkUnexpectCommand = rover.IsMoved(rover.GetRover(isUnexpectedCommand), rover.GetArea(areaOne));

            Assert.IsTrue(isMoveFromEast);
            Assert.IsTrue(isMoveFromWest);
            Assert.IsTrue(isMoveFromNorth);
            Assert.IsTrue(isMoveFromsouth);

            Assert.IsFalse(isBoundaryInEast);
            Assert.IsFalse(isBoundaryInNorth);
            Assert.IsFalse(isBoundaryInsouth);
            Assert.IsFalse(isBoundaryInWest);

            Assert.IsFalse(checkEast);
            Assert.IsFalse(checkNorth);
            Assert.IsFalse(checkWest);
            Assert.IsFalse(checkSouth);

            Assert.IsFalse(checkUnexpectCommand);

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void IsCommandTest()
        {
            RoverModel rover = null;
            rover = new AlphaRover();

            int roverOne = rover.AddRover(101, 2, 3, 'e');
            int areaOne = rover.AddArea(102, 0, 0, 5, 5);
            int roverFromNorth = rover.AddRover(102, 4, 4, 'N');
            int roverTrunFromWest = rover.AddRover(103, 5, 5, 'W');
            int areaIntoRoverOne = rover.AddRoverIntoArea(roverOne, areaOne);
            int areaIntoRoverTwo = rover.AddRoverIntoArea(roverFromNorth, areaOne);
            int areaIntoRoverThree = rover.AddRoverIntoArea(roverTrunFromWest, areaOne);
            int areaIntoRoverFour = rover.AddRoverIntoArea(roverOne, areaOne);
            int areaIntoRoverFive = rover.AddRoverIntoArea(roverOne, areaOne);

            // Check successfull commands
            bool turnLeft = rover.IsCommandExecuted('L', rover.GetRover(roverOne), rover.GetArea(areaOne));
            bool turnRight = rover.IsCommandExecuted('r', rover.GetRover(roverOne), rover.GetArea(areaOne));
            bool move = rover.IsCommandExecuted('M', rover.GetRover(roverOne), rover.GetArea(areaOne));
            bool moveOne = rover.IsCommandExecuted('m', rover.GetRover(roverOne), rover.GetArea(areaOne));
            bool isTurneLeft = rover.IsCommandExecuted('l', rover.GetRover(roverOne), rover.GetArea(areaOne));

            // check failiour commands
            bool unexpectedCommandOne = rover.IsCommandExecuted('h', rover.GetRover(roverOne), rover.GetArea(areaOne));
            bool unexpectedCommandTwo = rover.IsCommandExecuted(',', rover.GetRover(roverOne), rover.GetArea(areaOne));
            bool unexpectedCommandThree = rover.IsCommandExecuted('+', rover.GetRover(roverOne), rover.GetArea(areaOne));

            Assert.IsTrue(isTurneLeft);
            Assert.IsTrue(turnLeft);
            Assert.IsTrue(turnRight);
            Assert.IsTrue(move);
            Assert.IsTrue(moveOne);

            Assert.IsFalse(unexpectedCommandOne);
            Assert.IsFalse(unexpectedCommandTwo);
            Assert.IsFalse(unexpectedCommandThree);

        }
    }
}