using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class SnowBallFactory
	{
		private Control gamePanel;

		public static string SNOWBALL_TAG = "snowball";

		public SnowBallFactory(Control gamePanel)
		{
			this.gamePanel = gamePanel;
		}

		private SnowBall CreateSnowBall(Player p)
		{
			var playerEntity = p.Entity;

			var ballEntity = CreateSnowBallEntity(playerEntity);

			return new SnowBall(p, ballEntity);
		}

		public SnowBall CreateClassicSnowBall(Player p)
		{
			var s = CreateSnowBall(p);
			s.SetEntitySize(15);
			s.SetPunchForce(20);
			s.SetColor(Color.White);

			return s;
		}

		public SnowBall CreateBigSnowBall(Player p)
		{
			var s = CreateSnowBall(p);
			s.SetEntitySize(30);
			s.SetPunchForce(10);
			s.SetColor(Color.HotPink);
			s.Movement.SetMoveSpeed(10);

			return s;
		}

		public SnowBall CreateSmallSnowBall(Player p)
		{
			var s = CreateSnowBall(p);
			s.SetEntitySize(10);
			s.SetPunchForce(40);
			s.SetColor(Color.Yellow);
			s.Movement.SetMoveSpeed(30);

			return s;
		}

		private void RegisterToGamePanel(Control ballEntity)
		{
			gamePanel.Controls.Add(ballEntity);
			ballEntity.BringToFront();
		}

		private Control CreateSnowBallEntity(Control playerEntity)
		{
			var ballEntity = new Label();
			ballEntity.Tag = SNOWBALL_TAG;

			ballEntity.Top = playerEntity.Top + (playerEntity.Height / 2);
			ballEntity.Left = playerEntity.Left + (playerEntity.Width / 2);

			RegisterToGamePanel(ballEntity);

			return ballEntity;
		}
	}
}
