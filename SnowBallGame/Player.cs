using System.Windows.Forms;

namespace SnowBallGame
{
	class Player
	{
		public Control Entity { get; }

		public PlayerControler Controler { get; private set; }

		public PlayerProfile Profile { get; }

		private PlayerMovement _movement;

		private PlayerMovement _bonusMovement;

		public PlayerMovement Movement { 
			get {
				if (_bonusMovement != null) return _bonusMovement;
				else return _movement;
			}
			set { _movement = value; }
		}

		PlayerThrowment _throwment;

		PlayerThrowment _bonusThrowment;

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

		public int EntitySize {
			get
			{
				if (_bonusSize != null) return _bonusSize.Value;
				else return _size;
			}
			set { _size = value; }
		} 

		public int Lives { get; private set; } = Config.PLAYER_LIVES;

		public int Score { get; private set; }

		public string Name { get; }

		private int _bonusDuration = Config.PLAYER_BONUS_DURATION;

		private int _bonusDurationCounter;

		public Player(Control entity, PlayerProfile profile, PlayerControler controler, string playerName)
		{
			this.Controler = controler;
			this.Entity = entity;
			this.Profile = profile;
			this.Name = playerName;

			this.Profile.UpdateLives(this.Lives);

			this.Movement = new PlayerMovement();
			this.Throwment = new PlayerThrowment();

			UpdateEntitySize();
		}

		public void SetEntitySize(int value)
		{
			this.EntitySize = value;
			UpdateEntitySize();
		}

		public void SetBonusMovement(PlayerMovement movement)
		{
			_bonusMovement = movement;
			ResetBonusDurationCounter();
		}

		public void SetBonusThrowment(PlayerThrowment throwment)
		{
			_bonusThrowment = throwment;
		}

		public void SetBonusSize(int? value)
		{
			_bonusSize = value;
			UpdateEntitySize();
			ResetBonusDurationCounter();
		}

		public void ResetBonusMovement()
		{
			SetBonusMovement(null);
			SetBonusSize(null);
			Profile.UpdateBonus(PlayerProfile.DEFAULT_BONUS);
		}

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

		public bool LoseLive()
		{
			this.Lives -= 1;

			if (Score - Config.LOSE_LIVE_SCORE > 0) Score -= Config.LOSE_LIVE_SCORE;
			else Score = 0;

			Profile.UpdateScore(Score);
			Profile.UpdateLives(this.Lives);
			return Lives <= 0;
		}

		public void AddLive()
		{
			this.Lives += 1;
			Profile.UpdateLives(this.Lives);
		}

		public void ResetBonusDurationCounter()
		{
			_bonusDurationCounter = _bonusDuration;
		}

		public bool DecreaseBonusDurationCounter()
		{
			_bonusDurationCounter -= 1;
			return _bonusDurationCounter <= 0;
		}

		public void HitScore()
		{
			Score += Config.HIT_SCORE;
			Profile.UpdateScore(Score);
		}

		public void ColectBonusScore()
		{
			Score += Config.BONUS_COLECT_SCORE;
			Profile.UpdateScore(Score);
		}
	}
}
