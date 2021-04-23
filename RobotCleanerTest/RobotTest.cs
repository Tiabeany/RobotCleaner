using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner;
using System.Collections.Generic;

namespace RobotCleanerTest
{
    [TestClass]
    public class RobotTest
    {
        private const string EXAMPLE_INPUT_LINE_ONE = "2";
        private const string EXAMPLE_INPUT_LINE_TWO = "10 22";
        private const string EXAMPLE_INPUT_LINE_THREE = "E 2";
        private const string EXAMPLE_INPUT_LINE_FOUR = "N 1";

        private const string EXAMPLE_OUTPUT = "=> Cleaned: 4";

        private static List<string> _exampleInputAllLines = new List<string>();

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _exampleInputAllLines.Add(EXAMPLE_INPUT_LINE_ONE);
            _exampleInputAllLines.Add(EXAMPLE_INPUT_LINE_TWO);
            _exampleInputAllLines.Add(EXAMPLE_INPUT_LINE_THREE);
            _exampleInputAllLines.Add(EXAMPLE_INPUT_LINE_FOUR);
        }

        [TestMethod]
        public void Should_Return_ExampleOutput_When_Receive_ExampleInput()
        {
            var robot = new Robot();
            var result = robot.Clean(_exampleInputAllLines);

            Assert.AreEqual(result, EXAMPLE_OUTPUT);
        }
    }
}
