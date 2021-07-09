using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowBallGame
{
	class PlayerCreationRecord
	{
		public string Name { get; set; }
		public Color Color { get; set; }
		public bool Active { get; set; }
		public PlayerControler Controler { get; }

		public PlayerCreationRecord(bool active)
		{
			Active = active;
			Controler = new PlayerControler();
		}
	}
}
