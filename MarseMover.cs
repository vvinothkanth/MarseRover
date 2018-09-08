using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarceRover
{
    class MarseMover
    {
        enum Option
        {
            CreateRover = 1,
            CreateArea,
            GiveCommand
        }

        enum Action
        {
            Left = 'L',
            Right = 'R',
            Move = 'M'
        }
        static void Main(string[] args)
        {


            Dictionary<int, Rover> listOfRover = new Dictionary<int, Rover>();
            Dictionary<int, Plateau> listOfPlataeu = new Dictionary<int, Plateau>();


            while (true)
            {
                Console.WriteLine("1.) Create Rover");
                Console.WriteLine("2.) Create Area");
                Console.WriteLine("3.) Give Commands");
                int option = Convert.ToInt16(Console.ReadLine());

                switch (option)
                {
                    case (int)Option.CreateRover:
                        Console.WriteLine("select Area:");
                        foreach (var plateau in listOfPlataeu)
                        {
                            Console.WriteLine("Press {0} To select Area of id : {1}", plateau.Key, plateau.Value.Id);
                        }
                        int platInx = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("Create New Rover  In Formate id,X Point,Y Point,Direction eg 101,2,3,E");
                        string roverData = Convert.ToString(Console.ReadLine());
                        string[] roverValues = roverData.Split(',');
                        Rover beetaRover = new Rover();
                        beetaRover.SetRover(Convert.ToInt16(roverValues[0]), Convert.ToInt16(roverValues[1]), Convert.ToInt16(roverValues[2]), Convert.ToChar(roverValues[3]));
                        //listOfRover.Add(listOfRover.Count + 1, beetaRover);

                        Console.WriteLine("Rover Id :{0}  Index=>{1}", beetaRover.Id, listOfRover.Count);

                        bool isAnyRoverInArea = listOfPlataeu[platInx].IsAnyRoverInThisPoint(new int[] { beetaRover.XPoint, beetaRover.YPoint }, listOfPlataeu[platInx].RoverCollection);

                        if (!isAnyRoverInArea)
                        {
                            int index = listOfPlataeu[platInx].AddRoverIntoPlateau(beetaRover);
                            Console.WriteLine("Area Index :{0}", index);
                        }
                        else
                        {
                            Console.WriteLine("Anothr Rover in this point");
                        }

                        break;

                    case (int)Option.CreateArea:
                        Console.WriteLine("Create New Area in formate of id,minX,minY,maxX,maxY eg 101,0,0,5,5");
                        string areaValue = Convert.ToString(Console.ReadLine());
                        string[] areaValues = areaValue.Split(',');
                        Plateau plateauOne = new Plateau();
                        plateauOne.SetPlateau(Convert.ToInt16(areaValues[0]), Convert.ToInt16(areaValues[1]), Convert.ToInt16(areaValues[2]), Convert.ToInt16(areaValues[3]), Convert.ToInt16(areaValues[4]));
                        listOfPlataeu.Add(listOfPlataeu.Count + 1, plateauOne);
                        Console.WriteLine("Plateau Id :{0}  Index=>{1}", plateauOne.Id, listOfPlataeu.Count);
                        break;


                    case (int)Option.GiveCommand:

                        Console.WriteLine("Give commands to rover\n-----------");

                        Console.WriteLine("select Area:");
                        foreach (var plateau in listOfPlataeu)
                        {
                            Console.WriteLine("Press {0} To select Area of id : {1}", plateau.Key, plateau.Value.Id);
                        }
                        int plateauInx = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("Select Rover");

                        foreach (var rover in listOfPlataeu[plateauInx].GetAllRoversInPlateau())
                        {
                            Console.WriteLine("Press {0} To select Rover of id : {1}", rover.Key, rover.Value.Id);
                        }
                        
                        int roverIndex = Convert.ToInt16(Console.ReadLine());


                        Console.WriteLine("Enter Commands L for Left R For Right M for move one step forword:");
                        string cmmd = Convert.ToString(Console.ReadLine());

                        foreach (var item in cmmd)
                        {
                            var rover = listOfPlataeu[plateauInx].GetRover(roverIndex);
                            var plataeu = listOfPlataeu[plateauInx];
                            if (item == (char)Action.Move)
                            {
                                int[] nextPoint = rover.GetNextPoint(rover.XPoint, rover.YPoint, rover.DirectionKey, 1);
                                if (plataeu.IsNotBoundaryPoint(nextPoint, listOfPlataeu[plateauInx]) && !plataeu.IsAnyRoverInThisPoint(rover, plataeu.RoverCollection))
                                {
                                    
                                    rover.ResetXPoint(nextPoint[0]);
                                    rover.ResetYPoint(nextPoint[1]);
                                }
                                else
                                {
                                    Console.WriteLine("Boundary..");
                                }
                                
                            }
                            else if(item == (char)Action.Left || item == (char)Action.Right)
                            {
                                rover.ResetDirection(rover.GetNextDirection(rover.DirectionKey, item));
                            }
                            else
                            {
                                Console.WriteLine("Wrong Value");
                            }

                            Console.WriteLine(listOfPlataeu[plateauInx].GetRover(roverIndex).GetCurrentPosition());
                        }

                        //Console.WriteLine("Rover Current Position => {1} ", listOfRover[roverInx].GetCurrentPosition());
                        //Console.WriteLine("Rover New Position : => {0}", roverCurrent);
                        //marseRover.IsCommandExecuted(cmd, listOfRover[roverInx], listOfArea[areaInx]);
                        break;
                    default:
                        Console.WriteLine("Wrong Option");
                        break;
                }

            }

            Console.ReadKey();
        }
    }
}
