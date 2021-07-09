namespace SnowBallGame
{
	abstract class Movement
	{
		public int MoveSpeed { get; private set; }

		public int Direction { get; private set; } = Config.DEFAULT_DIRECTION;

		public void SetMoveSpeed(int value)
		{
			MoveSpeed = value;
		}

		public void SetDirectionLeft()
		{
			Direction = -1;
		}

		public void SetDirectionRight()
		{
			Direction = 1;
		}
	}
}
