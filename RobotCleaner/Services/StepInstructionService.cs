using RobotCleaner.Domain;
using RobotCleaner.Services.Interfaces;
using System.Collections.Generic;

namespace RobotCleaner.Services
{
    public class StepInstructionService : IStepInstructionService
    {
        public StepInstructionService()
        {
        }

        public List<StepInstruction> GetStepsInstructionListFromStepInputs(string stepInputOne, string stepInputTwo)
        {
            var response = new List<StepInstruction>();

            var stepInstructionOne = new StepInstruction
            {
                Direction = stepInputOne.Split(' ')[0],
                StepsCount = int.Parse(stepInputOne.Split(' ')[1])
            };

            response.Add(stepInstructionOne);

            var stepInstructionTwo = new StepInstruction
            {
                Direction = stepInputTwo.Split(' ')[0],
                StepsCount = int.Parse(stepInputTwo.Split(' ')[1])
            };

            response.Add(stepInstructionTwo);

            return response;
        }
    }
}
