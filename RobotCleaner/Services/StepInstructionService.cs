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

        public List<StepInstruction> GetStepsInstructionListFromStepInputs(List<string> stepInstructionInputList)
        {
            var response = new List<StepInstruction>();

            foreach (var input in stepInstructionInputList)
            {
                var newStepInstruction = new StepInstruction
                {
                    Direction = input.Split(' ')[0],
                    StepsCount = int.Parse(input.Split(' ')[1])
                };

                response.Add(newStepInstruction);
            }

            return response;
        }
    }
}
