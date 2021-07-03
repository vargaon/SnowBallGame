using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class MovementEngine
	{
		private List<Control> platforms;

		private Control gamePanel;

		private Random random = new Random();

		public MovementEngine(Control gamePanel, List<Control> platforms)
		{
			this.platforms = platforms;
			this.gamePanel = gamePanel;
		}

		public void Move(Player p, Dictionary<Keys, bool> pressedKeys)
		{
			var entity = p.Entity;

			var controler = p.Controler;

			if (pressedKeys[controler.Left]) entity.Left -= p.MoveSpeed;
			if (pressedKeys[controler.Right]) entity.Left += p.MoveSpeed;
			if (pressedKeys[controler.Up] && p.CanJump && p.StandOn != null) p.CanJump = false;
			if (pressedKeys[controler.Down] && p.StandOn != null) p.FallTrought = p.StandOn;


			if (p.FallTrought != null && !entity.Bounds.IntersectsWith(p.FallTrought.Bounds)) p.FallTrought = null;

			if (!p.CanJump && p.ForceCounter < 0)
			{
				p.CanJump = true;
			}


			if (!p.CanJump)
			{
				if (p.JumpSpeed > 0) p.ReverseJumpSpeed();
				p.DecreaseForceCounter();
			}
			else
			{
				if (p.JumpSpeed < 0) p.ReverseJumpSpeed();
			}

			CheckPlatformStand(p);
			CheckGamePanelBorderOut(p);
		}

		private void CheckGamePanelBorderOut(Player p)
		{
			var entity = p.Entity;

			if(entity.Top > gamePanel.Top + gamePanel.Height + 100)
			{
				entity.Top = -100;
				entity.Left = GetRandomLeftPosition();
			}
		}

		private void CheckPlatformStand(Player p)
		{
			var entity = p.Entity;

			foreach(var platform in platforms)
			{
				if (entity.Bounds.IntersectsWith(platform.Bounds) && p.CanJump && platform != p.FallTrought)
				{
					p.ResetForceCounter();
					entity.Top = platform.Top - p.EntitySize + 1;
					p.StandOn = platform;
					return;	
				}
			}

			entity.Top += p.JumpSpeed;
			p.StandOn = null;
		}

		private int GetRandomLeftPosition()
		{
			var platform = platforms[random.Next(0, platforms.Count)];
			return random.Next(platform.Left, platform.Left + platform.Width);
		}
	}
}
