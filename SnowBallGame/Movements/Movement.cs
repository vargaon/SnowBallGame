using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBallGame
{
	abstract class Movement
	{
		public int MoveSpeed { get; private set; }

		public int Direction { get; private set; } = 1;

		public Movement()
		{
		}

		public void SetMoveSpeed(int value)
		{
			MoveSpeed = value;
		}

		public void SetDirectionLeft()
		{
			Direction = -1;
		}

		public void SetDirectionRight()
		{
			Direction = 1;
		}
	}
}
