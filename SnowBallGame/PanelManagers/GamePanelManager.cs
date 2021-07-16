using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Class that manages form control game_panel for generating players, bonus and balls.
	/// </summary>
	sealed class GamePanelManager : PanelManager
	{
		private Random random;

		/// <summary>
		/// List of form controls representing platforms.
		/// </summary>
		public List<Control> Platforms { get; }

		/// <summary>
		/// List of players genereted into game_panel.
		/// </summary>
		public List<Player> Players { get; } = new List<Player>();

		/// <summary>
		/// List of balls generated into game_panel.
		/// </summary>
		public List<Ball> Balls { get; } = new List<Ball>();

		/// <summary>
		/// Bonus generated into game_panel.
		/// </summary>
		public Bonus Bonus { get; private set; }

		/// <summary>
		/// Margin of game_panel. Extends the real value of game_panel height.
		/// </summary>
		public int Margin { get; } = Config.GAME_PANEL_MARGIN;

		/// <summary>
		/// Initializes a new instance of the <see cref="GamePanelManager"/>.
		/// </summary>
		/// <param name="gamePanelEntity">Form control that contains game space.</param>
		/// <param name="random"></param>
		public GamePanelManager(Control gamePanelEntity, Random random) : base(gamePanelEntity)
		{
			this.Platforms = new List<Control>();
			this.random = random;
			RegisterPlatforms();
		}

		private void RegisterPlatforms()
		{
			foreach (Control x in Entity.Controls)
			{
				if (x.Tag != null && x.Tag.ToString() == Config.PLATFORM_TAG) Platforms.Add(x);
			}
		}

		/// <summary>
		/// Get a random left position according to registered platforms in game_panel.
		/// </summary>
		/// <returns>Control position left value.</returns>
		public int GetRandomLeftPosition()
		{
			if (Platforms.Count > 0)
			{
				var platform = Platforms[random.Next(0, Platforms.Count)];
				return random.Next(platform.Left, platform.Left + platform.Width);
			}

			return 0;
		}

		/// <summary>
		/// Get a random position on some of registered platforms in game_panel.
		/// </summary>
		/// <returns>Control position value.</returns>
		public Point GetRandomPosition()
		{
			if (Platforms.Count > 0)
			{
				var platform = Platforms[random.Next(0, Platforms.Count)];
				return new Point(random.Next(platform.Left, platform.Left + platform.Width), platform.Top);
			}

			return new Point(0,0);
		}

		/// <summary>
		/// Registers generated ball into game_panel.
		/// </summary>
		/// <param name="ball">Newly created ball.</param>
		public void RegisterBall(Ball ball)
		{
			Register(ball.Entity);
			Balls.Add(ball);
		}

		/// <summary>
		/// Unregisters ball from game_panel.
		/// </summary>
		/// <param name="ball">Already registered ball.</param>
		public void UnregisterBall(Ball ball)
		{
			UnRegister(ball.Entity);
			ball.IsActive = false;
		}

		/// <summary>
		/// Registers generated player into game_panel.
		/// </summary>
		/// <param name="player">Newly created player.</param>
		public void RegisterPlayer(Player player)
		{
			Register(player.Entity);
			Players.Add(player);
		}

		/// <summary>
		/// Unregisters player from game_panel.
		/// </summary>
		/// <param name="player">Already registered player.</param>
		public void UnregisterPlayer(Player player)
		{
			UnRegister(player.Entity);
		}

		/// <summary>
		/// Compares bonus and null.
		/// </summary>
		/// <returns>True if bonus is not null.</returns>
		public bool IsSetBonus()
		{
			return Bonus != null;
		}

		/// <summary>
		/// Registers generated bonus into game_panel.
		/// </summary>
		/// <param name="bonus">Newly created bonus.</param>
		public void RegisterBonus(Bonus bonus)
		{
			Register(bonus.Entity);
			Bonus = bonus;
		}

		/// <summary>
		/// Unregisters bonus from game_panel.
		/// </summary>
		public void UnregisterBonus()
		{
			if(IsSetBonus())
			{
				UnRegister(Bonus.Entity);
				Bonus = null;
			}
		}
	}
}
