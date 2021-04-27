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
            var commandsCount = int.Parse(Console.ReadLine());
            var inputList = new List<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                inputList.Add(Console.ReadLine());
            }

            var robotService = new RobotService(new StepInstructionService());
            robotService.RunRobotCommands(inputList);

            var uniquePlaces = robotService.GetCleanedUniquePlaces();
            Console.Write(uniquePlaces);
        }
    }
}
