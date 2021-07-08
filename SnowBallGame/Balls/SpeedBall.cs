namespace SnowBallGame
{
	class SpeedBall : Ball
	{
		public SpeedBall()
		{
			EntitySize = Config.SPEED_BALL_SIZE;
			PunchForce = Config.SPEED_BALL_PUNCH_FORCE;
			BallColor = Config.SPEED_BALL_COLOR;
			Movement = new BallMovement(Config.SPEED_BALL_MOVE_SPEED);
		}
	}
}
