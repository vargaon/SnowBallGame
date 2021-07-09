using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	class BallMovementEngine : MovementEngine<Ball>
	{
		protected List<Player> players;

		public BallMovementEngine(GamePanelManager gamePanel, List<Player> players) :base(gamePanel)
		{
			this.players = players;
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
			var movement = ball.Movement;

			if (OutOfGamePanel(entity))
			{
				ball.IsActive = false;
				gamePanel.UnRegister(entity);
			}
			else
			{
				foreach (var p in players)
				{
					var playerEntity = p.Entity;
					if (entity.Bounds.IntersectsWith(playerEntity.Bounds) && ball.Owner != p)
					{
						p.Movement.SetPunchSpeed(movement.Direction * ball.PunchForce);
						ball.Owner.HitScore();
						ball.IsActive = false;
						gamePanel.UnRegister(entity);
						return;
					}
				}
			}
		}

		override protected bool OutOfGamePanel(Control entity)
		{
			return entity.Left > gamePanel.Entity.Left + gamePanel.Entity.Width + gamePanel.Margin || entity.Left < -gamePanel.Margin;
		}
	}
}
