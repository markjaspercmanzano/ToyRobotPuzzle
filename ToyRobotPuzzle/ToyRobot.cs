using System;
namespace ToyRobotPuzzle
{
	public class ToyRobot
	{
		public ToyRobot()
		{
			// initialize values; set coordinates to (0,0) with blank direction
			CoordinateX = Constants.lowerBoundaryX;
			CoordinateY = Constants.lowerBoundaryY;
			CurrentDirection = "";
		}

		public int CoordinateX { get; set; }
		public int CoordinateY { get; set; }
		public string CurrentDirection { get; set; }

		public void ParseCommand(string? command)
		{
			// handling for PLACE is different due to parameters
			if (!string.IsNullOrEmpty(command) && command.Length >= (Constants.placeCommand.Length + 4) && (command.Substring(0, 5) == Constants.placeCommand))
			{
 				if (command.Substring(7, 1) != ",")
                {
					return;
                }

				int coordinateX = Convert.ToInt32(command.Substring(6, 1));
				int coordinateY = Convert.ToInt32(command.Substring(8, 1));

				if (command.Length >= (Constants.placeCommand.Length + 5))
				{
					if (command.Substring(9, 1) == ",")
                    {
						string direction = command.Substring(10);
						PlaceRobot(coordinateX, coordinateY, direction);
						return;
					}
				}

				PlaceRobot(coordinateX, coordinateY);
			}

			// MOVE, REPORT, LEFT, RIGHT; commands that don't fit within that scope will be ignored
			else
            {
				if (!IsRobotPlaced())
                {
					return;
                }

				switch(command)
                {
					case Constants.moveCommand:
						MoveRobot();
						break;
					case Constants.reportCommand:
						ReportRobotLocation();
						break;
					case Constants.leftCommand:
						RotateRobotLeft();
						break;
					case Constants.rightCommand:
						RotateRobotRight();
						break;
					default: // do nothing if command is not a match
						return;
                }
            }
		}

		private void PlaceRobot(int x, int y, string direction = "")
		{
			if (!IsRobotPlaced() && string.IsNullOrEmpty(direction))
            {
				return;
            }

			if (x > Constants.upperBoundaryX || x < Constants.lowerBoundaryX)
			{
				return;
			}

			else if (y > Constants.upperBoundaryY || y < Constants.lowerBoundaryY)
			{
				return;
			}

			if (!string.IsNullOrEmpty(direction) && (direction == Constants.northDirection || direction == Constants.eastDirection || direction == Constants.westDirection || direction == Constants.southDirection))
            {
				CurrentDirection = direction;
            }

			CoordinateX = x;
			CoordinateY = y;
		}

		private void RotateRobotLeft()
		{
			switch (CurrentDirection)
			{
				case Constants.northDirection:
					CurrentDirection = Constants.westDirection;
					break;
				case Constants.westDirection:
					CurrentDirection = Constants.southDirection;
					break;
				case Constants.southDirection:
					CurrentDirection = Constants.eastDirection;
					break;
				case Constants.eastDirection:
					CurrentDirection = Constants.northDirection;
					break;
				default:
					return;
			}
		}

		private void RotateRobotRight()
        {
			switch (CurrentDirection)
            {
				case Constants.northDirection:
					CurrentDirection = Constants.eastDirection;
					break;
				case Constants.eastDirection:
					CurrentDirection = Constants.southDirection;
					break;
				case Constants.southDirection:
					CurrentDirection = Constants.westDirection;
					break;
				case Constants.westDirection:
					CurrentDirection = Constants.northDirection;
					break;
				default:
					return;
            }
        }

		private void MoveRobot()
        {
			if (CurrentDirection == Constants.northDirection)
            {
				if (CoordinateY + 1 > Constants.upperBoundaryY)
                {
					return;
                }

				CoordinateY++;
            }

			else if (CurrentDirection == Constants.southDirection)
            {
				if (CoordinateY - 1 < Constants.lowerBoundaryY)
				{
					return;
				}

				CoordinateY--;
            }

			else if (CurrentDirection == Constants.eastDirection)
            {
				if (CoordinateX + 1 > Constants.upperBoundaryX)
                {
					return;
                }

				CoordinateX++;
            }

			else if (CurrentDirection == Constants.westDirection)
			{
				if (CoordinateX - 1 < Constants.lowerBoundaryX)
				{
					return;
				}

				CoordinateX--;
			}
        }

		private void ReportRobotLocation()
		{
			Console.WriteLine($"{CoordinateX},{CoordinateY},{CurrentDirection}");
		}

		private bool IsRobotPlaced()
		{
			if (string.IsNullOrEmpty(CurrentDirection))
			{
				return false;
			}

			return true;
		}
	}
}

