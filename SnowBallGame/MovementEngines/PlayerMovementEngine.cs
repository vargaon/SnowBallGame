using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerMovementEngine : MovementEngine<Player>
	{
		private Dictionary<Keys, bool> _pressedKeys = new Dictionary<Keys, bool>();

		public PlayerMovementEngine(GamePanelManager gamePanel, Dictionary<Keys, bool> pressedKeys) :base(gamePanel) 
		{
			this._pressedKeys = pressedKeys;
		}

		public override void Move(Player p)
		{
			var controler = p.Controler.MovementContoler;

			ProcessPunch(p);

			if (_pressedKeys[controler.Left]) MoveLeft(p);

			if (_pressedKeys[controler.Right]) MoveRight(p);

			if (_pressedKeys[controler.Jump]) Jump(p);

			ProcessJump(p);

			if (_pressedKeys[controler.Down]) 
			{
				if(p.Movement.StandOn != null) p.Movement.FallTrought = p.Movement.StandOn;
			}

			if (p.Movement.FallTrought != null) CheckFallingThroughtDone(p);

			if (!CheckPlatformStand(p.Entity, p.Movement))
			{
				p.Entity.Top += p.Movement.JumpSpeed;
				p.Movement.StandOn = null;
			}

			CheckGamePanelBorderOut(p);
		}

		private void Jump(Player p)
		{
			if (p.Movement.CanJump && p.Movement.StandOn != null) p.Movement.CanJump = false;
		}

		private void ProcessJump(Player p)
		{
			var movement = p.Movement;

			if (!movement.CanJump && movement.DecreaseJumpForceCounter())
			{
				movement.CanJump = true;
			}

			if (!movement.CanJump)
			{
				if (!movement.Falling()) movement.ReverseJumpSpeed();
			}
			else
			{
				if (movement.Falling()) movement.ReverseJumpSpeed();
			}
		}

		private void CheckFallingThroughtDone(Player p)
		{
			if(!p.Entity.Bounds.IntersectsWith(p.Movement.FallTrought.Bounds)) p.Movement.FallTrought = null;
		}

		private void ProcessPunch(Player p)
		{
			p.Entity.Left += p.Movement.PunchSpeed;
			p.Movement.PunchTick();
		}

		private void MoveLeft(Player p)
		{
			p.Entity.Left -= p.Movement.MoveSpeed;
			p.Movement.SetDirectionLeft();
		}

		private void MoveRight(Player p)
		{
			p.Entity.Left += p.Movement.MoveSpeed;
			p.Movement.SetDirectionRight();
		}

		private void CheckGamePanelBorderOut(Player p)
		{
			var entity = p.Entity;

			if(OutOfGamePanel(entity))
			{
				if (p.LoseLive())
				{
					p.Profile.UnRegister();
					gamePanel.UnRegister(entity);
				}
				else
				{
					p.ResetBonusMovement();
					p.ResetBonusThrowment();
					SetSpawnPosition(p);
				}
			}
		}

		private bool CheckPlatformStand(Control entity, PlayerMovement movement)
		{
			foreach(var platform in gamePanel.Platforms)
			{
				if (entity.Bounds.IntersectsWith(platform.Bounds) && movement.CanJump && platform != movement.FallTrought)
				{
					movement.ResetJumpForceCounter();
					entity.Top = platform.Top - entity.Height + 1;
					movement.StandOn = platform;
					return true;	
				}
			}
			return false;
		}

		override protected bool OutOfGamePanel(Control entity)
		{
			return entity.Top > gamePanel.Entity.Top + gamePanel.Entity.Height + gamePanel.Margin;
		}
	}
}
