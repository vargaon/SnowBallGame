using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	sealed class PlayerPanelManager : PanelManager
	{
		public static int PLAYER_PANEL_WIDTH = 170;
		public static int PLAYER_PROFILE_MARGINE = 40;

		public List<PlayerProfile> PlayersProfiles { get; } 

		public PlayerPanelManager(Control entity) : base(entity)
		{
			PlayersProfiles = new List<PlayerProfile>();
		}

		public int GetLeftPosition()
		{
			return PlayersProfiles.Count * (PLAYER_PANEL_WIDTH + PLAYER_PROFILE_MARGINE);
		}
	}
}
