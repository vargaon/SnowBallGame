using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SnowBallGame
{
	class Game
	{
		private Dictionary<Keys, bool> _pressedKeys = new Dictionary<Keys, bool>();

		public GameState State { get; private set; }

		private PlayerMovementEngine playerMovementEngine;
		private BallMovementEngine ballMovementEngine;

		private GamePanelManager gamePanelManager;
		private PlayerPanelManager playerPanelManager;

		private PlayerFactory playerFactory;
		private BallFactory ballFactory;
		private BonusFactory bonusFactory;

		private List<Player> players = new List<Player>();
		private List<Ball> balls = new List<Ball>();
		private Bonus bonus;
		private Random random = new Random();

		public Player GameWinner { get; private set; }

		private int _bonusSpawnDelayTime = Config.BONUS_SPAWN_DELAY_TIME;

		private int _bonusSpawnDelayTimeCounter;

		public Game(Control gamePanelEntity, Control playerPanelEntity, Dictionary<Keys, bool> pressedKeys, Dictionary<string, bool> bonusesSettings)
		{
			this._pressedKeys = pressedKeys;

			gamePanelManager = new GamePanelManager(gamePanelEntity, random);
			playerPanelManager = new PlayerPanelManager(playerPanelEntity);

			playerFactory = new PlayerFactory(gamePanelManager, playerPanelManager);
			ballFactory = new BallFactory(gamePanelManager);
			bonusFactory = new BonusFactory(gamePanelManager, ballFactory, bonusesSettings, random);

			playerMovementEngine = new PlayerMovementEngine(gamePanelManager, pressedKeys);
			ballMovementEngine = new BallMovementEngine(gamePanelManager, players);

			ResetBonusSpawnDelayTimeCounter();
		}

		public void RegisterPlayer(PlayerCreationRecord playerRecord)
		{
			var player = playerFactory.CreatePlayer(playerRecord);
			playerMovementEngine.SetSpawnPosition(player);
			player.Throwment.SetThrownBall(() => ballFactory.CreateBall<SnowBall>(player));
			players.Add(player);
		}

		public void Start()
		{
			gamePanelManager.Show();
			playerPanelManager.Show();

			State = GameState.RUN;
		}

		public void TickAction()
		{
			players.ForEach(x => {
				playerMovementEngine.Move(x);
				CheckPlayerThrow(x);
				if(x.DecreaseBonusDurationCounter())
				{
					x.ResetBonusDurationCounter();
					x.ResetBonusMovement();
				}
			});

			balls.ForEach(x => ballMovementEngine.Move(x));

			if (this.bonus != null)
			{
				if(CheckBonusCollect()) this.bonus = null;
			}

			if (DecreaseBonusSpawnDelayTimeCounter())
			{
				if (this.bonus != null) gamePanelManager.UnRegister(this.bonus.Entity);
				this.bonus = bonusFactory.CreateRandomBonus();
				ResetBonusSpawnDelayTimeCounter();
			}

			RemoveDeadPlayers();
			RemoveUnactiveSnowBalls();
		}

		private void CheckPlayerThrow(Player p)
		{
			var throwControler = p.Controler.ThrowContoler;
			var throwment = p.Throwment;

			throwment.ThrowTick();

			if (throwment.CanThrow && _pressedKeys[throwControler.Throw])
			{	
				balls.Add(throwment.ThrowBall());

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
			var entity = bonus.Entity;
			foreach(var p in players)
			{
				if(entity.Bounds.IntersectsWith(p.Entity.Bounds))
				{
					gamePanelManager.UnRegister(entity);
					p.ColectBonusScore();
					bonus.AplyBonus(p);
					return true;
				}
			}
			return false;
		}

		private void RemoveUnactiveSnowBalls()
		{
			balls.RemoveAll(x => x.IsActive == false);
		}

		private void RemoveDeadPlayers()
		{
			players.RemoveAll(x => x.Lives <= 0);
			if (players.Count <= 1) Stop();
		}

		private void Stop()
		{
			State = GameState.END;

			if (bonus != null) gamePanelManager.UnRegister(bonus.Entity);

			players.ForEach(p => {
				p.Profile.UnRegister();
				gamePanelManager.UnRegister(p.Entity); 
			});

			GameWinner = players[0];

			balls.ForEach(b => gamePanelManager.UnRegister(b.Entity));

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
