﻿using System.Windows.Forms;

namespace SnowBallGame
{
	sealed class PlayerControler
	{
		public MovementControler MovementContoler { get; }
		public ThrowContoler ThrowContoler { get; }

		public PlayerControler() 
		{
			MovementContoler = new MovementControler();
			ThrowContoler = new ThrowContoler();
		}
	}
}
