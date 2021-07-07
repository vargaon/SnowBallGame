using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBallGame
{
	class PlayerThrowment
	{
		private int throwWait = 10;

		private int throwWaitCounter;

		private Func<Ball> thrownBall;

		public bool CanThrow { get; private set; }

		public PlayerThrowment()
		{
			this.CanThrow = true;
			ResetThrowWaitCounter();
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

			DecreaseThrowWaitCounter();
			if(throwWaitCounter <= 0)
			{
				this.CanThrow = true;
				ResetThrowWaitCounter();
			}
		}

		private void DecreaseThrowWaitCounter()
		{
			throwWaitCounter -= 1;
		}

		private void ResetThrowWaitCounter()
		{
			throwWaitCounter = throwWait;
		}

		public void SetThrowWait(int value)
		{
			this.throwWait = value;
		}
	}
}
