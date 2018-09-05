//
//
//


namespace MarseMover
{
    public class Rover
    {
        public int id;
        public int xPoint;
        public int yPoint;
        public char direction;

        public Rover(int id, int xPoint, int yPoint, char direction)
        {
            this.id = id;
            this.xPoint = xPoint;
            this.yPoint = yPoint;
            this.direction = direction;
        }
    }


    public class Area
    {
        public int id;
        public int minXPoint;
        public int maxXPoint;
        public int minYPoint;
        public int maxYPoint;

        public Area(int id, int minXPoint, int minYPoint,int maxXPoint, int maxYPoint)
        {
            this.id = id;
            this.minXPoint = minXPoint;
            this.minYPoint = minXPoint;
            this.maxXPoint = maxXPoint;
            this.maxYPoint = maxYPoint;
        }
    }

    public class AreaWithRover
    {
        public Rover rover;
        public Area area;

        public AreaWithRover(Rover rover, Area area)
        {
            this.rover = rover;
            this.area = area;
        }
    }

}
