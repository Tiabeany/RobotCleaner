﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner.Core.Interfaces;
using RobotCleaner.Core.Services;
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

            var commandService = new CommandService();
            _robotService = new RobotService(commandService);
        }

        [TestMethod]
        public void Should_Return_ExampleOutput_When_Receive_ExampleInput()
        {
            _robotService.RunRobotCommands(_exampleInputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual(EXAMPLE_OUTPUT, cleanedUniquePlaces);
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

            Assert.AreEqual(EXAMPLE_OUTPUT, cleanedUniquePlaces);
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

            Assert.AreEqual("=> Cleaned: 6", cleanedUniquePlaces);
        }

        [TestMethod]
        public void Should_Return_Zero_When_Receive_ZeroCommands()
        {
            var inputAllLines = new List<string>();
            inputAllLines.Add(EXAMPLE_INPUT_STARTING_POINT);
            _robotService.RunRobotCommands(inputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual("=> Cleaned: 0", cleanedUniquePlaces);
        }

        [TestMethod]
        public void Should_Return_One_When_Receive_ZeroSteps()
        {
            var inputAllLines = new List<string>();
            inputAllLines.Add(EXAMPLE_INPUT_STARTING_POINT);
            inputAllLines.Add("E 0");
            _robotService.RunRobotCommands(inputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual("=> Cleaned: 1", cleanedUniquePlaces);
        }

        [TestMethod]
        public void Should_Return_10001_When_Receive_10000OneStepCommandsToTheSameDirection()
        {
            var inputAllLines = new List<string>();
            inputAllLines.Add("0 0");

            for (int i = 0; i < 10000; i++)
            {
                inputAllLines.Add("E 1");
            }

            _robotService.RunRobotCommands(inputAllLines);
            var cleanedUniquePlaces = _robotService.GetCleanedUniquePlaces();

            Assert.AreEqual("=> Cleaned: 10001", cleanedUniquePlaces);
        }
    }
}
