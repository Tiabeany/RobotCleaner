using RobotCleaner.Domain;
using System.Collections.Generic;

namespace RobotCleaner.Services.Interfaces
{
    public interface IRobotService
    {
        void RunRobotCommands(List<string> inputs);
        string GetCleanedUniquePlaces();
    }
}
