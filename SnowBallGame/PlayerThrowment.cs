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

		public bool CanThrow { get; set; } = true;

		public PlayerThrowment()
		{
			ResetThrowSpeedCounter();
		}

		public void ThrowTick()
		{
			if (CanThrow) return;

			DecreaseThrowSpeedCounter();
			if(throwWaitCounter < 0)
			{
				CanThrow = true;
				ResetThrowSpeedCounter();
			}
		}

		private void DecreaseThrowSpeedCounter()
		{
			throwWaitCounter -= 1;
		}

		private void ResetThrowSpeedCounter()
		{
			throwWaitCounter = throwWait;
		}
	}
}
