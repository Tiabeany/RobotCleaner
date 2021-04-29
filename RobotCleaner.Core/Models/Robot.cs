using System;
using System.Collections.Generic;
using System.Windows;

namespace RobotCleaner.Core.Models
{
    public class Robot
    {
        public Coordinate StartingPoint { get; private set; }
        public List<Command> ComandsToRun { get; private set; }
        public Coordinate CurrentPosition { get; private set; }
        public List<Coordinate> CleanedUniquePlaces { get; private set; }

        public Robot(Coordinate startingPoint, List<Command> stepInstructions)
        {
            CurrentPosition = startingPoint;
            StartingPoint = startingPoint;
            ComandsToRun = stepInstructions;
            CleanedUniquePlaces = new List<Coordinate>();
        }

        public void RunAllCommands()
        {
            CleanedUniquePlaces.Clear();
            // The robot cleans the vertex it starts
            AddPositionIntoUniqueCleanPlacesIfUnique(CurrentPosition);
            foreach (var command in ComandsToRun)
            {
                RunCommand(command);
            }
        }

        private void RunCommand(Command command)
        {
            if (command.Direction.Equals("E"))
            {
                WalkEast(command.StepsCount, CurrentPosition.X, CurrentPosition.Y);
            }
            
            if (command.Direction.Equals("W"))
            {
                WalkWest(command.StepsCount, CurrentPosition.X, CurrentPosition.Y);
            }
            
            if (command.Direction.Equals("S"))
            {
                WalkSouth(command.StepsCount, CurrentPosition.X, CurrentPosition.Y);
            }
            
            if (command.Direction.Equals("N"))
            {
                WalkNorth(command.StepsCount, CurrentPosition.X, CurrentPosition.Y);
            }
        }

        private void WalkEast(int stepsCount, int currentX, int currentY)
        {
            var newXPosition = currentX;
            for (int i = 0; i < stepsCount; i++)
            {
                newXPosition++;
                AddPositionIntoUniqueCleanPlacesIfUnique(new Coordinate(newXPosition, currentY));
            }            
            CurrentPosition = new Coordinate(newXPosition, currentY);
        }

        private void WalkWest(int stepsCount, int currentX, int currentY)
        {
            var newXPosition = currentX;
            for (int i = 0; i < stepsCount; i++)
            {
                newXPosition--;
                AddPositionIntoUniqueCleanPlacesIfUnique(new Coordinate(newXPosition, currentY));
            }
            CurrentPosition = new Coordinate(newXPosition, currentY);
        }

        private void WalkSouth(int stepsCount, int currentX, int currentY)
        {
            var newYPosition = currentY;
            for (int i = 0; i < stepsCount; i++)
            {
                newYPosition--;
                AddPositionIntoUniqueCleanPlacesIfUnique(new Coordinate(currentX, newYPosition));
            }
            CurrentPosition = new Coordinate(currentX, newYPosition);
        }

        private void WalkNorth(int stepsCount, int currentX, int currentY)
        {
            var newYPosition = currentY;
            for (int i = 0; i < stepsCount; i++)
            {
                newYPosition++;
                AddPositionIntoUniqueCleanPlacesIfUnique(new Coordinate(currentX, newYPosition));
            }
            CurrentPosition = new Coordinate(currentX, newYPosition);
        }

        private void AddPositionIntoUniqueCleanPlacesIfUnique(Coordinate position)
        {
            if (!CleanedUniquePlaces.Contains(position))
            {
                CleanedUniquePlaces.Add(position);
            }
        }
    }
}
