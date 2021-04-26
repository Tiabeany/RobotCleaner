using RobotCleaner.Domain;
using System.Collections.Generic;

namespace RobotCleaner.Services.Interfaces
{
    public interface IRobotService
    {
        string GetCleanedUniquePlaces();
        void RunRobotCommands(List<string> inputs);
    }
}
