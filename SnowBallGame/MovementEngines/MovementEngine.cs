using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Abstract class for other movement engines.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	abstract class MovementEngine<T>
	{
		/// <summary>
		/// Game panel manager.
		/// </summary>
		protected GamePanelManager gamePanel;

		public MovementEngine(GamePanelManager gamePanel)
		{
			this.gamePanel = gamePanel;
		}

		/// <summary>
		/// Sets a spawn position to the <see cref="Player.Entity"/>.
		/// </summary>
		/// <param name="player"></param>
		public void SetSpawnPosition(Player player)
		{
			var entity = player.Entity;
			entity.Top = (-1) * gamePanel.Margin;

			entity.Left = gamePanel.GetRandomLeftPosition();
		}

		/// <summary>
		/// Moves by moveable entity.
		/// </summary>
		/// <param name="t"></param>
		abstract public void Move(T t);

		/// <summary>
		/// Check whenever entity is out of game_panel.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>True if entity is out of panel.</returns>
		abstract protected bool OutOfGamePanel(Control entity);
	}
}
