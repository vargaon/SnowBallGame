using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerPanelManager
	{
		public static string PLAYER_PROFILE_TAG = "player_profile";
		public static string PLAYER_PROFILE__NAME_TAG = "player_name";
		public static string PLAYER_PROFILE__AVATAR_TAG = "player_avatar";
		public static string PLAYER_PROFILE__LIVES_TAG = "player_lives";
		public static string PLAYER_PROFILE__BALL_TAG = "player_ball";
		public static string PLAYER_PROFILE__BONUS_TAG = "player_bonus";

		public static int PLAYER_PANEL_WIDTH = 170;

		public Control Entity { get; }

		public List<PlayerProfile> PlayersProfiles { get; } = new List<PlayerProfile>();

		public PlayerPanelManager(Control entity)
		{
			this.Entity = entity;
		}

		public int GetLeftPosition()
		{
			return PlayersProfiles.Count * (PLAYER_PANEL_WIDTH + 25);
		}

		public void Register(Control entity)
		{
			Entity.Controls.Add(entity);
		}
	}
}
