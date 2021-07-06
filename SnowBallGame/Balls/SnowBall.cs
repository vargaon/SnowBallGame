using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBallGame
{
	class SnowBall : Ball
	{
		public SnowBall()
		{
			EntitySize = 15;
			PunchForce = 20;
			BallColor = Color.White;
			Movement = new BallMovement(15);
		}
	}
}
