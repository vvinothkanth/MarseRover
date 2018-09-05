//
//
//

namespace MarseMover
{
    using System;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class AlphaRover : RoverModel
    {
        /// <summary>
        /// Directions
        /// </summary>
        enum Direction
        {
            North = 'N',
            East = 'E',
            South = 'S',
            West = 'W'
        }

        /// <summary>
        /// Relative Directions
        /// </summary>
        enum RelativeDirection
        {
            Right = 'R',
            Left = 'L'
        }

        /// <summary>
        /// To perform the moving command 
        /// </summary>
        /// <param name="rover">rover</param>
        /// <param name="area">area</param>
        /// <returns>boolian value</returns>
        public override bool IsMoved(Rover rover, Area area)
        {
            bool isMove = false;
            try
            {
                if (Directions.ContainsKey(rover.direction))
                {
                    switch (char.ToUpper(rover.direction))
                    {
                        case (char)Direction.North:

                            rover.yPoint += 1;
                            if (rover.yPoint <= area.maxYPoint && !IsAnyRoverInThisPoint(area, rover))
                            {
                                isMove = true;
                            }
                            else
                            {
                                rover.yPoint -= 1;
                                Log.Write(rover.id + ". ) => :" + "boundary in upper Y value");
                            }
                            break;

                        case (char)Direction.East:

                            rover.xPoint += 1;
                            if (rover.xPoint <= area.maxXPoint && !IsAnyRoverInThisPoint(area, rover))
                            {
                                isMove = true;
                            }
                            else
                            {
                                rover.xPoint -= 1;
                                Log.Write(rover.id + ". ) => :" + "boundary in upper X value");
                            }

                            break;

                        case (char)Direction.South:

                            rover.yPoint -= 1;
                            if (rover.yPoint >= area.minYPoint && !IsAnyRoverInThisPoint(area, rover))
                            {
                                isMove = true;
                            }
                            else
                            {
                                rover.yPoint += 1;
                                Log.Write(rover.id + ". ) => :" + "boundary in Lower Y value");
                            }

                            break;

                        case (char)Direction.West:

                            rover.xPoint -= 1;
                            if (rover.xPoint >= area.minXPoint && !IsAnyRoverInThisPoint(area, rover))
                            {
                                isMove = true;
                            }
                            else
                            {
                                rover.xPoint += 1;
                                Log.Write(rover.id + ". ) => :" + "boundary in upper X value");
                            }
                            break;

                        default:
                            Log.Write(rover.id + ". ) => :" + "Unexpected Direction");
                            break;
                    }
                }
                else
                {
                    Log.Write(rover.id + ". ) => :" + "The given directin of rover does not exsist");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isMove;
        }

        /// <summary>
        /// To perform the given relative direction command
        /// </summary>
        /// <param name="rover">rover</param>
        /// <param name="relativeDirectionCommand">command</param>
        /// <returns>boolian</returns>
        public override bool IsTurned(Rover rover, char relativeDirectionCommand)
        {

            char currentDirection = rover.direction;
            bool isTurn = false;

            try
            {
                if (Directions.ContainsKey(currentDirection))
                {
                    switch (char.ToUpper(relativeDirectionCommand))
                    {
                        case (char)RelativeDirection.Left:

                            if (currentDirection == (char)Direction.North)
                            {
                                rover.direction = 'W';
                            }
                            else
                            {
                                rover.direction = (from entry in Directions where entry.Value == Directions[currentDirection] - 90 select entry.Key).ToArray()[0];
                            }

                            isTurn = true;

                            break;

                        case (char)RelativeDirection.Right:

                            if (currentDirection == (char)Direction.West)
                            {
                                rover.direction = 'N';
                            }
                            else
                            {
                                rover.direction = (from entry in Directions where entry.Value == Directions[currentDirection] + 90 select entry.Key).ToArray()[0];
                            }
                            isTurn = true;
                            break;

                        default:

                            Log.Write(rover.id + ". ) => :" + "Unexpected Rover Command");
                            break;
                    }

                }
                else
                {
                    Log.Write(rover.id + ". ) => :" + "The given directin of rover does not exsist");
                    throw new ArgumentException("Argument");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isTurn;
        }

        /// <summary>
        /// To perform the given command
        /// </summary>
        /// <param name="roverCommand">rover command as char value</param>
        /// <param name="rover">rover</param>
        /// <param name="area">area</param>
        /// <returns>boolian value </returns>
        public override bool IsCommandExecuted(char roverCommand, Rover rover, Area area)
        {
            bool isCommandExecuted = false;
            try
            {
                char command = char.ToUpper(roverCommand);
                if(command.Equals('M'))
                {
                    isCommandExecuted = IsMoved(rover, area);
                }
                else if(command.Equals('R') || command.Equals('L'))
                {
                    isCommandExecuted = IsTurned(rover, command);   
                }
                else
                {
                    Log.Write(rover.id + ". ) => :" + "command error");
                }

            }
            catch (Exception)
            {

                throw;
            }

            return isCommandExecuted;
        }

        /// <summary>
        /// To check more then one  rover have the same position
        /// </summary>
        /// <param name="area">area</param>
        /// <param name="rover">rover</param>
        /// <returns>boolian result</returns>
        public bool IsAnyRoverInThisPoint(Area area, Rover rover)
        {
            bool isRoverInThisPoint = false;
            try
            {
                // Get all rovers in one single area
                var listOfRovers = from areaWithRovers in areasWithRovers where areaWithRovers.area == area select areaWithRovers.rover;

                // formate the rover currrent position
                string expectedRoverPosition = string.Format(rover.xPoint.ToString() + rover.yPoint.ToString() + rover.direction.ToString());

                foreach (var roverInList in listOfRovers)
                {
                    string actualRoverPosition = string.Format(roverInList.xPoint.ToString() + roverInList.yPoint.ToString() + roverInList.direction.ToString());

                    if (expectedRoverPosition.Equals(actualRoverPosition) && roverInList.id != rover.id)
                    {
                        isRoverInThisPoint = true;
                        Log.Write(rover.id + ". ) => :" + " Another Rover in this place");
                        break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return isRoverInThisPoint;
        }
    }
}
