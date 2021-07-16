using System.Drawing;
using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Factory class creating instances of the class <see cref="Player"/>.
	/// </summary>
	sealed class PlayerFactory : Factory
	{
		private PlayerPanelManager playerPanel;

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerFactory"/>.
		/// </summary>
		/// <param name="gamePanel">Game panel manager.</param>
		/// <param name="playerPanel">Player panel manager.</param>
		public PlayerFactory(GamePanelManager gamePanel, PlayerPanelManager playerPanel) :base(gamePanel)
		{
			this.playerPanel = playerPanel;
		}

		/// <summary>
		/// Create an instance of the class <see cref="Player"/> with <see cref="PlayerProfile"/>.
		/// </summary>
		/// <param name="record">Record of player from initial game settings.</param>
		/// <returns>Completely set player.</returns>
		public Player CreatePlayer(PlayerCreationRecord record)
		{
			var entity = CreatePlayerEntity();

			entity.BackColor = record.Color;

			var playerProfile = CreatePlayerProfile();

			playerProfile.SetColor(record.Color);
			playerProfile.SetName(record.Name);

			playerPanel.RegisterProfile(playerProfile);

			var player = new Player(entity, playerProfile, record.Controller, record.Name);

			gamePanel.RegisterPlayer(player);

			return player;
		}

		private Control CreatePlayerEntity()
		{
			var entity = new PictureBox();
			entity.Tag = Config.PLAYER_TAG;
			
			return entity;
		}

		private PlayerProfile CreatePlayerProfile()
		{
			var playerProfilePanel = CreatePlayerProfilePanel();
			CreateHearthPictureBox(playerProfilePanel);
			var scoreLabel = CreatePlayerScoreLabel(playerProfilePanel);
			var avatar = CreatePlayerAvatarPictureBox(playerProfilePanel);
			var nameLabel = CreatePlayerNameLabel(playerProfilePanel);
			var livesLabel = CreatePlayerLivesLabel(playerProfilePanel);
			var bonusLabel = CreatePlayerBonusLabel(playerProfilePanel);
			var ballLabel = CreatePlayerBallLabel(playerProfilePanel);

			return new PlayerProfile(playerPanel, playerProfilePanel, nameLabel, scoreLabel, avatar, livesLabel, ballLabel, bonusLabel);
		}

		private Label CreatePlayerNameLabel(Panel playerProfilePanel)
		{
			var entity = new Label();
			entity.Tag = Config.PLAYER_PROFILE__NAME_TAG;
			playerProfilePanel.Controls.Add(entity);
			entity.Location = new Point(11, 11);
			entity.Height = 30;
			entity.Width = playerProfilePanel.Width;
			entity.Font = new Font(entity.Font.FontFamily, 18);

			return entity;
		}

		private Label CreatePlayerScoreLabel(Panel playerProfilePanel)
		{
			var entity = new Label();
			entity.Tag = Config.PLAYER_PROFILE__BONUS_TAG;
			playerProfilePanel.Controls.Add(entity);
			entity.Location = new Point(11, 45);
			entity.Size = new Size(150, 30);
			entity.Font = new Font(entity.Font.FontFamily, 10);

			return entity;
		}

		private PictureBox CreatePlayerAvatarPictureBox(Panel playerProfilePanel)
		{
			var entity = new PictureBox();
			entity.Tag = Config.PLAYER_PROFILE__AVATAR_TAG;
			playerProfilePanel.Controls.Add(entity);
			entity.Location = new Point(11, 69);
			entity.Width = 45;
			entity.Height = 45;

			return entity;
		}

		private void CreateHearthPictureBox(Panel playerProfilePanel)
		{
			var entity = new PictureBox();
			playerProfilePanel.Controls.Add(entity);
			entity.Location = new Point(110, 82);
			entity.Image = Properties.Resources.hearth1;
			entity.Width = 40;
			entity.Height = 33;
		}

		private Label CreatePlayerLivesLabel(Panel playerProfilePanel)
		{
			var entity = new Label();
			entity.Tag = Config.PLAYER_PROFILE__LIVES_TAG;
			playerProfilePanel.Controls.Add(entity);
			entity.Location = new Point(77, 73);
			entity.Height = 37;
			entity.Width = playerProfilePanel.Width;
			entity.Font = new Font(entity.Font.FontFamily, 30);

			return entity;
		}

		private Label CreatePlayerBallLabel(Panel playerProfilePanel)
		{
			var entity = new Label();
			entity.Tag = Config.PLAYER_PROFILE__BALL_TAG;
			playerProfilePanel.Controls.Add(entity);
			entity.Location = new Point(11, 138);
			entity.Size = new Size(150, 30);
			entity.Font = new Font(entity.Font.FontFamily, 10);

			return entity;
		}

		private Label CreatePlayerBonusLabel(Panel playerProfilePanel)
		{
			var entity = new Label();
			entity.Tag = Config.PLAYER_PROFILE__BONUS_TAG;
			playerProfilePanel.Controls.Add(entity);
			entity.Location = new Point(11, 172);
			entity.Size = new Size(150, 30);
			entity.Font = new Font(entity.Font.FontFamily, 10);

			return entity;
		}

		private Panel CreatePlayerProfilePanel()
		{
			var entity = new Panel();
			entity.Tag = Config.PLAYER_PROFILE_TAG;
			entity.Width = PlayerPanelManager.PLAYER_PANEL_WIDTH;
			entity.Height = playerPanel.Entity.Height;
			entity.BackColor = Color.Silver;

			entity.Left = playerPanel.GetLeftPosition();

			return entity;
		}
	}
}
