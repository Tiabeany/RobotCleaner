using System.Collections.Generic;
using System.Windows;

namespace RobotCleaner.Domain
{
    public class Robot
    {
        public Coordinate StartingPoint { get; set; }
        public List<StepInstruction> StepInstructions { get; set; }
        public Coordinate CurrentPosition { get; set; }
    }
}
