using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarceRover
{
    public class Plateau
    {
        public int Id { get; set; }

        public int MinimumXPoint { get; set; }

        public int MaximumXPoint { get; set; }

        public int MinimumYPoint { get; set; }

        public int MaximumYPoint { get; set; }

        public Dictionary<int, Rover> RoverCollection = new Dictionary<int, Rover>();

        public Plateau()
        {

        }
        public void SetPlateau(int id, int minXpoint, int minYPoint, int maxXPoint, int maxYPoint)
        {
            Id = id;
            MinimumXPoint = minXpoint;
            MaximumXPoint = maxXPoint;
            MinimumYPoint = minYPoint;
            MaximumYPoint = maxYPoint;
        }

        public Dictionary<int, Rover> GetAllRoversInPlateau()
        {
            return RoverCollection;
        }

        public int AddRoverIntoPlateau(Rover rover)
        {
            int roverKey = RoverCollection.Count + 1;
            RoverCollection.Add(roverKey, rover);
            return roverKey;
        }

        public Rover GetRover(int key)
        {
            return RoverCollection[key];
        }

        public bool IsNotBoundaryPoint(int[] points, Plateau plateau)
        {

            return points[0] > plateau.MinimumXPoint && points[0] < plateau.MaximumXPoint && points[1] > plateau.MinimumYPoint && points[1] < plateau.MaximumYPoint ? true : false;
        }

        public bool IsAnyRoverInThisPoint(int[] points, Plateau plateau)
        {
            bool isRoverInThisPoint;
            try
            {
                isRoverInThisPoint = ((from roverCollection in plateau.RoverCollection where points[0] == roverCollection.Value.XPoint && points[1] == roverCollection.Value.XPoint && points[2] == roverCollection.Value.Id select roverCollection.Value.Id).ToList<int>().Count) != 0 ? true : false;
            }
            catch (Exception)
            {
                
                throw;
            }
            return isRoverInThisPoint;
        }

        public bool IsAnyRoverInThisPoint(Rover rover, Plateau plateau)
        {
            bool isRoverInThisPoint = false;
            try
            {
                isRoverInThisPoint = ((from getRover in plateau.RoverCollection where getRover.Value.Id != rover.Id && getRover.Value.GetCurrentPosition() != rover.GetCurrentPosition() select getRover.Value.Id).ToList<int>().Count) != 0 ? true : false;    
            }
            catch (Exception)
            {

                throw;
            }

            return isRoverInThisPoint;
        }

    }
}
