using System.Drawing;
using System.Windows.Forms;

namespace SnowBallGame
{
	sealed class PlayerProfile
	{
		private PlayerPanelManager _playerPanel;
		private Panel _playerProfileContainer;
		private Label _nameLabel;
		private Label _scoreLabel;
		private PictureBox _avatar;
		private Label _livesLabel;
		private Label _ballLabel;
		private Label _bonusLabel;

		public static string BALL_PREFIX = "Ball: ";
		public static string BONUS_PREFIX = "Bonus: ";
		public static string SCORE_PREFIX = "Score: ";

		public static string DEFAUL_BALL = "SnowBall";
		public static string DEFAULT_BONUS = "None";
		public static int DEFAULT_SCORE = 0;

		public PlayerProfile(PlayerPanelManager playerPanel, Panel playerProfileContainer, Label nameLabel, Label scoreLabel,
			PictureBox avatar, Label livesLabel, Label ballLabel, Label bonusLabel)
		{
			this._playerPanel = playerPanel;
			this._playerProfileContainer = playerProfileContainer;
			this._nameLabel = nameLabel;
			this._scoreLabel = scoreLabel;
			this._avatar = avatar;
			this._livesLabel = livesLabel;
			this._ballLabel = ballLabel;
			this._bonusLabel = bonusLabel;

			UpdateBall(DEFAUL_BALL);
			UpdateBonus(DEFAULT_BONUS);
			UpdateScore(DEFAULT_SCORE);
		}

		public void SetName(string value)
		{
			_nameLabel.Text = value;
		}

		public void SetColor(Color c)
		{
			_avatar.BackColor = c;
		}

		public void UpdateLives(int value)
		{
			_livesLabel.Text = value.ToString();
		}

		public void UpdateBonus(string value)
		{
			_bonusLabel.Text = BONUS_PREFIX + value;
		}

		public void UpdateScore(int value)
		{
			_scoreLabel.Text = SCORE_PREFIX + value.ToString();
		}

		public void UpdateBall(string value)
		{
			_ballLabel.Text = BALL_PREFIX + value;
		}

		public void UnRegister()
		{
			_playerPanel.UnRegister(_playerProfileContainer);
		}

	}
}
