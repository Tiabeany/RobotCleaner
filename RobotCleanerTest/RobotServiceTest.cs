using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner;
using RobotCleaner.Domain;
using RobotCleaner.Services;
using RobotCleaner.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RobotCleanerTest
{
    [TestClass]
    public class RobotServiceTest
    {
        private const string EXAMPLE_INPUT_STARTING_POINT = "10 22";
        private const string EXAMPLE_INPUT_DIRECTIONAL_STEPS_ONE = "E 2";
        private const string EXAMPLE_INPUT_DIRECTIONAL_STEPS_TWO = "N 1";

        private const string EXAMPLE_OUTPUT = "=> Cleaned: 4";

        private static List<string> _exampleInputAllLines = new List<string>();
        private static IRobotService _robotService;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _exampleInputAllLines.Add(EXAMPLE_INPUT_STARTING_POINT);
            _exampleInputAllLines.Add(EXAMPLE_INPUT_DIRECTIONAL_STEPS_ONE);
            _exampleInputAllLines.Add(EXAMPLE_INPUT_DIRECTIONAL_STEPS_TWO);

            var stepInstructionService = new StepInstructionService();
            _robotService = new RobotService(stepInstructionService);
        }

        [TestMethod]
        public void Should_Return_ExampleOutput_When_Receive_ExampleInput()
        {
            _robotService.RunRobotCommands(_exampleInputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual(cleanedUniquePlaces, EXAMPLE_OUTPUT);
        }

        [TestMethod]
        public void Should_Return_ExampleOutput_When_Receive_ExampleInputWithRoomyStartpoint()
        {
            var inputAllLines = new List<string>();
            inputAllLines.Add("880 58490");
            inputAllLines.Add(EXAMPLE_INPUT_DIRECTIONAL_STEPS_ONE);
            inputAllLines.Add(EXAMPLE_INPUT_DIRECTIONAL_STEPS_TWO);

            _robotService.RunRobotCommands(inputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual(cleanedUniquePlaces, EXAMPLE_OUTPUT);
        }

        [TestMethod]
        public void Should_Return_Six_When_Receive_ExampleInputWithOneExtraCommand()
        {
            var inputAllLines = new List<string>();
            inputAllLines.Add(EXAMPLE_INPUT_STARTING_POINT);
            inputAllLines.Add(EXAMPLE_INPUT_DIRECTIONAL_STEPS_ONE);
            inputAllLines.Add(EXAMPLE_INPUT_DIRECTIONAL_STEPS_TWO);
            inputAllLines.Add("E 2");

            _robotService.RunRobotCommands(inputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual(cleanedUniquePlaces, "=> Cleaned: 6");
        }

        [TestMethod]
        public void Should_Return_Zero_When_Receive_ZeroCommands()
        {
            var inputAllLines = new List<string>();
            inputAllLines.Add(EXAMPLE_INPUT_STARTING_POINT);
            _robotService.RunRobotCommands(inputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual(cleanedUniquePlaces, "=> Cleaned: 0");
        }

        [TestMethod]
        public void Should_Return_One_When_Receive_ZeroSteps()
        {
            var inputAllLines = new List<string>();
            inputAllLines.Add(EXAMPLE_INPUT_STARTING_POINT);
            inputAllLines.Add("E 0");
            _robotService.RunRobotCommands(inputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual(cleanedUniquePlaces, "=> Cleaned: 1");
        }
    }
}
