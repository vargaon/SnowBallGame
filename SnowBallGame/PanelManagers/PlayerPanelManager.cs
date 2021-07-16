using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Class that manages form control player_panel for generating players profiles.
	/// </summary>
	sealed class PlayerPanelManager : PanelManager
	{
		public static int PLAYER_PANEL_WIDTH = 170;
		public static int PLAYER_PROFILE_MARGINE = 40;

		/// <summary>
		/// List of players profiles generated into player_panel.
		/// </summary>
		public List<PlayerProfile> PlayersProfiles { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerPanelManager"/>.
		/// </summary>
		/// <param name="entity">Form control where players profiles will be generate.</param>
		public PlayerPanelManager(Control entity) : base(entity)
		{
			PlayersProfiles = new List<PlayerProfile>();
		}

		/// <summary>
		/// Get left position according to already generated players profiles.
		/// </summary>
		/// <returns>Control position left value.</returns>
		public int GetLeftPosition()
		{
			return PlayersProfiles.Count * (PLAYER_PANEL_WIDTH + PLAYER_PROFILE_MARGINE);
		}

		/// <summary>
		/// Registers generated player's profile into player_panel.
		/// </summary>
		/// <param name="profile">Newly created player's profile.</param>
		public void RegisterProfile(PlayerProfile profile)
		{
			Register(profile.Entity);
			PlayersProfiles.Add(profile);
		}

		/// <summary>
		/// Unregisters player's profile from player_panel.
		/// </summary>
		/// <param name="profile">Already registered player's profile.</param>
		public void UnRegisterProfile(PlayerProfile profile)
		{
			UnRegister(profile.Entity);
			PlayersProfiles.Remove(profile);
		}
	}
}
