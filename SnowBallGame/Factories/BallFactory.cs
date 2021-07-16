using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Factory class creating descendants of the class <see cref="Ball"/>.
	/// </summary>
	sealed class BallFactory : Factory
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BallFactory"/>.
		/// </summary>
		/// <param name="gamePanel">Game panel manager.</param>
		public BallFactory(GamePanelManager gamePanel) :base(gamePanel) { }

		/// <summary>
		/// Create a ball according to player position.
		/// </summary>
		/// <typeparam name="TBall">Descendant of the class <see cref="Ball"/> with constructor.</typeparam>
		/// <param name="p">Player that throw a ball.</param>
		/// <returns></returns>
		public TBall CreateBall<TBall>(Player p) where TBall : Ball, new()
		{
			var ball = new TBall();

			ball.SetEntity(CreateBallEntity(p.Entity));
			ball.SetOwner(p);

			gamePanel.RegisterBall(ball);
			ball.Entity.BringToFront();

			return ball;
		}

		private Control CreateBallEntity(Control playerEntity)
		{
			var ballEntity = new Label();
			ballEntity.Tag = Config.BALL_TAG;

			ballEntity.Top = playerEntity.Top + (playerEntity.Height / 2);
			ballEntity.Left = playerEntity.Left + (playerEntity.Width / 2);

			return ballEntity;
		}
	}
}
