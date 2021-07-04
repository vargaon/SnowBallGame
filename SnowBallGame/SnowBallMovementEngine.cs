using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class SnowBallMovementEngine : MovementEngine<SnowBall>
	{
		private List<Player> players;

		public SnowBallMovementEngine(Control gamePanel, List<Player> players) :base(gamePanel)
		{
			this.players = players;
		}

		public void Move(SnowBall snowball)
		{
			var entity = snowball.Entity;
			var movement = snowball.Movement;

			entity.Left += movement.Direction * movement.MoveSpeed;
			CheckSnowBallExpiration(snowball);
		}

		private void CheckSnowBallExpiration(SnowBall snowball)
		{
			var entity = snowball.Entity;
			var movement = snowball.Movement;

			if (OutOfGamePanel(entity))
			{
				snowball.Active = false;
				gamePanel.Controls.Remove(entity);
			}
			else
			{
				foreach (var p in players)
				{
					var playerEntity = p.Entity;
					if (entity.Bounds.IntersectsWith(playerEntity.Bounds) && snowball.Owner != p)
					{
						p.Movement.SetPunchSpeed(movement.Direction * snowball.PunchForce);
						snowball.Active = false;
						gamePanel.Controls.Remove(entity);
						return;
					}
				}
			}
		}

		override protected bool OutOfGamePanel(Control entity)
		{
			return entity.Left > gamePanel.Left + gamePanel.Width + gamePanelMargin || entity.Left < -gamePanelMargin;
		}
	}
}
