using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarceRover
{
    enum Degree
    {
        N = 0,
        E = 90,
        S = 180,
        W = 270
    }

    enum CommanDirection
    {
        North = 'N',
        East = 'E',
        West = 'W',
        South = 'S'
    }

    enum RelativeDirection
    {
        Left = 'L',
        Right = 'R'
    }

    public class Direction
    {
        public static char ToName(int degree)
        {
            char key = ' ';
            switch (degree)
            {
                case (int)Degree.N:
                    key = Degree.N.ToString().ToCharArray()[0];
                    break;

                case (int)Degree.E:
                    key = Degree.E.ToString().ToCharArray()[0];
                    break;

                case (int)Degree.S:
                    key = Degree.S.ToString().ToCharArray()[0];
                    break;

                case (int)Degree.W:
                    key = Degree.W.ToString().ToCharArray()[0];
                    break;

                default:
                    throw new Exception("Degree Contains only 0,90,180 and 270");
                    break;
            }

            return key;
        }

        public static int ToDegree(char key)
        {
            int degree = 0;
            switch (char.ToUpper(key))
            {
                case (char)CommanDirection.North:
                    degree = (int)Degree.N;
                    break;

                case (char)CommanDirection.East:
                    degree = (int)Degree.E;
                    break;

                case (char)CommanDirection.South:
                    degree = (int)Degree.S;
                    break;

                case (char)CommanDirection.West:
                    degree = (int)Degree.W;
                    break;

                default:
                    throw new Exception("Degree Contains only E,W,N and S");
                    break;
            }

            return degree;
        }

        public static char GetNextDirectionFromLeft(char direction)
        {
            char key= char.ToUpper(direction);
            char nextDegree = ' ';
            if (key == (char)CommanDirection.East || key == (char)CommanDirection.West || key == (char)CommanDirection.South)
            {
                nextDegree = ToName(ToDegree(direction) - 90);
            }
            else if (key == (char)CommanDirection.North)
            {
                nextDegree = 'W';
            }
            else
            {
                throw new Exception("Degree Contains only 0,90,180 and 270");
            }

            return nextDegree;
            
        }

        public static char GetNextDirectionFromRight(char direction)
        {
            char key = char.ToUpper(direction);
            char nextDegree = ' ';
            if (key == (char)CommanDirection.East || key == (char)CommanDirection.North || key == (char)CommanDirection.South)
            {
                nextDegree = ToName(ToDegree(direction) + 90);
            }
            else if (key == (char)CommanDirection.West)
            {
                nextDegree = 'N';
            }
            else
            {
                throw new Exception("Degree Contains only 0,90,180 and 270");
            }

            return nextDegree;

        }

        
    }
}
