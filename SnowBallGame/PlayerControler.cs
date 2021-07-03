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
		
		public Keys Throw { get; private set; }

		private PlayerControler() { }

		static public PlayerControler FromKeys(Keys Up, Keys Down, Keys Left, Keys Right, Keys Throw)
		{
			var controler = new PlayerControler();

			controler.Up = Up;
			controler.Down = Down;
			controler.Left = Left;
			controler.Right = Right;
			controler.Throw = Throw;

			return controler;
		}
	}
}
