using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	abstract class MovementEngine
	{
		protected GamePanelManager gamePanel;

		public MovementEngine(GamePanelManager gamePanel)
		{
			this.gamePanel = gamePanel;
		}

		public void SetSpawnPosition(Control entity)
		{
			entity.Top = -gamePanel.Margin;
			entity.Left = gamePanel.GetRandomLeftPosition();
		}

		abstract protected bool OutOfGamePanel(Control entity);
	}
}
