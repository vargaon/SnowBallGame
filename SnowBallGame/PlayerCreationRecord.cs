using System.Drawing;

namespace SnowBallGame
{
	sealed class PlayerCreationRecord
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
