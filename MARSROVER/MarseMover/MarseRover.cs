//
//
//

namespace MarseMover
{
    using System;

    class MarseRover
    {
        enum Option
        {
            CreateRover = 1,
            CreateArea,
            AddRoverIntoArea,
            GiveCommand
        }

        static void Main(string[] args)
        {


            RoverModel alphaRover = new AlphaRover();

            while (true)
            {
                Console.WriteLine("1.) Create Rover");
                Console.WriteLine("2.) Create Area");
                Console.WriteLine("3.) Add Rover Into Area");
                Console.WriteLine("4.) Give Commands");
                int option = Convert.ToInt16(Console.ReadLine());

                switch (option)
                {
                    case (int)Option.CreateRover:
                        Console.WriteLine("Create New Rover  In Formate id,X Point,Y Point,Direction eg 101,2,3,E");
                        string rover = Convert.ToString(Console.ReadLine());
                        string[] roverValues = rover.Split(',');
                        int roverId = alphaRover.AddRover(Convert.ToInt16(roverValues[0]), Convert.ToInt16(roverValues[1]), Convert.ToInt16(roverValues[2]), Convert.ToChar(roverValues[3]));
                        Console.WriteLine("Rover Id :{0}  Index=>{1}", roverValues[0], roverId);
                        break;

                    case (int)Option.CreateArea:
                        Console.WriteLine("Create New Area in formate of id,minX,minY,maxX,maxY eg 101,0,0,5,5");
                        string area = Convert.ToString(Console.ReadLine());
                        string[] areaValues = area.Split(',');
                        int are = alphaRover.AddArea(Convert.ToInt16(areaValues[0]), Convert.ToInt16(areaValues[1]), Convert.ToInt16(areaValues[2]), Convert.ToInt16(areaValues[3]), Convert.ToInt16(areaValues[4]));
                        Console.WriteLine("Rover Id :{0}  Index=>{1}", areaValues[0], area);
                        break;

                    case (int)Option.AddRoverIntoArea:
                        Console.WriteLine("Add rover into area");
                        Console.WriteLine("Select Rover");

                        foreach (var getOneByOne in alphaRover.GetAllRovers())
                        {
                            Console.WriteLine("Press {0} To select Rover of id : {1}", getOneByOne.Key , getOneByOne.Value.id);
                        }

                        int roverIndex = Convert.ToInt16(Console.ReadLine());

                        foreach (var getOneByOne in alphaRover.GetAllAreas())
                        {
                            Console.WriteLine("Press {0} To select Area of id : {1}", getOneByOne.Key , getOneByOne.Value.id);
                        }

                        int areaIndex = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Area Index :{0}", alphaRover.AddRoverIntoArea(roverIndex, areaIndex));
                        break;

                    case (int)Option.GiveCommand:

                        Console.WriteLine("Give commands to rover\n-----------");

                        Console.WriteLine("Select Rover");

                        foreach (var getOneByOne in alphaRover.GetAllRovers())
                        {
                            Console.WriteLine("Press {0} To select Rover of id : {1}", getOneByOne.Key, getOneByOne.Value.id);
                        }
                        int roverKey = Convert.ToInt16(Console.ReadLine());

                        foreach (var getOneByOne in alphaRover.GetAllAreas())
                        {
                            Console.WriteLine("Press {0} To select Area of id : {1}", getOneByOne.Key, getOneByOne.Value.id);
                        }
                        int areaKey = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("Enter Commands L for Left R For Right M for move one step forword:");
                        string cmd = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Rover id {0} : Current Position => {1} ", alphaRover.GetRover(roverKey).id, alphaRover.GetRoverCurrentPosition(roverKey));

                        foreach (char command in cmd)
                        {
                            alphaRover.IsCommandExecuted(command, alphaRover.GetRover(roverKey), alphaRover.GetArea(areaKey));
                            Rover roo = alphaRover.GetRover(roverKey);
                            Console.WriteLine("{3} => ({0},{1},{2})", roo.xPoint, roo.yPoint, roo.direction, command);
                        }

                        string roverCurrent = alphaRover.GetRoverCurrentPosition(roverKey);
                        Console.WriteLine("Rover New Position : => {0}", roverCurrent);

                        break;
                    default:
                        Console.WriteLine("Wrong Option");
                        break;
                }

            }

        }
    }
}
