namespace RobotCleaner.Core.Models
{
    public class Command
    {
        public string Direction { get; private set; }
        public int StepsCount { get; private set; }

        public Command(string direction, int stepsCount)
        {
            Direction = direction;
            StepsCount = stepsCount;
        }
    }
}