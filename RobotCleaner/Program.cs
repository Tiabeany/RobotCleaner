using RobotCleaner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputList = new List<string>
            {
                Console.ReadLine(),
                Console.ReadLine(),
                Console.ReadLine(),
                Console.ReadLine()
            };

            var robotService = new RobotService(new StepInstructionService());
            robotService.RunRobotCommands(inputList);

            var uniquePlaces = robotService.GetCleanedUniquePlaces();
            Console.Write(uniquePlaces);
        }
    }
}
