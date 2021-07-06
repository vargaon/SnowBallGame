using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerMovementEngine : MovementEngine<Player>
	{
		public PlayerMovementEngine(Control gamePanel) :base(gamePanel) { }

		public void Move(Player p, Dictionary<Keys, bool> pressedKeys)
		{
			var entity = p.Entity;
			var controler = p.Controler.MovementContoler;
			var movement = p.Movement;

			entity.Left += movement.PunchSpeed;
			movement.PunchTick();

			if (pressedKeys[controler.Left])
			{
				entity.Left -= movement.MoveSpeed;
				movement.SetDirectionLeft();
			}
			if (pressedKeys[controler.Right])
			{
				entity.Left += movement.MoveSpeed;
				movement.SetDirectionRight();
			}

			if (pressedKeys[controler.Jump] && movement.CanJump && movement.StandOn != null) movement.CanJump = false;
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
			CheckGamePanelBorderOut(p);
		}

		private void CheckGamePanelBorderOut(Player p)
		{
			var entity = p.Entity;

			if(OutOfGamePanel(entity))
			{
				if(p.LoseLive()) gamePanel.Controls.Remove(entity);
				SetSpawnPosition(entity);
			}
		}

		private void CheckPlatformStand(Control entity, PlayerMovement movement)
		{
			foreach(var platform in platforms)
			{
				if (entity.Bounds.IntersectsWith(platform.Bounds) && movement.CanJump && platform != movement.FallTrought)
				{
					movement.ResetJumpForceCounter();
					entity.Top = platform.Top - entity.Height + 1;
					movement.StandOn = platform;
					return;	
				}
			}

			entity.Top += movement.JumpSpeed;
			movement.StandOn = null;
		}

		override protected bool OutOfGamePanel(Control entity)
		{
			return entity.Top > gamePanel.Top + gamePanel.Height + gamePanelMargin;
		}
	}
}
