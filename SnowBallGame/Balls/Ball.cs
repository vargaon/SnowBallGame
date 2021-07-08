using System.Drawing;
using System.Windows.Forms;

namespace SnowBallGame
{
	abstract class Ball
	{
		public Player Owner { get; private set; }

		public Control Entity { get; private set; }

		public Color BallColor { get; protected set; }

		public BallMovement Movement { get; protected set; } 

		public int EntitySize { get; protected set; }

		public int PunchForce { get; protected set; }

		public bool IsActive { get; set; } = true;

		public void SetEntity(Control entity)
		{
			this.Entity = entity;
			this.Entity.BackColor = BallColor;
			SetEntitySize();
		}

		public void SetOwner(Player p)
		{
			this.Owner = p;

			if (p.Movement.Direction < 0) Movement.SetDirectionLeft();
			else Movement.SetDirectionRight();
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
