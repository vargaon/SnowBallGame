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

		public int MoveSpeed { get; private set; } = 5;

		public int JumpSpeed { get; private set; } = 8;

		public int JumpForce { get; private set; } = 10;

		public int ForceCounter { get; private set; }

		public bool CanJump { get; set; } = true;

		public int EntitySize { get; private set; } = 20;

		public Control StandOn;

		public Control FallTrought;

		public Player(Color c, Control entity, PlayerControler pc)
		{
			Controler = pc;
			this.Entity = entity;
			ForceCounter = JumpSpeed;
			SetUpEntity(c);
		}

		private void SetUpEntity(Color c)
		{
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;
			this.Entity.BackColor = c;
			this.Entity.Left = 600;
		}

		public void SetSize(int value)
		{
			this.EntitySize = value;
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;
		}

		public void SetMoveSpeed(int value)
		{
			MoveSpeed = value;
		}

		public void SetJumpSpeed(int value)
		{
			JumpSpeed = value;
		}

		public void SetJumpForce(int value)
		{
			JumpForce = value;
		}

		public void ReverseJumpSpeed()
		{
			JumpSpeed *= -1;
		}

		public void DecreaseForceCounter()
		{
			ForceCounter -= 1;
		}

		public void ResetForceCounter()
		{
			ForceCounter = JumpForce;
		}
	}
}
