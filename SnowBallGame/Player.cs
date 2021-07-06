using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class Player
	{
		public Control Entity { get; }

		public PlayerControler Controler { get; private set; }

		public PlayerMovement Movement { get; } = new PlayerMovement();

		public PlayerThrowment Throwment { get; } = new PlayerThrowment();

		public int EntitySize { get; private set; } = 25;

		public int Lives { get; private set; } = 3;

		public Player(Control entity, PlayerControler controler)
		{
			this.Controler = controler;
			this.Entity = entity;
			UpdateEntitySize();
		}

		public void SetEntitySize(int value)
		{
			this.EntitySize = value;
			UpdateEntitySize();
		}

		private void UpdateEntitySize()
		{
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;
		}

		public void LoseLive()
		{
			Lives -= 1;
		}
	}
}
