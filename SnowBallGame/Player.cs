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

		public int EntitySize { get; private set; } = 20;

		public int Direction { get; private set; } = 1;

		public Player(Color c, Control entity, PlayerControler pc)
		{
			Controler = pc;
			this.Entity = entity;
			SetUpEntity(c);
		}

		private void SetUpEntity(Color c)
		{
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;
			this.Entity.BackColor = c;
		}

		public void SetSize(int value)
		{
			this.EntitySize = value;
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;
		}

		public void SetDirectionLeft()
		{
			Direction = -1;
		}

		public void SetDirectionRight()
		{
			Direction = 1;
		}
	}
}
