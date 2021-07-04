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

		private List<Player> players;

		private int gamePanelMargin = 100;

		public SnowBallMovementEngine(Control gamePanel, List<Player> players)
		{
			this.gamePanel = gamePanel;
			this.players = players;
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

			removeUnactiveSnowBalls();
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
			}
			else
			{
				foreach (var p in players)
				{
					var playerEntity = p.Entity;
					if (entity.Bounds.IntersectsWith(playerEntity.Bounds) && snowball.Owner != p)
					{
						playerEntity.Left += movement.Direction * snowball.PunchForce;
						snowball.Active = false;
						return;
					}
					
				}
			}
		}

		private void removeUnactiveSnowBalls()
		{
			foreach(var s in snowballs)
			{
				if(!s.Active) gamePanel.Controls.Remove(s.Entity);
			}

			snowballs.RemoveAll(x => x.Active == false);
		}
	}
}
