using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Class representing the game itself and taking care of its course.
	/// </summary>
	sealed class Game
	{
		/// <summary>
		/// Internal enum for game state indication.
		/// </summary>
		public enum GameState { RUN, END }

		private Dictionary<Keys, bool> _pressedKeys = new Dictionary<Keys, bool>();

		/// <summary>
		/// Game state. Run when game is running. End when only one player left.
		/// </summary>
		public GameState State { get; private set; }

		private PlayerMovementEngine playerMovementEngine;
		private BallMovementEngine ballMovementEngine;

		private GamePanelManager gamePanelManager;
		private PlayerPanelManager playerPanelManager;

		private PlayerFactory playerFactory;
		private BallFactory ballFactory;
		private BonusFactory bonusFactory;

		private Random random = new Random();

		/// <summary>
		/// Instace of player that won the game.
		/// </summary>
		public Player GameWinner { get; private set; }

		private int _bonusSpawnDelayTime = Config.BONUS_SPAWN_DELAY_TIME;

		private int _bonusSpawnDelayTimeCounter;

		/// <summary>
		/// Initializes a new instance of the <see cref="Game"/>.
		/// </summary>
		/// <param name="gamePanelEntity">Form control that contains game space.</param>
		/// <param name="playerPanelEntity">Form control where players profiles will be generate.</param>
		/// <param name="pressedKeys">Dictionary of set control keys.</param>
		/// <param name="bonusesSettings">Additional bonuses settings.</param>
		public Game(Control gamePanelEntity, Control playerPanelEntity, Dictionary<Keys, bool> pressedKeys, Dictionary<string, bool> bonusesSettings)
		{
			this._pressedKeys = pressedKeys;

			gamePanelManager = new GamePanelManager(gamePanelEntity, random);
			playerPanelManager = new PlayerPanelManager(playerPanelEntity);

			playerFactory = new PlayerFactory(gamePanelManager, playerPanelManager);
			ballFactory = new BallFactory(gamePanelManager);
			bonusFactory = new BonusFactory(gamePanelManager, ballFactory, bonusesSettings, random);

			playerMovementEngine = new PlayerMovementEngine(gamePanelManager, pressedKeys);
			ballMovementEngine = new BallMovementEngine(gamePanelManager);

			ResetBonusSpawnDelayTimeCounter();
		}

		/// <summary>
		/// Method for adding player to game.
		/// Creates an instace of player and add him a default thrown ball.
		/// </summary>
		/// <param name="playerRecord">Record of player from initial game settings.</param>
		public void RegisterPlayer(PlayerCreationRecord playerRecord)
		{
			var player = playerFactory.CreatePlayer(playerRecord);
			playerMovementEngine.SetSpawnPosition(player);
			player.Throwment.SetThrownBall(() => ballFactory.CreateBall<SnowBall>(player));
		}

		/// <summary>
		/// Start the game, this set a game state to RUN and show game panels.
		/// </summary>
		public void Start()
		{
			gamePanelManager.Show();
			playerPanelManager.Show();

			State = GameState.RUN;
		}

		/// <summary>
		/// Method that should be called every timer tick action.
		/// Moves all moving entities and controls subsequent situations.
		/// </summary>
		public void TickAction()
		{
			gamePanelManager.Players.ForEach(x => {
				playerMovementEngine.Move(x);
				CheckPlayerThrow(x);
				if(x.DecreaseBonusDurationCounter())
				{
					x.ResetBonusDurationCounter();
					x.ResetPlayerBonus();
				}
			});

			gamePanelManager.Balls.ForEach(x => ballMovementEngine.Move(x));

			if (gamePanelManager.IsSetBonus())
			{
				if(CheckBonusCollect()) gamePanelManager.UnregisterBonus();
			}

			if (DecreaseBonusSpawnDelayTimeCounter())
			{
				gamePanelManager.UnregisterBonus();
				bonusFactory.CreateRandomBonus();
				ResetBonusSpawnDelayTimeCounter();
			}

			RemoveDeadPlayers();
			RemoveUnactiveSnowBalls();
		}

		private void CheckPlayerThrow(Player p)
		{
			var throwControler = p.Controller.ThrowContoler;
			var throwment = p.Throwment;

			throwment.ThrowTick();

			if (throwment.CanThrow && _pressedKeys[throwControler.Throw])
			{	
				throwment.ThrowBall();

				if(throwment.DecreaseStackAmountCounter())
				{
					throwment.ResetStackAmountCounter();
					p.ResetBonusThrowment();
					p.Throwment.HoldAThrow();
				}
			}
		}

		private bool CheckBonusCollect()
		{
			var player = gamePanelManager.Players.Find(p => gamePanelManager.Bonus.Entity.Bounds.IntersectsWith(p.Entity.Bounds));
			
			if(player != null)
			{
				player.ColectBonusScore();
				gamePanelManager.Bonus.ApplyBonus(player);
				return true;
			}
			
			return false;
		}

		private void RemoveUnactiveSnowBalls()
		{
			gamePanelManager.Balls.RemoveAll(x => x.IsActive == false);
		}

		private void RemoveDeadPlayers()
		{
			gamePanelManager.Players.RemoveAll(x => x.Lives <= 0);
			if (gamePanelManager.Players.Count <= 1) Stop();
		}

		private void Stop()
		{
			State = GameState.END;

			gamePanelManager.UnregisterBonus();

			gamePanelManager.Players.ForEach(p => {
				p.Profile.UnRegister();
				gamePanelManager.UnregisterPlayer(p); 
			});

			if(gamePanelManager.Players.Count > 0) GameWinner = gamePanelManager.Players[0];

			gamePanelManager.Balls.ForEach(b => gamePanelManager.UnregisterBall(b));

			gamePanelManager.Hide();
			playerPanelManager.Hide();
		}

		private void ResetBonusSpawnDelayTimeCounter()
		{
			_bonusSpawnDelayTimeCounter = _bonusSpawnDelayTime;
		}

		private bool DecreaseBonusSpawnDelayTimeCounter()
		{
			_bonusSpawnDelayTimeCounter -= 1;
			return _bonusSpawnDelayTimeCounter <= 0;
		}
	}
}
