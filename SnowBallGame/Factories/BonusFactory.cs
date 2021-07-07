using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class BonusFactory
	{
		GamePanelManager gamePanel;

		private int entitySize = 10;

		Func<Control, Bonus>[] bonuses;

		public static string BONUS_TAG = "bonus";

		Random random;

		public BonusFactory(GamePanelManager gamePanel, BallFactory ballFactory ,Random random)
		{
			this.gamePanel = gamePanel;
			this.random = random;

			this.bonuses = new Func<Control, Bonus>[]
			{
				e => new SpeedMovementBonus(e),
				e => new JumpForceBonus(e),
				e => new ProtectionBonus(e),
				e => new ExtraLiveBonus(e),
				e => new GiantSizeBonus(e),
				e => new DwarfSizeBonus(e),
				e => new BallBonus<JellyBall>(e, ballFactory),
				e => new BallBonus<SpeedBall>(e, ballFactory)
			};
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
			entity.Tag = BONUS_TAG;
			entity.Location = gamePanel.GetRandomPosition();
			entity.Top -= entitySize + 10;
			entity.Height = entitySize;
			entity.Width = entitySize;

			entity.BackColor = Color.Purple;

			gamePanel.Register(entity);

			return entity;
		}
	}
}
