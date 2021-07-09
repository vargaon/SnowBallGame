using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	sealed class BonusFactory
	{
		private GamePanelManager _gamePanel;

		private int _entitySize = Config.BONUS_SIZE;

		private Dictionary<string, bool> _bonusesSettings;

		private List<Func<Control, Bonus>> _bonuses;

		private Random random;

		public BonusFactory(GamePanelManager gamePanel, BallFactory ballFactory, Dictionary<string, bool> bonusSettings, Random random)
		{
			this._gamePanel = gamePanel;
			this._bonusesSettings = bonusSettings;
			this.random = random;

			InitializeAvailableBonuses(ballFactory);
		}

		public Bonus CreateRandomBonus()
		{
			if (_bonuses.Count <= 0) return null;
			var entity = CreateBonusEntity();
			var getBonus = _bonuses[random.Next(0, _bonuses.Count)];
			return getBonus(entity);
		}

		private Control CreateBonusEntity()
		{
			var entity = new Label();
			entity.Tag = Config.BONUS_TAG;
			entity.Location = _gamePanel.GetRandomPosition();
			entity.Top -= _entitySize + 10;
			entity.Height = _entitySize;
			entity.Width = _entitySize;

			_gamePanel.Register(entity);

			return entity;
		}

		private void InitializeAvailableBonuses(BallFactory ballFactory)
		{
			this._bonuses = new List<Func<Control, Bonus>>();

			if (_bonusesSettings[Config.GIANT_SIZE_NAME]) _bonuses.Add(e => new GiantSizeBonus(e));
			if (_bonusesSettings[Config.DWARF_SIZE_NAME]) _bonuses.Add(e => new DwarfSizeBonus(e));
			if (_bonusesSettings[Config.EXTRA_LIVE_NAME]) _bonuses.Add(e => new ExtraLiveBonus(e));
			if (_bonusesSettings[Config.JUMP_BOOST_NAME]) _bonuses.Add(e => new JumpBoostBonus(e));
			if (_bonusesSettings[Config.PROTECTION_NAME]) _bonuses.Add(e => new ProtectionBonus(e));
			if (_bonusesSettings[Config.JELLYBALL_NAME]) _bonuses.Add(e => new BallBonus<JellyBall>(e, ballFactory));
			if (_bonusesSettings[Config.SPEEDBALL_NAME]) _bonuses.Add(e => new BallBonus<SpeedBall>(e, ballFactory));
		}
	}
}
