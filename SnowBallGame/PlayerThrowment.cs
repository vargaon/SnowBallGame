using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBallGame
{
	class PlayerThrowment
	{
		public int ThrowSpeed { get; private set; } = 15;

		public int ThrowSpeedCounter { get; private set; }

		public bool CanThrow { get; set; } = true;

		public PlayerThrowment()
		{
			ResetThrowSpeedCounter();
		}

		public void DecreaseThrowSpeedCounter()
		{
			ThrowSpeedCounter -= 1;
		}

		public void ResetThrowSpeedCounter()
		{
			ThrowSpeedCounter = ThrowSpeed;
		}
	}
}
