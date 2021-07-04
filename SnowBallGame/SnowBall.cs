using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class SnowBall
	{
		public Player Owner { get; private set; }

		public Control Entity { get; private set; }

		public SnowBallMovement Movement { get; } = new SnowBallMovement();

		public int EntitySize { get; private set; } = 15;

		public int PunchForce { get; private set; } = 20;

		public bool Active { get; set; } = true;

		private System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

		public SnowBall(Player p, Control e, Color c)
		{
			this.Owner = p;
			this.Entity = e;

			if (p.Movement.Direction < 0) Movement.SetDirectionLeft();
			else Movement.SetDirectionRight();

			SetUpEntity(c);
		}

		private void SetUpEntity(Color c)
		{
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;

			this.Entity.Top -= EntitySize / 2;
 
			gp.AddEllipse(0, 0, this.Entity.Width - 3, this.Entity.Height - 3);

			Region rg = new Region(gp);
			this.Entity.Region = rg;

			this.Entity.BackColor = c;
		}
	}
}
