using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBallGame
{
	class SpeedBall : Ball
	{
		public SpeedBall()
		{
			EntitySize = 10;
			PunchForce = 40;
			BallColor = Color.Yellow;
			Movement = new BallMovement(30);
		}
	}
}
