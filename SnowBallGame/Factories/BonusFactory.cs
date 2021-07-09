using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	class BonusFactory
	{
		GamePanelManager gamePanel;

		private int entitySize = Config.BONUS_SIZE;

		private Dictionary<string, bool> _bonusesSettings;

		List<Func<Control, Bonus>> bonuses;

		Random random;

		public BonusFactory(GamePanelManager gamePanel, BallFactory ballFactory, Dictionary<string, bool> bonusSettings, Random random)
		{
			this.gamePanel = gamePanel;
			this._bonusesSettings = bonusSettings;
			this.random = random;

			InitializeAvailableBonuses(ballFactory);
		}

		public Bonus CreateRandomBonus()
		{
			var entity = CreateBonusEntity();
			var getBonus = bonuses[random.Next(0, bonuses.Count)];
			return getBonus(entity);
		}

		private Control CreateBonusEntity()
		{
			var entity = new Label();
			entity.Tag = Config.BONUS_TAG;
			entity.Location = gamePanel.GetRandomPosition();
			entity.Top -= entitySize + 10;
			entity.Height = entitySize;
			entity.Width = entitySize;

			gamePanel.Register(entity);

			return entity;
		}

		private void InitializeAvailableBonuses(BallFactory ballFactory)
		{
			this.bonuses = new List<Func<Control, Bonus>>();

			if (_bonusesSettings[Config.GIANT_SIZE_NAME]) bonuses.Add(e => new GiantSizeBonus(e));
			if (_bonusesSettings[Config.DWARF_SIZE_NAME]) bonuses.Add(e => new DwarfSizeBonus(e));
			if (_bonusesSettings[Config.EXTRA_LIVE_NAME]) bonuses.Add(e => new ExtraLiveBonus(e));
			if (_bonusesSettings[Config.JUMP_BOOST_NAME]) bonuses.Add(e => new JumpBoostBonus(e));
			if (_bonusesSettings[Config.PROTECTION_NAME]) bonuses.Add(e => new ProtectionBonus(e));
			if (_bonusesSettings[Config.JELLYBALL_NAME]) bonuses.Add(e => new BallBonus<JellyBall>(e, ballFactory));
			if (_bonusesSettings[Config.SPEEDBALL_NAME]) bonuses.Add(e => new BallBonus<SpeedBall>(e, ballFactory));
		}
	}
}
