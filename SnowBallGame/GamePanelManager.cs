using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class GamePanelManager
	{
		private static string PLATFORM_TAG = "platform";

		protected Random random = new Random();

		public List<Control> Platforms { get; }

		public Control Entity { get; }

		public int Margin { get; } = 100;

		public GamePanelManager(Control gamePanelEntity)
		{
			this.Platforms = new List<Control>();
			Entity = gamePanelEntity;
			RegisterPlatforms();
		}

		private void RegisterPlatforms()
		{
			foreach (Control x in Entity.Controls)
			{
				if (x.Tag != null && x.Tag.ToString() == PLATFORM_TAG) Platforms.Add(x);
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

		public void Register(Control entity)
		{
			Entity.Controls.Add(entity);
		}

		public void UnRegister(Control entity)
		{
			Entity.Controls.Remove(entity);
		}
	}
}
