using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerControler
	{
		public MovementControler MovementContoler { get; private set; }
		public ThrowContoler ThrowContoler { get; private set; }

		private PlayerControler() { }

		static public PlayerControler FromKeys(Keys Jump, Keys Down, Keys Left, Keys Right, Keys Throw)
		{
			var controler = new PlayerControler();

			controler.MovementContoler = MovementControler.FromKeys(Jump, Down, Left, Right);
			controler.ThrowContoler = ThrowContoler.FromKeys(Throw);

			return controler;
		}
	}
}
