using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarceRover
{

    public class Rover
    {
        public int Id { get; set; }

        public int XPoint { get; set; }

        public int YPoint { get; set; }

        public char DirectionKey { get; set; }

        public Rover()
        {

        }
        public void SetRover(int id, int xPoint, int yPoint, char direction)
        {
            Id = id;
            XPoint = xPoint;
            YPoint = yPoint;
            DirectionKey = char.ToUpper(direction);
        }

        public string GetCurrentPosition()
        {
            return string.Format("{0} {1} {2}", XPoint, YPoint, DirectionKey);
        }

        public void ResetXPoint(int point)
        {
            XPoint = point;
        }

        public void ResetYPoint(int point)
        {
            YPoint = point;
        }

        public void ResetDirection(char direction)
        {
            DirectionKey = direction;
        }

        public char GetNextDirection(char currentDirection, char command)
        {
            char nextDirection = ' ';

            if (char.ToUpper(command) == (char)RelativeDirection.Left)
            {
                nextDirection = Direction.GetNextDirectionFromLeft(currentDirection);
            }
            else if (char.ToUpper(command) == (char)RelativeDirection.Right)
            {
                nextDirection = Direction.GetNextDirectionFromRight(currentDirection);
            }
            else
            {
                throw new ArgumentException("The command only contain L and R");
            }

            return nextDirection;
        }

        public int[] GetNextPoint(int xPoint, int yPoint, char currentDirection, int step)
        {
            int[] nextPoint = new int[2] { xPoint , yPoint };

            switch (char.ToUpper(currentDirection))
            {
                case (char)CommanDirection.East:
                    nextPoint[0] = Point.Increament(xPoint, step);
                    break;

                case (char)CommanDirection.West:
                    nextPoint[0] = Point.Decrement(xPoint, step);
                    break;

                case (char)CommanDirection.North:
                    nextPoint[1] = Point.Increament(yPoint, step);
                    break;

                case (char)CommanDirection.South:
                    nextPoint[1] = Point.Decrement(yPoint, step);
                    break;

                default:

                    throw new ArgumentException("The direction key not in exsist");
                    
            }

            return nextPoint;
        }
        
    }

}
