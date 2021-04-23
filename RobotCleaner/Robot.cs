using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    public class Robot
    {
        public string Clean(List<string> input)
        {
            var commandInstructions = input[0];            
            var startingPointInstructions = input[1];
            var horizontalInstructions = input[2];
            var verticalInstructions = input[3];

            var commandCount = int.Parse(commandInstructions);
            var horizontalStepsCount = int.Parse(horizontalInstructions.Split(' ')[1]);
            var verticalStepsCount = int.Parse(verticalInstructions.Split(' ')[1]);

            var uniquePlaces = (horizontalStepsCount / verticalStepsCount) * commandCount;

            return $"=> Cleaned: {uniquePlaces}";
        }
    }
}
