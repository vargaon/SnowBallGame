using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Data class with player movement properties.
	/// </summary>
	sealed class PlayerMovement : Movement
	{
		/// <summary>
		/// Default value of gravitation.
		/// </summary>
		public static int DEFAULT_GRAVITY { get; } = 1;

		/// <summary>
		/// Speed of player's jump.
		/// </summary>
		public int JumpSpeed { get; private set; } = Config.PLAYER_JUMP_SPEED;

		/// <summary>
		/// Jump force. 
		/// How many times player will move in assign <see cref="JumpDirection"/> by <see cref="JumpSpeed"/> 
		/// </summary>
		public int JumpForce { get; private set; } = Config.PLAYER_JUMP_FORCE;

		/// <summary>
		/// Punch force.
		/// How many times player will move by <see cref="PunchSpeed"/>.
		/// </summary>
		public int PunchForce { get; private set; } = Config.PLAYER_PUNCH_FORCE;

		/// <summary>
		/// Gravitation value.
		/// Value 1 means standart gravity.
		/// Value -1 means reverse gravity.
		/// </summary>
		public int Gravity { get; private set; } = DEFAULT_GRAVITY;

		/// <summary>
		/// Jump direction according to <see cref="Gravity"/>.
		/// Value -1 means up.
		/// Value 1 means down.
		/// </summary>
		public int JumpDirection { get; private set; }

		/// <summary>
		/// Helper counter for jump movement.
		/// </summary>
		public int JumpForceCounter { get; private set; }

		/// <summary>
		/// Helper counter for punch movement.
		/// </summary>
		public int PunchForceCounter { get; private set; }

		/// <summary>
		/// Flag for player jump movement.
		/// </summary>
		public bool CanJump { get; set; } = true;

		/// <summary>
		/// Speed of ball punch. Is set by ball that hits player.
		/// </summary>
		public int PunchSpeed { get; private set; }

		/// <summary>
		/// The game panel platform on which the player stands
		/// </summary>
		public Control StandOn;

		/// <summary>
		/// The game panel platform that the player falls through.
		/// </summary>
		public Control FallTrought;

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerMovement"/>.
		/// </summary>
		public PlayerMovement()
		{
			JumpDirection = Gravity;
			SetMoveSpeed(Config.PLAYER_MOVE_SPEED);
			ResetJumpForceCounter();
			ResetPunchForceCounter();
		}

		/// <summary>
		/// Sets a <see cref="JumpSpeed"/> value.
		/// </summary>
		/// <param name="value"></param>
		public void SetJumpSpeed(int value)
		{
			JumpSpeed = value;
		}

		/// <summary>
		/// Sets a <see cref="JumpForce"/> value.
		/// </summary>
		/// <param name="value"></param>
		public void SetJumpForce(int value)
		{
			JumpForce = value;
		}

		/// <summary>
		/// Reverses the <see cref="Gravity"/> value and change <see cref="JumpDirection"/> according to this.
		/// </summary>
		public void ReverseGravity()
		{
			Gravity *= -1;
			JumpDirection = Gravity;
		}

		/// <summary>
		/// Sets <see cref="JumpDirection"/> to up according to <see cref="Gravity"/>.
		/// </summary>
		public void SetJumpDirectionUp()
		{
			JumpDirection = -1 * Gravity;
		}

		/// <summary>
		/// Sets <see cref="JumpDirection"/> to down according to <see cref="Gravity"/>.
		/// </summary>
		public void SetJumpDirectionDown()
		{
			JumpDirection = Gravity;
		}

		/// <summary>
		/// Compares <see cref="JumpDirection"/> with set <see cref="Gravity"/>.
		/// </summary>
		/// <returns>True if the <see cref="JumpDirection"/> is equal to <see cref="Gravity"/></returns>
		public bool Falling()
		{
			return JumpDirection == Gravity;
		}

		/// <summary>
		/// Compares <see cref="Gravity"/> witch <see cref="DEFAULT_GRAVITY"/>.
		/// </summary>
		/// <returns>True if <see cref="Gravity"/> is not equal to <see cref="DEFAULT_GRAVITY"/></returns>
		public bool HasReversedGravity()
		{
			return Gravity != DEFAULT_GRAVITY;
		}

		/// <summary>
		/// Decreases <see cref="JumpForceCounter"/>.
		/// </summary>
		/// <returns>True if <see cref="JumpForceCounter"/> is less than zero.</returns>
		public bool DecreaseJumpForceCounter()
		{
			JumpForceCounter -= 1;
			return JumpForceCounter <= 0;
		}

		/// <summary>
		/// Resets <see cref="JumpForceCounter"/> to value of <see cref="JumpForce"/>.
		/// </summary>
		public void ResetJumpForceCounter()
		{
			JumpForceCounter = JumpForce;
		}

		/// <summary>
		/// Performs a one timer tick of punch movement.
		/// </summary>
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

		/// <summary>
		/// Sets a <see cref="PunchSpeed"/> value.
		/// </summary>
		/// <param name="value"></param>
		public void SetPunchSpeed(int value)
		{
			PunchSpeed = value;
		}

		/// <summary>
		/// Sets a <see cref="PunchForce"/> value.
		/// </summary>
		/// <param name="value"></param>
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
