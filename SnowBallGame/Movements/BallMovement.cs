namespace SnowBallGame
{
	/// <summary>
	/// Data class with ball movement properties.
	/// </summary>
	sealed class BallMovement : Movement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BallMovement"/>.
		/// </summary>
		/// <param name="moveSpeed"></param>
		public BallMovement(int moveSpeed) 
		{
			SetMoveSpeed(moveSpeed);
		}
	}
}
