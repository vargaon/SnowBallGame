using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	sealed class BallMovementEngine : MovementEngine<Ball>
	{
		private List<Player> _players;

		public BallMovementEngine(GamePanelManager gamePanel, List<Player> players) :base(gamePanel)
		{
			this._players = players;
		}

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
				ball.IsActive = false;
				gamePanel.UnRegister(entity);
			}
			else
			{
				var player = _players.Find(p => entity.Bounds.IntersectsWith(p.Entity.Bounds) && ball.Owner != p);

				if(player != null)
				{
					player.Movement.SetPunchSpeed(ballMovement.Direction * ball.PunchForce);
					ball.Owner.HitScore();
					ball.IsActive = false;
					gamePanel.UnRegister(entity);
				}
			}
		}

		override protected bool OutOfGamePanel(Control entity)
		{
			return entity.Left > gamePanel.Entity.Left + gamePanel.Entity.Width + gamePanel.Margin || entity.Left < -gamePanel.Margin;
		}
	}
}
