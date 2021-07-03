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

		public int MoveSpeed { get; private set; } = 10;

		public int Direction { get; private set; }

		public int EntitySize { get; private set; } = 5;

		public int PunchForce { get; private set; } = 15;

		public bool Active { get; set; } = true;

		public SnowBall(Player p, Control e, Color c)
		{
			this.Owner = p;
			this.Entity = e;
			this.Direction = p.Direction;

			SetUpEntity(c);
		}

		private void SetUpEntity(Color c)
		{
			this.Entity.Width = EntitySize;
			this.Entity.Height = EntitySize;
			this.Entity.BackColor = c;
		}
	}
}
