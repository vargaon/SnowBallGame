using System.Windows.Forms;

namespace SnowBallGame
{
	class ThrowContoler
	{
		public Keys Throw { get; private set; }

		private ThrowContoler() { }

		public static ThrowContoler FromKeys(Keys Throw)
		{
			var controler = new ThrowContoler();
			controler.Throw = Throw;

			return controler;
		}
	}
}
