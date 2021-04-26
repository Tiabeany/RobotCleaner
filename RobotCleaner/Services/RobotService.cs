using System.Collections.Generic;
using RobotCleaner.Domain;
using RobotCleaner.Services.Interfaces;

namespace RobotCleaner.Services
{
    public class RobotService : IRobotService
    {
        private Robot Robot { get; set; }
        private List<Coordinate> _cleanedUniquePlaces { get; set; }        
        private IStepInstructionService _stepInstructionService { get; set; }

        public RobotService(IStepInstructionService stepInstructionService)
        {
            _stepInstructionService = stepInstructionService;
            _cleanedUniquePlaces = new List<Coordinate>();
        }

        public void RunRobotCommands(List<string> inputs)
        {
            SetRobot(inputs);

            // The robot cleans the vertex it starts
            _cleanedUniquePlaces.Add(Robot.StartingPoint);

            for (int i = 0; i < Robot.CommandsToRun; i++)
            {
                // If the current command index is even then we should get the first instruction (index 0) otherwise get the second instruction (index 1)
                var stepInstructionToRunIndex = i % 2 == 0 ? 0 : 1;
                var stepInstructionToRun = Robot.StepInstructions[stepInstructionToRunIndex];

                bool isHorizontalCommand;
                bool isPositiveCommand;
                switch (stepInstructionToRun.Direction)
                {
                    case "E":
                        isHorizontalCommand = true;
                        isPositiveCommand = true;
                        break;
                    case "W":
                        isHorizontalCommand = true;
                        isPositiveCommand = false;
                        break;
                    case "S":
                        isHorizontalCommand = false;
                        isPositiveCommand = false;
                        break;
                    case "N":
                        isHorizontalCommand = false;
                        isPositiveCommand = true;
                        break;
                }
            }
        }

        public string GetCleanedUniquePlaces()
        {
            return $"=> Cleaned: {_cleanedUniquePlaces.Count}";
        }

        private void SetRobot(List<string> inputs)
        {
            var commandInstructions = int.Parse(inputs[0]);

            var startingPointInstructions = inputs[1];
            var startingPointHorizontal = int.Parse(startingPointInstructions.Split(' ')[0]);
            var startingPointVertical = int.Parse(startingPointInstructions.Split(' ')[1]);
            var startingPoint = new Coordinate { X = startingPointHorizontal, Y = startingPointVertical };

            var stepInstructionInputOne = inputs[2];
            var stepInstructionInputTwo = inputs[3];
            var stepsInstructions = _stepInstructionService.GetStepsInstructionListFromStepInputs(stepInstructionInputOne, stepInstructionInputTwo);

            Robot = new Robot
            {
                CommandsToRun = commandInstructions,
                StartingPoint = startingPoint,
                StepInstructions = stepsInstructions
            };
        }
    }
}
