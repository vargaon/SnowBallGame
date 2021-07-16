using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Data class representings a player's movement controller.
	/// </summary>
	sealed class MovementController
	{
		/// <summary>
		/// Keys controller to jump.
		/// </summary>
		public Keys Jump { get; set; }

		/// <summary>
		///  keys controller to go down through the platform.
		/// </summary>
		public Keys Down { get; set; }

		/// <summary>
		/// Keys controller to go left.
		/// </summary>
		public Keys Left { get; set; }

		/// <summary>
		/// Keys controller to go right.
		/// </summary>
		public Keys Right { get; set; }
	}
}
