namespace SnowBallGame
{
	/// <summary>
	/// Abstract class for moveable entities.
	/// </summary>
	abstract class Movement
	{
		/// <summary>
		/// Move speed. How fast the ball movement is.
		/// </summary>
		public int MoveSpeed { get; private set; }

		/// <summary>
		/// Entity direction.
		/// Value -1 means left.
		/// Value 1 means right.
		/// </summary>
		public int Direction { get; private set; } = Config.DEFAULT_DIRECTION;

		/// <summary>
		/// Set a movement speed.
		/// </summary>
		/// <param name="value"></param>
		public void SetMoveSpeed(int value)
		{
			MoveSpeed = value;
		}

		/// <summary>
		/// Set the direction to left.
		/// </summary>
		public void SetDirectionLeft()
		{
			Direction = -1;
		}

		/// <summary>
		/// Set the direction to right.
		/// </summary>
		public void SetDirectionRight()
		{
			Direction = 1;
		}

		/// <summary>
		/// Set the direction to the same value as given <see cref="Movement"/>.
		/// </summary>
		/// <param name="movement"></param>
		public void SetSameDirection(Movement movement)
		{
			Direction = movement.Direction;
		}
	}
}
