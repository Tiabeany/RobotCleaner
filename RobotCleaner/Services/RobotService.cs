using System;
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

        public string GetCleanedUniquePlaces()
        {
            return $"=> Cleaned: {_cleanedUniquePlaces.Count}";
        }

        public void RunRobotCommands(List<string> inputs)
        {
            SetRobot(inputs);

            // The robot cleans the vertex it starts
            AddPositionIntoUniqueCleanPlacesIfUnique();

            for (int runningCommandIndex = 0; runningCommandIndex < Robot.CommandsToRun; runningCommandIndex++)
            {
                // If the current command index is even then we should get the first instruction (index 0) otherwise get the second instruction (index 1)
                var stepInstructionToRunIndex = runningCommandIndex % 2 == 0 ? 0 : 1;
                var stepInstructionToRun = Robot.StepInstructions[stepInstructionToRunIndex];

                var isHorizontalCommand = false;
                var isPositiveCommand = false;
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

                if (isHorizontalCommand)
                {
                    if (isPositiveCommand)
                    {
                        for (int walkingStepIndex = 0; walkingStepIndex < stepInstructionToRun.StepsCount; walkingStepIndex++)
                        {
                            if (isNextPositionValid(Robot.CurrentPosition.X + 1))
                            {
                                Robot.CurrentPosition.X++;
                                AddPositionIntoUniqueCleanPlacesIfUnique();
                            }
                        }
                    }
                    else
                    {
                        for (int walkingStepIndex = 0; walkingStepIndex < stepInstructionToRun.StepsCount; walkingStepIndex++)
                        {
                            if (isNextPositionValid(Robot.CurrentPosition.X - 1))
                            {
                                Robot.CurrentPosition.X--;
                                AddPositionIntoUniqueCleanPlacesIfUnique();
                            }
                        }
                    }
                }
                else
                {
                    if (isPositiveCommand)
                    {
                        if (isNextPositionValid(Robot.CurrentPosition.Y + 1))
                        {
                            for (int walkingStepIndex = 0; walkingStepIndex < stepInstructionToRun.StepsCount; walkingStepIndex++)
                            {
                                Robot.CurrentPosition.Y++;
                                AddPositionIntoUniqueCleanPlacesIfUnique();
                            }
                        }
                    }
                    else
                    {
                        if (isNextPositionValid(Robot.CurrentPosition.Y - 1))
                        {
                            for (int walkingStepIndex = 0; walkingStepIndex < stepInstructionToRun.StepsCount; walkingStepIndex++)
                            {
                                Robot.CurrentPosition.Y--;
                                AddPositionIntoUniqueCleanPlacesIfUnique();
                            }
                        }
                    }
                }
            }
        }

        private bool isNextPositionValid(int nextPosition)
        {
            return nextPosition <= 100.000 || nextPosition >= -100.000;
        }

        private void AddPositionIntoUniqueCleanPlacesIfUnique()
        {
            if (!_cleanedUniquePlaces.Contains(Robot.CurrentPosition))
            {
                // Adding a new Coordinate to make sure we are not adding just a reference to the Robot's current position
                _cleanedUniquePlaces.Add(new Coordinate
                {
                    X = Robot.CurrentPosition.X,
                    Y = Robot.CurrentPosition.Y
                });
            }
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
                CurrentPosition = startingPoint,
                StartingPoint = startingPoint,
                StepInstructions = stepsInstructions
            };
        }
    }
}
