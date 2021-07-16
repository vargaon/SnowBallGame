using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Factory class creating descendants of the class <see cref="Bonus"/>.
	/// </summary>
	sealed class BonusFactory
	{
		private GamePanelManager _gamePanel;

		private int _entitySize = Config.BONUS_SIZE;

		private List<Func<Control, Bonus>> _bonuses;

		private Random random;

		/// <summary>
		/// Initializes a new instance of the <see cref="BonusFactory"/>.
		/// </summary>
		/// <param name="gamePanel">Game panel manager.</param>
		/// <param name="ballFactory">Ball factory instace for creating ball bonus.</param>
		/// <param name="bonusSettings">Additional bonuses settings.</param>
		/// <param name="random"></param>
		public BonusFactory(GamePanelManager gamePanel, BallFactory ballFactory, Dictionary<string, bool> bonusSettings, Random random)
		{
			this._gamePanel = gamePanel;
			this.random = random;

			InitializeAvailableBonuses(ballFactory, bonusSettings);
		}

		/// <summary>
		/// Create a random bonus according to bonuses settings.
		/// </summary>
		/// <returns></returns>
		public Bonus CreateRandomBonus()
		{
			if (_bonuses.Count <= 0) return null;
			var entity = CreateBonusEntity();
			var getBonus = _bonuses[random.Next(0, _bonuses.Count)];
			var bonus = getBonus(entity);
			_gamePanel.RegisterBonus(bonus);

			return bonus;
		}

		private Control CreateBonusEntity()
		{
			var entity = new Label();
			entity.Tag = Config.BONUS_TAG;
			entity.Location = _gamePanel.GetRandomPosition();
			entity.Top -= _entitySize + 10;
			entity.Height = _entitySize;
			entity.Width = _entitySize;

			return entity;
		}

		private void InitializeAvailableBonuses(BallFactory ballFactory, Dictionary<string, bool> bonusesSettings)
		{
			this._bonuses = new List<Func<Control, Bonus>>();

			if (bonusesSettings[Config.GIANT_SIZE_NAME]) _bonuses.Add(e => new GiantSizeBonus(e));
			if (bonusesSettings[Config.DWARF_SIZE_NAME]) _bonuses.Add(e => new DwarfSizeBonus(e));
			if (bonusesSettings[Config.EXTRA_LIVE_NAME]) _bonuses.Add(e => new ExtraLiveBonus(e));
			if (bonusesSettings[Config.JUMP_BOOST_NAME]) _bonuses.Add(e => new JumpBoostBonus(e));
			if (bonusesSettings[Config.PROTECTION_NAME]) _bonuses.Add(e => new ProtectionBonus(e));
			if (bonusesSettings[Config.REVERSE_GRAVITY_NAME]) _bonuses.Add(e => new ReverseGravity(e));
			if (bonusesSettings[Config.JELLYBALL_NAME]) _bonuses.Add(e => new BallBonus<JellyBall>(e, ballFactory));
			if (bonusesSettings[Config.SPEEDBALL_NAME]) _bonuses.Add(e => new BallBonus<SpeedBall>(e, ballFactory));
		}
	}
}
