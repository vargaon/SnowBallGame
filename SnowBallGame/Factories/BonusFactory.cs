using System;
using System.Windows.Forms;

namespace SnowBallGame
{
	class BonusFactory
	{
		GamePanelManager gamePanel;

		private int entitySize = Config.BONUS_SIZE;

		Func<Control, Bonus>[] bonuses;

		Random random;

		public BonusFactory(GamePanelManager gamePanel, BallFactory ballFactory ,Random random)
		{
			this.gamePanel = gamePanel;
			this.random = random;

			InitializeAvailableBonuses(ballFactory);
		}

		public Bonus CreateRandomBonus()
		{
			var entity = CreateBonusEntity();
			var getBonus = bonuses[random.Next(0, bonuses.Length)];
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
			this.bonuses = new Func<Control, Bonus>[]
			{
				e => new JumpBoostBonus(e),
				e => new ProtectionBonus(e),
				e => new ExtraLiveBonus(e),
				e => new GiantSizeBonus(e),
				e => new DwarfSizeBonus(e),
				e => new BallBonus<JellyBall>(e, ballFactory),
				e => new BallBonus<SpeedBall>(e, ballFactory)
			};
		}
	}
}
