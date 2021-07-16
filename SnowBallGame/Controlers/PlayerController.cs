namespace SnowBallGame
{
	/// <summary>
	/// Class representing player's set keys contoller.
	/// </summary>
	sealed class PlayerController
	{
		/// <summary>
		/// Player's movement controller.
		/// </summary>
		public MovementController MovementContoller { get; }

		/// <summary>
		/// Player's throwment controller.
		/// </summary>
		public ThrowContoler ThrowContoler { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerController"/>
		/// </summary>
		public PlayerController() 
		{
			MovementContoller = new MovementController();
			ThrowContoler = new ThrowContoler();
		}
	}
}
