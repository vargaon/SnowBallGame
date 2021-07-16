using System.Drawing;
using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Class representing player's profile card.
	/// </summary>
	sealed class PlayerProfile
	{
		private PlayerPanelManager _playerPanel;

		public Panel Entity { get; }

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

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerProfile"/>.
		/// </summary>
		/// <param name="playerPanel">Panel manager managing form control where players profiles will be generate.</param>
		/// <param name="playerProfileContainer">Form control representing profile card.</param>
		/// <param name="nameLabel">Form control with player's name.</param>
		/// <param name="scoreLabel">Form control with player's score.</param>
		/// <param name="avatar">Form control with player's color.</param>
		/// <param name="livesLabel">Form control with player's lives.</param>
		/// <param name="ballLabel">Form control with ball bonus name.</param>
		/// <param name="bonusLabel">Form control with bonus name.</param>
		public PlayerProfile(PlayerPanelManager playerPanel, Panel playerProfileContainer, Label nameLabel, Label scoreLabel,
			PictureBox avatar, Label livesLabel, Label ballLabel, Label bonusLabel)
		{
			this._playerPanel = playerPanel;
			this.Entity = playerProfileContainer;
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

		/// <summary>
		/// Set a player name to profile nameLabel.
		/// </summary>
		/// <param name="value"></param>
		public void SetName(string value)
		{
			_nameLabel.Text = value;
		}

		/// <summary>
		/// Set a color in profile to player avatar.
		/// </summary>
		/// <param name="c"></param>
		public void SetColor(Color c)
		{
			_avatar.BackColor = c;
		}

		/// <summary>
		/// Updates lives value in profile livesLabel.
		/// </summary>
		/// <param name="value"></param>
		public void UpdateLives(int value)
		{
			_livesLabel.Text = value.ToString();
		}

		/// <summary>
		/// Updates bonus value in profile bonusLabel.
		/// </summary>
		/// <param name="value"></param>
		public void UpdateBonus(string value)
		{
			_bonusLabel.Text = BONUS_PREFIX + value;
		}

		/// <summary>
		/// Updates score value in profile scoreLabel.
		/// </summary>
		/// <param name="value"></param>
		public void UpdateScore(int value)
		{
			_scoreLabel.Text = SCORE_PREFIX + value.ToString();
		}

		/// <summary>
		/// Updates ball value in profile ballLabel.
		/// </summary>
		/// <param name="value"></param>
		public void UpdateBall(string value)
		{
			_ballLabel.Text = BALL_PREFIX + value;
		}

		/// <summary>
		/// Remove player profile from player panel manager.
		/// </summary>
		public void UnRegister()
		{
			_playerPanel.UnRegisterProfile(this);
		}
	}
}
