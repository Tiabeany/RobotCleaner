using RobotCleaner.Core.Interfaces;
using RobotCleaner.Core.Models;
using System.Collections.Generic;

namespace RobotCleaner.Core.Services
{
    public class CommandService : ICommandService
    {
        public CommandService()
        {
        }

        public List<Command> GetStepsInstructionListFromStepInputs(List<string> commandsInputList)
        {
            var response = new List<Command>();

            foreach (var input in commandsInputList)
            {
                var newStepInstruction = new Command(input.Split(' ')[0], int.Parse(input.Split(' ')[1]));
                response.Add(newStepInstruction);
            }

            return response;
        }
    }
}
