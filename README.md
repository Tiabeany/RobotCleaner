# RobotCleaner
Robot Cleaner is a Console .NET Framework v4.7.2 that simulates a cleaning robot.

Once running the application it will be waiting for the following input.
The application expects that these lines are consistent with the following:
 - First Input line: a single integer that represents the number of commands the program should read (from the third input and so on) and to be executed by the robot. The number should be in range n(0 <= n <= 10,000);
 - Second Input line: two integers separated by a single space that represents the initial location of the robot. Each coordinate should be in range x(-100,00 <= x <= 100,000) and y(-100,00 <= y <= 100,000);
 - The third, and any subsequent line, will consist of two pieces of data. The firs will be a single uppercase character c {E,W,S,N}, that represents the direction on the compass the robot should head. The second will be an integer representing the number s(0 < s < 100,000).

Output:
The output will show a number of how many unique places the robot cleaned while running the commands. Every vertex it touches is cleaned. The output of this number is prefixed by "=> Cleaned:"

Observation: No exception or error message will be shown, only the expected output. In the case any error happens the output will be always 0.
