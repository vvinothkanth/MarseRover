//
//
//

namespace MarseMover
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// 
    /// </summary>
    public abstract class RoverModel : IRoverActivity
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<char, int> Directions = new Dictionary<char, int>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<char, string> RelativeDirections = new Dictionary<char, string>();

        public RoverModel()
        {
            Directions.Add('N', 0);
            Directions.Add('E', 90);
            Directions.Add('S', 180);
            Directions.Add('W', 270);
            RelativeDirections.Add('R', "Right");
            RelativeDirections.Add('L', "Left");

        }


        //
        protected Dictionary<int, Area> areas = new Dictionary<int, Area>();

        //
        protected Dictionary<int, Rover> rovers = new Dictionary<int, Rover>();

        //
        protected List<AreaWithRover> areasWithRovers = new List<AreaWithRover>();

        public abstract bool IsMoved(Rover rover, Area area);

        public abstract bool IsTurned(Rover rover, char relativeDirectionCommand);

        public abstract bool IsCommandExecuted(char roverCommand, Rover rover, Area area);


        public int AddRover(int roverCode ,int xPoint, int yPoint, char direction)
        {
            rovers.Add(rovers.Count + 1, new Rover(roverCode, xPoint, yPoint, char.ToUpper(direction)));
            return rovers.Count;
        }

        public int AddArea(int areaCode, int minXPoint, int minYPoint, int maxXPoint, int maxYPoint)
        {
            areas.Add(areas.Count + 1, new Area(areaCode, minXPoint, minYPoint, maxXPoint, maxYPoint));
            return areas.Count;
        }

        public int AddRoverIntoArea(int roverId, int areaId)
        {
            areasWithRovers.Add(new AreaWithRover(GetRover(roverId), GetArea(areaId)));
            return areasWithRovers.Count;
            
        }

        public Rover GetRover(int roverId)
        {
            Rover rover = null;
            try
            {
                if (rovers.ContainsKey(roverId))
                {
                    rover = rovers[roverId];
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rover;
        }

        public Area GetArea(int areaId)
        {
            Area area = null;
            try
            {
                area = areas[areaId];
            }
            catch (Exception)
            {

                throw;
            }

            return area;
            
        }

        public string GetRoverCurrentPosition(int roverId)
        {
            string roverCurrentPosition = string.Empty;
            try
            {
                if (rovers.ContainsKey(roverId))
                {
                    roverCurrentPosition = string.Format("({0},{1},{2})", GetRover(roverId).xPoint, GetRover(roverId).yPoint, GetRover(roverId).direction);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return roverCurrentPosition;
        }

        public Dictionary<int, Rover> GetAllRovers()
        {
            return rovers;
        }

        public Dictionary<int, Area> GetAllAreas()
        {
            return areas;
        }
    }
}
