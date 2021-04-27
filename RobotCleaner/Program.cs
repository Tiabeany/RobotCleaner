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
            try
            {
                var inputList = new List<string>();
                var commandsCount = int.Parse(Console.ReadLine());                
                // Starting position
                inputList.Add(Console.ReadLine());

                for (int i = 0; i < commandsCount; i++)
                {
                    // Step Instructions
                    inputList.Add(Console.ReadLine());
                }

                var robotService = new RobotService(new StepInstructionService());
                robotService.RunRobotCommands(inputList);

                var uniquePlaces = robotService.GetCleanedUniquePlaces();
                Console.Write(uniquePlaces);
            }
            catch (Exception)
            {
                // if any exception is thrown during the application running no exception must be shown and we return 0 places cleaned
                Console.Write("=> Cleaned: 0");                
            }
        }
    }
}
