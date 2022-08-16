// See https://aka.ms/new-console-template for more information
ToyRobotPuzzle.ToyRobot toyRobot = new();

while (true)
{
    toyRobot.ParseCommand(command: Console.ReadLine());
}