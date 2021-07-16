namespace SnowBallGame
{
	/// <summary>
	/// Type of ball with faster movement, increased punch force and smaller size.
	/// </summary>
	sealed class SpeedBall : Ball
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SpeedBall"/>.
		/// </summary>
		public SpeedBall()
		{
			EntitySize = Config.SPEED_BALL_SIZE;
			PunchForce = Config.SPEED_BALL_PUNCH_FORCE;
			BallColor = Config.SPEED_BALL_COLOR;
			Movement = new BallMovement(Config.SPEED_BALL_MOVE_SPEED);
		}
	}
}
