using RobotCleaner.Domain;
using System.Collections.Generic;

namespace RobotCleaner.Services.Interfaces
{
    public interface IStepInstructionService
    {
        List<StepInstruction> GetStepsInstructionListFromStepInputs(List<string> stepInstructionInputList);
    }
}
