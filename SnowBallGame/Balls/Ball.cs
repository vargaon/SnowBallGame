using System.Drawing;
using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Abstract class for all types of ball.
	/// </summary>
	abstract class Ball
	{
		/// <summary>
		/// Owner, instance of player that threw the ball.
		/// </summary>
		public Player Owner { get; private set; }

		/// <summary>
		/// Form control assigned to ball instance.
		/// </summary>
		public Control Entity { get; private set; }

		/// <summary>
		/// Ball color.
		/// </summary>
		public Color BallColor { get; protected set; }

		/// <summary>
		/// Ball movement.
		/// </summary>
		public BallMovement Movement { get; protected set; } 

		/// <summary>
		/// Size of <see cref="Entity"/>.
		/// </summary>
		public int EntitySize { get; protected set; }

		/// <summary>
		/// Ball punch force. How much player will be punch after ball hits him.
		/// </summary>
		public int PunchForce { get; protected set; }

		/// <summary>
		/// Flag if ball has already hit player or gone out of game panel.
		/// </summary>
		public bool IsActive { get; set; } = true;

		/// <summary>
		/// Set a ball entity and assign a ball color and size.
		/// </summary>
		/// <param name="entity">Form control.</param>
		public void SetEntity(Control entity)
		{
			this.Entity = entity;
			this.Entity.BackColor = BallColor;
			SetEntitySize();
		}

		/// <summary>
		/// Set ball owner and <see cref="Entity"/> position and direction according to owner properties.
		/// </summary>
		/// <param name="p">Player that threw the ball.</param>
		public void SetOwner(Player p)
		{
			this.Owner = p;
			Movement.SetSameDirection(p.Movement);
		}

		private void SetEntitySize()
		{

			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;

			this.Entity.Top -= EntitySize / 2;
			this.Entity.Left -= EntitySize / 2;

			System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
			gp.AddEllipse(0, 0, this.Entity.Width - 3, this.Entity.Height - 3);
			Region rg = new Region(gp);
			this.Entity.Region = rg;
		}
	}
}
