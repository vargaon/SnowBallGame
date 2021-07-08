namespace SnowBallGame
{
	class SnowBall : Ball
	{
		public SnowBall()
		{
			EntitySize = Config.SNOW_BALL_SIZE;
			PunchForce = Config.SNOW_BALL_PUNCH_FORCE;
			BallColor = Config.SNOW_BALL_COLOR;
			Movement = new BallMovement(Config.SNOW_BALL_MOVE_SPEED);
		}
	}
}
