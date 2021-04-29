using RobotCleaner.Core.Models;
using System.Collections.Generic;

namespace RobotCleaner.Core.Interfaces
{
    public interface ICommandService
    {
        List<Command> GetStepsInstructionListFromStepInputs(List<string> stepInstructionInputList);
    }
}
