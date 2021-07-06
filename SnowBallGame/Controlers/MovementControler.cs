using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class MovementControler
	{
		public Keys Jump { get; private set; }
		public Keys Down { get; private set; }
		public Keys Left { get; private set; }
		public Keys Right { get; private set; }

		private MovementControler() { }

		public static MovementControler FromKeys(Keys Jump, Keys Down, Keys Left, Keys Right)
		{
			var controler = new MovementControler();

			controler.Jump = Jump;
			controler.Down = Down;
			controler.Left = Left;
			controler.Right = Right;

			return controler;
		}
	}
}
