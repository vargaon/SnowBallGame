namespace SnowBallGame
{
	abstract class Factory
	{
		protected GamePanelManager gamePanel;

		public Factory(GamePanelManager gamePanel)
		{
			this.gamePanel = gamePanel;
		}
	}
}
