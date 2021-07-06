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

		public SnowBall CreateSnowBall(Player p)
		{
			var playerEntity = p.Entity;

			var ballEntity = new Label();
			ballEntity.Tag = SNOWBALL_TAG;
			
			ballEntity.Top = playerEntity.Top + (p.EntitySize / 2);
			ballEntity.Left = playerEntity.Left + (p.EntitySize / 2);

			gamePanel.Controls.Add(ballEntity);
			ballEntity.BringToFront();

			return new SnowBall(p, ballEntity, Color.White);
		}
	}
}
