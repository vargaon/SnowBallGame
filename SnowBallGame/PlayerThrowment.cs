using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBallGame
{
	class PlayerThrowment
	{
		private int throwWait = 15;

		private int throwWaitCounter;

		private int stackAmount = 10;

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

			;
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
