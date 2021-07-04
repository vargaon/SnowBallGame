using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerMovement : Movement
	{
		public int JumpSpeed { get; private set; } = 8;

		public int JumpForce { get; private set; } = 10;

		public int JumpForceCounter { get; private set; }

		public bool CanJump { get; set; } = true;

		public Control StandOn;

		public Control FallTrought;

		public PlayerMovement() :base(5)
		{
			JumpForceCounter = JumpSpeed;
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

		public void DecreaseJumpForceCounter()
		{
			JumpForceCounter -= 1;
		}

		public void ResetForceCounter()
		{
			JumpForceCounter = JumpForce;
		}
	}
}
