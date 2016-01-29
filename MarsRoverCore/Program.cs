using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCore
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string strLandScape = "", strRoverPosition = "",strCommands;
            Console.Write("Type in Landscape: X Y");
            strLandScape = Console.ReadLine();
           
            // DefaulCommands
            strCommands = "M";
            try
            {
                
                while (!string.IsNullOrEmpty(strCommands))
                {                   
                    Console.WriteLine("Type in Rover Position: X Y Direction");
                    strRoverPosition = Console.ReadLine();                    
                    Console.WriteLine("Type in Commands");
                    strCommands = Console.ReadLine();
                    var landScape = strLandScape.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();
                    var rover = strRoverPosition.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    MarsRoverCore.Core.Position.Direction direction
                        = (MarsRoverCore.Core.Position.Direction)Enum.Parse(typeof(MarsRoverCore.Core.Position.Direction), rover[2], true);
                    // Init Rover
                    MarsRoverCore.Core.Rover Rover = new Core.Rover(new Core.Landscape(landScape[0], landScape[1]),
                        new Core.Position(Convert.ToInt32(rover[0]), Convert.ToInt32(rover[1]), direction));
                    var index = 1;
                    foreach (var ch in strCommands)
                    {
                        MarsRoverCore.Core.Rover.Command command =
                            (MarsRoverCore.Core.Rover.Command)Enum.Parse(typeof(MarsRoverCore.Core.Rover.Command), ch.ToString(), true);
                        Rover.Move(command);
                        Console.WriteLine(string.Format("{3} {0} {1} {2} ", Rover.RoverPosition.x, Rover.RoverPosition.y, Rover.RoverPosition.direction.ToString(), index++));
                    }
                    Console.WriteLine(string.Format("{0} {1} {2}", Rover.RoverPosition.x, Rover.RoverPosition.y, Rover.RoverPosition.direction.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Console.ReadLine();
        }
    }
}
