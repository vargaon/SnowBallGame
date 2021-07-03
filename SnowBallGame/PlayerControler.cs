using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerControler
	{
		public Keys Up { get; private set; }
		public Keys Down { get; private set; }
		public Keys Left { get; private set; }
		public Keys Right { get; private set; }

		private PlayerControler() { }

		static public PlayerControler FromKeys(Keys up, Keys down, Keys left, Keys right)
		{
			var controler = new PlayerControler();

			controler.Up = up;
			controler.Down = down;
			controler.Left = left;
			controler.Right = right;

			return controler;
		}
	}
}
