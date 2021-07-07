using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerProfile
	{
		Panel _playerProfileContainer;
		Label _nameLabel;
		PictureBox _avatar;
		Label _livesLabel;
		Label _ballLabel;
		Label _bonusLabel;

		public static string BALL_PREFIX = "Ball: ";
		public static string BONUS_PREFIX = "Bonus: ";

		public static string DEFAUL_BALL = "SnowBall";
		public static string DEFAULT_BONUS = "None";

		public PlayerProfile(Panel playerProfileContainer, Label nameLabel, PictureBox avatar, Label livesLabel, Label ballLabel, Label bonusLabel)
		{
			this._playerProfileContainer = playerProfileContainer;
			this._nameLabel = nameLabel;
			this._avatar = avatar;
			this._livesLabel = livesLabel;
			this._ballLabel = ballLabel;
			this._bonusLabel = bonusLabel;

			UpdateBall(DEFAUL_BALL);
			UpdateBonus(DEFAULT_BONUS);
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

		public void UpdateBall(string value)
		{
			_ballLabel.Text = BALL_PREFIX + value;
		}

		public void Hide()
		{
			_playerProfileContainer.Visible = false;
		}
	}
}
