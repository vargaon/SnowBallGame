using System.Drawing;
using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerFactory : Factory
	{
		private PlayerPanelManager playerPanel;

		public PlayerFactory(GamePanelManager gamePanel, PlayerPanelManager playerPanel) :base(gamePanel)
		{
			this.playerPanel = playerPanel;
		}

		public Player CreatePlayer(PlayerCreationRecord record)
		{
			var entity = CreatePlayerEntity();

			entity.BackColor = record.Color;

			var playerProfile = CreatePlayerProfile();

			playerProfile.SetColor(record.Color);
			playerProfile.SetName(record.Name); 

			playerPanel.PlayersProfiles.Add(playerProfile);

			return new Player(entity, playerProfile, record.Controler, record.Name);
		}

		private Control CreatePlayerEntity()
		{
			var entity = new PictureBox();
			gamePanel.Register(entity);
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
			entity.Image = Properties.Resources.hearth;
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
			playerPanel.Register(entity);
			entity.Width = 170;
			entity.Height = playerPanel.Entity.Height;
			entity.BackColor = Color.Silver;

			entity.Left = playerPanel.GetLeftPosition();

			return entity;
		}
	}
}
