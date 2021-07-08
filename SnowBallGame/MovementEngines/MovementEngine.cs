using System.Windows.Forms;

namespace SnowBallGame
{
	abstract class MovementEngine<T>
	{
		protected GamePanelManager gamePanel;

		public MovementEngine(GamePanelManager gamePanel)
		{
			this.gamePanel = gamePanel;
		}

		public void SetSpawnPosition(Player player)
		{
			var entity = player.Entity;
			entity.Top = (-1) * gamePanel.Margin;
			entity.Left = gamePanel.GetRandomLeftPosition();
		}

		abstract public void Move(T t);
		abstract protected bool OutOfGamePanel(Control entity);
	}
}
