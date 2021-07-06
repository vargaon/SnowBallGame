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

		public int EntitySize { get; private set; }

		public int PunchForce { get; private set; }

		public bool Active { get; set; } = true;

		public SnowBall(Player p, Control e)
		{
			this.Owner = p;
			this.Entity = e;

			if (p.Movement.Direction < 0) Movement.SetDirectionLeft();
			else Movement.SetDirectionRight();
		}

		public void SetColor(Color c)
		{
			this.Entity.BackColor = c;
		}

		public void SetPunchForce(int value)
		{
			this.PunchForce = value;
		}

		public void SetEntitySize(int value)
		{
			EntitySize = value;

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
