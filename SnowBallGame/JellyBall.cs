using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnowBallGame
{
	class JellyBall : Ball
	{
		public JellyBall()
		{
			EntitySize = 30;
			PunchForce = 10;
			BallColor = Color.HotPink;
			Movement = new BallMovement(10);
		}
	}
}
