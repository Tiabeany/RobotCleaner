using RobotCleaner.Core.Interfaces;
using RobotCleaner.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.Core.Services
{
    public class RobotService : IRobotService
    {
        private Robot Robot;
        private ICommandService _stepInstructionService;

        public RobotService(ICommandService stepInstructionService)
        {
            _stepInstructionService = stepInstructionService;
        }

        public string GetCleanedUniquePlaces()
        {
            return $"=> Cleaned: {Robot.CleanedUniquePlaces.Count}";
        }

        public void RunRobotCommands(List<string> inputs)
        {
            SetRobot(inputs);
                        
            if (Robot.ComandsToRun.Any())
            {
                Robot.RunAllCommands();
            }
        }

        private void SetRobot(List<string> inputs)
        {
            var startingPointInstructions = inputs[0];
            var startingPointHorizontal = int.Parse(startingPointInstructions.Split(' ')[0]);
            var startingPointVertical = int.Parse(startingPointInstructions.Split(' ')[1]);
            var startingPoint = new Coordinate(startingPointHorizontal, startingPointVertical);

            var stepsInstructionInputList = new List<string>();

            // This loop starts at i = 1 because i = 0 was already dealt before for the starting point
            for (int i = 1; i < inputs.Count; i++)
            {
                stepsInstructionInputList.Add(inputs[i]);
            }

            var stepsInstructions = _stepInstructionService.GetStepsInstructionListFromStepInputs(stepsInstructionInputList);

            Robot = new Robot(startingPoint, stepsInstructions);
        }
    }
}
