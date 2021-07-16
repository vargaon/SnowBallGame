using System.Drawing;

namespace SnowBallGame
{
	/// <summary>
	/// Configuration class.
	/// </summary>
	static class Config
	{
		//game
		public static int BONUS_SPAWN_DELAY_TIME = 400;

		//game panel
		public static int GAME_PANEL_MARGIN = 100;

		//player
		public static int PLAYER_LIVES = 3;
		public static int PLAYER_SIZE = 25;
		public static int PLAYER_BONUS_DURATION = 300;
		public static int HIT_SCORE = 5;
		public static int BONUS_COLECT_SCORE = 2;
		public static int LOSE_LIVE_SCORE = 4;

		//bonus
		public static int BONUS_SIZE = 10;

		//movement
		public static int DEFAULT_DIRECTION = 1;

		//player movement
		public static int PLAYER_MOVE_SPEED = 10;
		public static int PLAYER_JUMP_SPEED = 12;
		public static int PLAYER_JUMP_FORCE = 7;
		public static int PLAYER_PUNCH_FORCE = 4;

		//player throwment
		public static int PLAYER_STACK_AMOUNT = 8;
		public static int PLAYER_THROW_WAIT = 10;


		//controls tags
		public static string PLAYER_TAG = "player";
		public static string BONUS_TAG = "bonus";
		public static string BALL_TAG = "ball";
		public static string PLATFORM_TAG = "platform";
		public static string PLAYER_PROFILE_TAG = "player_profile";
		public static string PLAYER_PROFILE__NAME_TAG = "player_name";
		public static string PLAYER_PROFILE__AVATAR_TAG = "player_avatar";
		public static string PLAYER_PROFILE__LIVES_TAG = "player_lives";
		public static string PLAYER_PROFILE__BALL_TAG = "player_ball";
		public static string PLAYER_PROFILE__BONUS_TAG = "player_bonus";

		//Balls

		//snowball
		public static int SNOW_BALL_SIZE = 15;
		public static int SNOW_BALL_PUNCH_FORCE = 20;
		public static int SNOW_BALL_MOVE_SPEED = 15;
		public static Color SNOW_BALL_COLOR = Color.White;

		//jellyball
		public static int JELLY_BALL_SIZE = 30;
		public static int JELLY_BALL_PUNCH_FORCE = 10;
		public static int JELLY_BALL_MOVE_SPEED = 10;
		public static Color JELLY_BALL_COLOR = Color.HotPink;

		//speedball
		public static int SPEED_BALL_SIZE = 10;
		public static int SPEED_BALL_PUNCH_FORCE = 40;
		public static int SPEED_BALL_MOVE_SPEED = 30;
		public static Color SPEED_BALL_COLOR = Color.Yellow;

		//Bonuses

		//extra live
		public static string EXTRA_LIVE_NAME = "ExtraLive";
		public static Color EXTRA_LIVE_COLOR = Color.Red;

		//giant size
		public static string GIANT_SIZE_NAME = "GiantSize";
		public static Color GIANT_SIZE_COLOR = Color.Purple;
		public static int GIANT_SIZE_PLAYER_SIZE = 35;
		public static int GIANT_SIZE_PLAYER_MOVE_SPEED = 7;

		//dwarf size
		public static string DWARF_SIZE_NAME = "DwarfSize";
		public static Color DWARF_SIZE_COLOR = Color.Purple;
		public static int DWARF_SIZE_PLAYER_SIZE = 15;
		public static int DWARF_SIZE_PLAYER_MOVE_SPEED = 15;

		//jump boost
		public static string JUMP_BOOST_NAME = "JumpBoost";
		public static Color JUMP_BOOST_COLOR = Color.Blue;
		public static int JUMP_BOOST_JUMP_FORCE = 10;
		public static int JUMP_BOOST_JUMP_SPEED = 15;

		//protection
		public static string PROTECTION_NAME = "Protection";
		public static Color PROTECTION_COLOR = Color.Green;
		public static int PROTECTION_PUNCH_FORCE = 1;

		//reverse gravity
		public static string REVERSE_GRAVITY_NAME = "RevGravity";
		public static Color REVERSE_GRAVITY_COLOR = Color.White;

		//ball bonus
		public static Color BALL_BONUS_COLOR = Color.Gold;

		//balls names
		public static string JELLYBALL_NAME = "JellyBall";
		public static string SPEEDBALL_NAME = "SpeedBall";
	}
}
