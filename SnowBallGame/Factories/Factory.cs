using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	abstract class Factory
	{
		protected GamePanelManager gamePanel;

		public Factory(GamePanelManager gamePanel)
		{
			this.gamePanel = gamePanel;
		}
		
	}
}
