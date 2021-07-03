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

		private int gamePanelMargin = 100;

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
			var movement = p.Movement;

			if (pressedKeys[controler.Left])
			{
				entity.Left -= movement.MoveSpeed;
				p.SetDirectionLeft();
			}
			if (pressedKeys[controler.Right])
			{
				entity.Left += movement.MoveSpeed;
				p.SetDirectionRight();
			}

			if (pressedKeys[controler.Up] && movement.CanJump && movement.StandOn != null) movement.CanJump = false;
			if (pressedKeys[controler.Down] && movement.StandOn != null) movement.FallTrought = movement.StandOn;

			if (movement.FallTrought != null && !entity.Bounds.IntersectsWith(movement.FallTrought.Bounds)) movement.FallTrought = null;

			if (!movement.CanJump && movement.JumpForceCounter < 0)
			{
				movement.CanJump = true;
			}

			if (!movement.CanJump)
			{
				if (movement.JumpSpeed > 0) movement.ReverseJumpSpeed();
				movement.DecreaseJumpForceCounter();
			}
			else
			{
				if (movement.JumpSpeed < 0) movement.ReverseJumpSpeed();
			}

			CheckPlatformStand(p.Entity, p.Movement);
			CheckGamePanelBorderOut(p.Entity);
		}

		private void CheckGamePanelBorderOut(Control entity)
		{
			if(OutOfGamePanel(entity))
			{
				SetSpawnPosition(entity);
			}
		}

		private void CheckPlatformStand(Control entity, PlayerMovement movement)
		{
			foreach(var platform in platforms)
			{
				if (entity.Bounds.IntersectsWith(platform.Bounds) && movement.CanJump && platform != movement.FallTrought)
				{
					movement.ResetForceCounter();
					entity.Top = platform.Top - entity.Height + 1;
					movement.StandOn = platform;
					return;	
				}
			}

			entity.Top += movement.JumpSpeed;
			movement.StandOn = null;
		}

		private void SetSpawnPosition(Control entity)
		{
			entity.Top = -gamePanelMargin;
			entity.Left = GetRandomLeftPosition();
		}

		private bool OutOfGamePanel(Control entity)
		{
			return entity.Top > gamePanel.Top + gamePanel.Height + gamePanelMargin;
		}

		private int GetRandomLeftPosition()
		{
			var platform = platforms[random.Next(0, platforms.Count)];
			return random.Next(platform.Left, platform.Left + platform.Width);
		}
	}
}
