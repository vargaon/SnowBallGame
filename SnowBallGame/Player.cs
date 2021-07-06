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

		private PlayerMovement _movement;

		private PlayerMovement _bonusMovement;

		public PlayerMovement Movement { 
			get {
				if (_bonusMovement != null) return _bonusMovement;
				else return _movement;
			}
			set { _movement = value; }
		}

		PlayerThrowment _throwment;

		PlayerThrowment _bonusThrowment;

		public PlayerThrowment Throwment {
			get
			{
				if (_bonusThrowment != null) return _bonusThrowment;
				else return _throwment;
			}
			set { _throwment = value; }
		}

		public int EntitySize { get; private set; } = 25;

		public int Lives { get; private set; } = 3;

		public Player(Control entity, PlayerControler controler)
		{
			this.Controler = controler;
			this.Entity = entity;

			this.Movement = new PlayerMovement(10);
			this.Throwment = new PlayerThrowment();

			UpdateEntitySize();
		}

		public void SetEntitySize(int value)
		{
			this.EntitySize = value;
			UpdateEntitySize();
		}

		public void SetBonusMovement(PlayerMovement movement)
		{
			_bonusMovement = movement;
		}

		public void SetBonusThrowment(PlayerThrowment throwment)
		{
			_bonusThrowment = throwment;
		}

		private void UpdateEntitySize()
		{
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;
		}

		public bool LoseLive()
		{
			Lives -= 1;

			return Lives <= 0;
		}
	}
}
