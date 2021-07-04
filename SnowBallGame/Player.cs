﻿using System;
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

		public Player(Control entity, PlayerControler controler)
		{
			this.Controler = controler;
			this.Entity = entity;
			UpdateEntitySize();
		}

		public void SetSize(int value)
		{
			this.EntitySize = value;
			UpdateEntitySize();
		}

		private void UpdateEntitySize()
		{
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
