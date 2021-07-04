using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	abstract class MovementEngine<T>
	{
		protected int gamePanelMargin = 100;

		private static string PLATFORM_TAG = "platform";

		protected Random random = new Random();

		protected List<Control> platforms;

		protected Control gamePanel;

		public MovementEngine(Control gamePanel)
		{
			this.gamePanel = gamePanel;
			RegisterPlatforms();
		}

		private void RegisterPlatforms()
		{
			this.platforms = new List<Control>();

			foreach (Control x in gamePanel.Controls)
			{
				if (x.Tag != null && x.Tag.ToString() == PLATFORM_TAG) platforms.Add(x);
			}
		}

		public void SetSpawnPosition(Control entity)
		{
			entity.Top = -gamePanelMargin;
			entity.Left = GetRandomLeftPosition();
		}

		private int GetRandomLeftPosition()
		{
			if (platforms.Count > 0)
			{
				var platform = platforms[random.Next(0, platforms.Count)];
				return random.Next(platform.Left, platform.Left + platform.Width);
			}

			return 0;
		}

		abstract protected bool OutOfGamePanel(Control entity);
	}
}
