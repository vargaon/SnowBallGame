using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Class representing a player with his characteristics.
	/// </summary>
	class Player
	{
		/// <summary>
		/// Form control assign to player instance.
		/// </summary>
		public Control Entity { get; }

		/// <summary>
		/// Player's keys controller.
		/// </summary>
		public PlayerController Controller { get; private set; }

		/// <summary>
		/// Player profile.
		/// </summary>
		public PlayerProfile Profile { get; }

		private PlayerMovement _movement;

		private PlayerMovement _bonusMovement;

		/// <summary>
		/// Player's movement.
		/// </summary>
		public PlayerMovement Movement { 
			get {
				if (_bonusMovement != null) return _bonusMovement;
				else return _movement;
			}
			set { _movement = value; }
		}

		private PlayerThrowment _throwment;

		private PlayerThrowment _bonusThrowment;

		/// <summary>
		/// Player's throwmnet.
		/// </summary>
		public PlayerThrowment Throwment {
			get
			{
				if (_bonusThrowment != null) return _bonusThrowment;
				else return _throwment;
			}
			set { _throwment = value; }
		}

		private int _size = Config.PLAYER_SIZE;

		private int? _bonusSize = null;

		/// <summary>
		/// Size of player's <see cref="Entity"/>
		/// </summary>
		public int EntitySize {
			get
			{
				if (_bonusSize != null) return _bonusSize.Value;
				else return _size;
			}
			set { _size = value; }
		}

		/// <summary>
		/// The number of remaining lives of the player.
		/// </summary>
		public int Lives { get; private set; } = Config.PLAYER_LIVES;

		/// <summary>
		/// The number of points a player has earned during the game.
		/// </summary>
		public int Score { get; private set; }

		/// <summary>
		/// Player's name.
		/// </summary>
		public string Name { get; }

		private int _bonusDuration = Config.PLAYER_BONUS_DURATION;

		private int _bonusDurationCounter;

		/// <summary>
		/// Initializes a new instance of the <see cref="Player"/>.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/></param>
		/// <param name="profile"><see cref="Profile"/></param>
		/// <param name="controller"><see cref="Controller"/></param>
		/// <param name="playerName"><see cref="Name"/></param>
		public Player(Control entity, PlayerProfile profile, PlayerController controller, string playerName)
		{
			this.Controller = controller;
			this.Entity = entity;
			this.Profile = profile;
			this.Name = playerName;

			this.Profile.UpdateLives(this.Lives);

			this.Movement = new PlayerMovement();
			this.Throwment = new PlayerThrowment();

			UpdateEntitySize();
		}

		/// <summary>
		/// Sets player's entity size.
		/// Entity is the squre, method sets its width and height.
		/// </summary>
		/// <param name="value">Entity size in pixels.</param>
		public void SetEntitySize(int value)
		{
			this.EntitySize = value;
			UpdateEntitySize();
		}

		/// <summary>
		/// Sets bonus movement.
		/// If bonus movement is set <see cref="Movement"/> returns it.
		/// </summary>
		/// <param name="movement">Movement with new values.</param>
		public void SetBonusMovement(PlayerMovement movement)
		{
			_bonusMovement = movement;
			ResetBonusDurationCounter();
		}

		/// <summary>
		/// Sets bonus throwment.
		/// If bonus throwment is set <see cref="Throwment"/> returns it.
		/// </summary>
		/// <param name="throwment">Throwment with new values.</param>
		public void SetBonusThrowment(PlayerThrowment throwment)
		{
			_bonusThrowment = throwment;
		}

		/// <summary>
		/// Sets bonus entity size.
		/// If bonus size is set <see cref="EntitySize"/> returns it.
		/// </summary>
		/// <param name="value">Value can be null, then bonus size is not set.</param>
		public void SetBonusSize(int? value)
		{
			_bonusSize = value;
			UpdateEntitySize();
			ResetBonusDurationCounter();
		}

		/// <summary>
		/// Unsets bonus movement and size. Rerender player's profile bonus info.
		/// </summary>
		public void ResetPlayerBonus()
		{
			if (_bonusMovement != null)
			{
				_movement.SetSameDirection(_bonusMovement);
				if (_bonusMovement.HasReversedGravity()) Entity.Top += 1;
			}

			SetBonusMovement(null);
			SetBonusSize(null);

			Profile.UpdateBonus(PlayerProfile.DEFAULT_BONUS);
		}

		/// <summary>
		/// Unsets bonus throwment. Rerender player profile ball bonus info.
		/// </summary>
		public void ResetBonusThrowment()
		{
			SetBonusThrowment(null);
			Profile.UpdateBall(PlayerProfile.DEFAUL_BALL);
		}

		private void UpdateEntitySize()
		{
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;
		}

		/// <summary>
		/// Decreases number of player's lives.
		/// Updates player's lives info in his profile.
		/// </summary>
		/// <returns>True if player has zero lives.</returns>
		public bool LoseLive()
		{
			this.Lives -= 1;

			Profile.UpdateLives(this.Lives);
			return Lives <= 0;
		}

		/// <summary>
		/// Increases number of player's lives.
		/// Updates player's lives info in his profile.
		/// </summary>
		public void AddLive()
		{
			this.Lives += 1;
			Profile.UpdateLives(this.Lives);
		}

		/// <summary>
		/// Sets bonus duration counter to default value.
		/// </summary>
		public void ResetBonusDurationCounter()
		{
			_bonusDurationCounter = _bonusDuration;
		}


		/// <summary>
		/// Helper method for counting bonus duration counter.
		/// </summary>
		/// <returns>True if counter is zero.</returns>
		public bool DecreaseBonusDurationCounter()
		{
			_bonusDurationCounter -= 1;
			return _bonusDurationCounter <= 0;
		}

		/// <summary>
		/// Updates player's score after hit enemy player.
		/// </summary>
		public void HitScore()
		{
			Score += Config.HIT_SCORE;
			Profile.UpdateScore(Score);
		}

		/// <summary>
		/// Updates player's score after collect bonus.
		/// </summary>
		public void ColectBonusScore()
		{
			Score += Config.BONUS_COLECT_SCORE;
			Profile.UpdateScore(Score);
		}

		/// <summary>
		/// Updates player's score after fall down out of game panel.
		/// </summary>
		public void FallDownScore()
		{
			if (Score - Config.LOSE_LIVE_SCORE > 0) Score -= Config.LOSE_LIVE_SCORE;
			else Score = 0;

			Profile.UpdateScore(Score);
		}
	}
}
