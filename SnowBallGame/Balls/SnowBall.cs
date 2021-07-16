namespace SnowBallGame
{
	/// <summary>
	/// Type of ball with standart size, punch force and move speed.
	/// </summary>
	sealed class SnowBall : Ball
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SnowBall"/>.
		/// </summary>
		public SnowBall()
		{
			EntitySize = Config.SNOW_BALL_SIZE;
			PunchForce = Config.SNOW_BALL_PUNCH_FORCE;
			BallColor = Config.SNOW_BALL_COLOR;
			Movement = new BallMovement(Config.SNOW_BALL_MOVE_SPEED);
		}
	}
}
