using System;

namespace SnowBallGame
{
	class PlayerThrowment
	{
		private int throwWait = Config.PLAYER_THROW_WAIT;

		private int throwWaitCounter;

		private int stackAmount = Config.PLAYER_STACK_AMOUNT;

		private int stackAmountCounter;

		private Func<Ball> thrownBall;

		public bool CanThrow { get; private set; }

		public PlayerThrowment()
		{
			this.CanThrow = true;
			ResetThrowWaitCounter();
			ResetStackAmountCounter();
		}

		public Ball ThrowBall()
		{
			this.CanThrow = false;
			return thrownBall();
		}

		public void SetThrownBall(Func<Ball> thrownBall)
		{
			this.thrownBall = thrownBall;
		}

		public void ThrowTick()
		{
			if (this.CanThrow) return;

			if(DecreaseThrowWaitCounter())
			{
				this.CanThrow = true;
				ResetThrowWaitCounter();
			}
		}

		private bool DecreaseThrowWaitCounter()
		{
			throwWaitCounter -= 1;
			return throwWaitCounter <= 0;
		}

		private void ResetThrowWaitCounter()
		{
			throwWaitCounter = throwWait;
		}

		public bool DecreaseStackAmountCounter()
		{
			stackAmountCounter -= 1;
			return stackAmountCounter <= 0;
		}

		public void ResetStackAmountCounter()
		{
			stackAmountCounter = stackAmount;
		}

		public void SetThrowWait(int value)
		{
			this.throwWait = value;
		}

		public void HoldAThrow()
		{
			CanThrow = false;
			ResetThrowWaitCounter();
		}
	}
}
