using System;

namespace SnowBallGame
{
	sealed class PlayerThrowment
	{
		private int _throwWait = Config.PLAYER_THROW_WAIT;

		private int _throwWaitCounter;

		private int _stackAmount = Config.PLAYER_STACK_AMOUNT;

		private int _stackAmountCounter;

		private Func<Ball> _thrownBall;

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
			return _thrownBall();
		}

		public void SetThrownBall(Func<Ball> thrownBall)
		{
			this._thrownBall = thrownBall;
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
			_throwWaitCounter -= 1;
			return _throwWaitCounter <= 0;
		}

		private void ResetThrowWaitCounter()
		{
			_throwWaitCounter = _throwWait;
		}

		public bool DecreaseStackAmountCounter()
		{
			_stackAmountCounter -= 1;
			return _stackAmountCounter <= 0;
		}

		public void ResetStackAmountCounter()
		{
			_stackAmountCounter = _stackAmount;
		}

		public void SetThrowWait(int value)
		{
			this._throwWait = value;
		}

		public void HoldAThrow()
		{
			CanThrow = false;
			ResetThrowWaitCounter();
		}
	}
}
