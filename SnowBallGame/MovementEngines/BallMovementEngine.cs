using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Class taking care of the ball's movement.
	/// </summary>
	sealed class BallMovementEngine : MovementEngine<Ball>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BallMovementEngine"/>.
		/// </summary>
		/// <param name="gamePanel">Game panel manager</param>
		public BallMovementEngine(GamePanelManager gamePanel) :base(gamePanel)
		{
		}

		/// <summary>
		/// Performs a ball movement according to its <see cref="BallMovement"/>.
		/// </summary>
		/// <param name="ball"></param>
		public override void Move(Ball ball)
		{
			var entity = ball.Entity;
			var movement = ball.Movement;

			entity.Left += movement.Direction * movement.MoveSpeed;
			CheckSnowBallExpiration(ball);
		}

		private void CheckSnowBallExpiration(Ball ball)
		{
			var entity = ball.Entity;
			var ballMovement = ball.Movement;

			if (OutOfGamePanel(entity))
			{
				gamePanel.UnregisterBall(ball);
			}
			else
			{
				var player = gamePanel.Players.Find(p => entity.Bounds.IntersectsWith(p.Entity.Bounds) && ball.Owner != p);

				if(player != null)
				{
					player.Movement.SetPunchSpeed(ballMovement.Direction * ball.PunchForce);
					ball.Owner.HitScore();
					gamePanel.UnregisterBall(ball);
				}
			}
		}

		override protected bool OutOfGamePanel(Control entity)
		{
			return entity.Left > gamePanel.Entity.Left + gamePanel.Entity.Width + gamePanel.Margin || entity.Left < -gamePanel.Margin;
		}
	}
}
