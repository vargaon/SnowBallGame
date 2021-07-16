using System.Drawing;

namespace SnowBallGame
{
	/// <summary>
	/// Class representing a player's settings record.
	/// </summary>
	sealed class PlayerCreationRecord
	{
		/// <summary>
		/// Player's set name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Player's set color.
		/// </summary>
		public Color Color { get; set; }

		/// <summary>
		/// Flag for adding new player to game.
		/// </summary>
		public bool Active { get; set; }

		/// <summary>
		/// Player's set keys controller.
		/// </summary>
		public PlayerController Controller { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerCreationRecord"/>.
		/// </summary>
		/// <param name="active"><see cref="Active"/></param>
		public PlayerCreationRecord(bool active)
		{
			Active = active;
			Controller = new PlayerController();
		}
	}
}
