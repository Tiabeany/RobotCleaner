using System.Collections.Generic;

namespace RobotCleaner.Core.Interfaces
{
    public interface IRobotService
    {
        string GetCleanedUniquePlaces();
        void RunRobotCommands(List<string> inputs);
    }
}
