namespace SnowBallGame
{
	/// <summary>
	/// Abstract factory class for all other factory.
	/// </summary>
	abstract class Factory
	{
		protected GamePanelManager gamePanel;

		public Factory(GamePanelManager gamePanel)
		{
			this.gamePanel = gamePanel;
		}
	}
}
