namespace SnowBallGame
{
	sealed class BallMovement : Movement
	{
		public BallMovement(int moveSpeed) 
		{
			SetMoveSpeed(moveSpeed);
		}
	}
}
