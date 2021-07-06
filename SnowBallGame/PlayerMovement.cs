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
		public int JumpSpeed { get; private set; } = 12;

		public int JumpForce { get; private set; } = 6;

		public int JumpForceCounter { get; private set; }

		public bool CanJump { get; set; } = true;

		public int PunchSpeed { get; private set; }

		public int PunchForce { get; private set; } = 4;

		public int PunchForceCounter { get; private set; }

		public Control StandOn;

		public Control FallTrought;

		public PlayerMovement(int moveSpeed) :base(moveSpeed)
		{
			ResetJumpForceCounter();
			ResetPunchForceCounter();
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

		public void ResetJumpForceCounter()
		{
			JumpForceCounter = JumpForce;
		}

		public void PunchTick()
		{
			if(PunchSpeed != 0)
			{
				DecreasePunchForceCounter();
				if(PunchForceCounter < 0)
				{
					ResetPunchForceCounter();
					ResetPunchSpeed();
				}
			}
		}

		public void SetPunchForce(int value)
		{
			PunchForce = value;
		}

		private void DecreasePunchForceCounter()
		{
			PunchForceCounter -= 1;
		}

		private void ResetPunchForceCounter()
		{
			PunchForceCounter = PunchForce;
		}

		public void SetPunchSpeed(int value)
		{
			PunchSpeed = value;
		}

		private void ResetPunchSpeed()
		{
			PunchSpeed = 0;
		}

	}
}
