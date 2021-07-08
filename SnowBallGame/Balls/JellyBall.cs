namespace SnowBallGame
{
	class JellyBall : Ball
	{
		public JellyBall()
		{
			EntitySize = Config.JELLY_BALL_SIZE;
			PunchForce = Config.JELLY_BALL_PUNCH_FORCE;
			BallColor = Config.JELLY_BALL_COLOR;
			Movement = new BallMovement(Config.JELLY_BALL_MOVE_SPEED);
		}
	}
}
