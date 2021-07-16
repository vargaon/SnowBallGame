using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Class taking care of the player's movement.
	/// </summary>
	sealed class PlayerMovementEngine : MovementEngine<Player>
	{
		private Dictionary<Keys, bool> _pressedKeys = new Dictionary<Keys, bool>();

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerMovementEngine"/>.
		/// </summary>
		/// <param name="gamePanel">Game panel manager.</param>
		/// <param name="pressedKeys">Dictionary of set control keys.</param>
		public PlayerMovementEngine(GamePanelManager gamePanel, Dictionary<Keys, bool> pressedKeys) :base(gamePanel) 
		{
			this._pressedKeys = pressedKeys;
		}

		/// <summary>
		/// Performs a player movement according to his <see cref="PlayerMovement"/> and pressed controller keys.
		/// </summary>
		/// <param name="p">Player to move.</param>
		public override void Move(Player p)
		{
			var controler = p.Controller.MovementContoller;

			ProcessPunchMove(p);

			if (_pressedKeys[controler.Left]) MoveLeft(p);

			if (_pressedKeys[controler.Right]) MoveRight(p);

			if (_pressedKeys[controler.Jump]) TryJump(p);

			ProcessJumpMove(p);

			if (_pressedKeys[controler.Down]) 
			{
				if(p.Movement.StandOn != null) p.Movement.FallTrought = p.Movement.StandOn;
			}

			if (p.Movement.FallTrought != null) CheckFallingThroughtDone(p);

			if (!CheckPlatformStand(p.Entity, p.Movement))
			{
				p.Entity.Top += p.Movement.JumpDirection * p.Movement.JumpSpeed;
				p.Movement.StandOn = null;
			}

			CheckGamePanelBorderOut(p);
		}

		private void TryJump(Player p)
		{
			if (p.Movement.CanJump && p.Movement.StandOn != null)
			{
				p.Movement.CanJump = false;
				p.Movement.SetJumpDirectionUp();
			}
		}

		private void ProcessJumpMove(Player p)
		{
			var movement = p.Movement;

			if (!movement.CanJump && movement.DecreaseJumpForceCounter())
			{
				movement.SetJumpDirectionDown();
			}
		}

		private void CheckFallingThroughtDone(Player p)
		{
			if(!p.Entity.Bounds.IntersectsWith(p.Movement.FallTrought.Bounds)) p.Movement.FallTrought = null;
		}

		private void ProcessPunchMove(Player p)
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
				if(p.Movement.HasReversedGravity())
				{
					p.ResetPlayerBonus();
					return;
				}

				if (p.LoseLive())
				{
					p.Profile.UnRegister();
					gamePanel.UnregisterPlayer(p);
				}
				else
				{
					p.ResetPlayerBonus();
					p.ResetBonusThrowment();
					SetSpawnPosition(p);
				}

				p.FallDownScore();
			}
		}
	
		private bool CheckPlatformStand(Control entity, PlayerMovement movement)
		{
			var platform = gamePanel.Platforms.Find(p => entity.Bounds.IntersectsWith(p.Bounds));

			if (platform != null && movement.Falling() && platform != movement.FallTrought)
			{
				movement.ResetJumpForceCounter();
				movement.CanJump = true;

				if(movement.HasReversedGravity()) entity.Top = platform.Top + platform.Height - 1;
				else entity.Top = platform.Top - entity.Height + 1;

				movement.StandOn = platform;
				return true;	
			}
			
			return false;
		}

		override protected bool OutOfGamePanel(Control entity)
		{
			return entity.Top > gamePanel.Entity.Top + gamePanel.Entity.Height + gamePanel.Margin || entity.Top < -1 * gamePanel.Margin;
		}
	}
}
