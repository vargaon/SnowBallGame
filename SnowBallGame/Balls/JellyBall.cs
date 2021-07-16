namespace SnowBallGame
{
	/// <summary>
	/// Type of ball with slower movement speed, decreased punch force and bigger size.
	/// </summary>
	sealed class JellyBall : Ball
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="JellyBall"/>.
		/// </summary>
		public JellyBall()
		{
			EntitySize = Config.JELLY_BALL_SIZE;
			PunchForce = Config.JELLY_BALL_PUNCH_FORCE;
			BallColor = Config.JELLY_BALL_COLOR;
			Movement = new BallMovement(Config.JELLY_BALL_MOVE_SPEED);
		}
	}
}
