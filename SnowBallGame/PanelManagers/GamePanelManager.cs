using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnowBallGame
{
	sealed class GamePanelManager : PanelManager
	{
		private Random random;

		public List<Control> Platforms { get; }

		public int Margin { get; } = Config.GAME_PANEL_MARGIN;

		public GamePanelManager(Control gamePanelEntity, Random random) : base(gamePanelEntity)
		{
			this.Platforms = new List<Control>();
			this.random = random;
			RegisterPlatforms();
		}

		private void RegisterPlatforms()
		{
			foreach (Control x in Entity.Controls)
			{
				if (x.Tag != null && x.Tag.ToString() == Config.PLATFORM_TAG) Platforms.Add(x);
			}
		}

		public int GetRandomLeftPosition()
		{
			if (Platforms.Count > 0)
			{
				var platform = Platforms[random.Next(0, Platforms.Count)];
				return random.Next(platform.Left, platform.Left + platform.Width);
			}

			return 0;
		}

		public Point GetRandomPosition()
		{
			if (Platforms.Count > 0)
			{
				var platform = Platforms[random.Next(0, Platforms.Count)];
				return new Point(random.Next(platform.Left, platform.Left + platform.Width), platform.Top);
			}

			return new Point(0,0);
		}
	}
}
