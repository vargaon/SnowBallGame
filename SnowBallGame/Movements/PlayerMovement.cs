using System.Windows.Forms;

namespace SnowBallGame
{
	sealed class PlayerMovement : Movement
	{
		public int JumpSpeed { get; private set; } = Config.PLAYER_JUMP_SPEED;

		public int JumpForce { get; private set; } = Config.PLAYER_JUMP_FORCE;

		public int PunchForce { get; private set; } = Config.PLAYER_PUNCH_FORCE;

		public int JumpForceCounter { get; private set; }
		public int PunchForceCounter { get; private set; }

		public bool CanJump { get; set; } = true;

		public int PunchSpeed { get; private set; }

		public Control StandOn;

		public Control FallTrought;

		public PlayerMovement()
		{
			SetMoveSpeed(Config.PLAYER_MOVE_SPEED);
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

		public bool Falling()
		{
			return JumpSpeed < 0;
		}

		public bool DecreaseJumpForceCounter()
		{
			JumpForceCounter -= 1;
			return JumpForceCounter <= 0;
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

		public void SetPunchSpeed(int value)
		{
			PunchSpeed = value;
		}

		public void SetPunchForce(int value)
		{
			PunchForce = value;
			PunchForceCounter = value;
		}

		private void DecreasePunchForceCounter()
		{
			PunchForceCounter -= 1;
		}

		private void ResetPunchForceCounter()
		{
			PunchForceCounter = PunchForce;
		}

		private void ResetPunchSpeed()
		{
			PunchSpeed = 0;
		}
	}
}
