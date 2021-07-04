using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class SnowBallMovementEngine
	{
		private Control gamePanel;

		private List<SnowBall> snowballs = new List<SnowBall>();

		private int gamePanelMargin = 100;

		public SnowBallMovementEngine(Control gamePanel)
		{
			this.gamePanel = gamePanel;
		}

		public void AddSnowBall(SnowBall s)
		{
			snowballs.Add(s);
		}

		public void MoveSnowBalls()
		{
			foreach (var x in snowballs)
			{
				MoveSnowBall(x);
				CheckSnowBallExpiration(x);
			}

			snowballs.RemoveAll(x => x.Active == false);
		}

		private void MoveSnowBall(SnowBall snowball)
		{
			var entity = snowball.Entity;
			var movement = snowball.Movement;

			entity.Left += movement.Direction * movement.MoveSpeed;
		}

		private void CheckSnowBallExpiration(SnowBall snowball)
		{
			var entity = snowball.Entity;
			var movement = snowball.Movement;

			if (entity.Left > gamePanel.Left + gamePanel.Width + gamePanelMargin || entity.Left < -gamePanelMargin)
			{
				snowball.Active = false;
				gamePanel.Controls.Remove(entity);
			}
			else
			{
				foreach (Control x in gamePanel.Controls)
				{
					if (x.Tag != null && x.Tag.ToString() == PlayerFactory.PLAYER_TAG)
					{
						if (entity.Bounds.IntersectsWith(x.Bounds) && snowball.Owner.Entity != x)
						{
							x.Left += movement.Direction * snowball.PunchForce;
							snowball.Active = false;
							gamePanel.Controls.Remove(entity);
							return;
						}
					}
				}
			}
		}
	}
}
