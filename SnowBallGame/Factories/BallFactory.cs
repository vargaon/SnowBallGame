using System.Windows.Forms;

namespace SnowBallGame
{
	sealed class BallFactory : Factory
	{
		public static string SNOWBALL_TAG = "snowball";

		public BallFactory(GamePanelManager gamePanel) :base(gamePanel)
		{
		}

		public TBall CreateBall<TBall>(Player p) where TBall : Ball, new()
		{
			var ball = new TBall();
			ball.SetEntity(CreateBallEntity(p.Entity));
			ball.SetOwner(p);

			return ball;
		}

		private Control CreateBallEntity(Control playerEntity)
		{
			var ballEntity = new Label();
			ballEntity.Tag = SNOWBALL_TAG;

			ballEntity.Top = playerEntity.Top + (playerEntity.Height / 2);
			ballEntity.Left = playerEntity.Left + (playerEntity.Width / 2);

			gamePanel.Register(ballEntity);

			ballEntity.BringToFront();

			return ballEntity;
		}
	}
}
