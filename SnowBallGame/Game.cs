using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class Game
	{
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
		private Random random = new Random(100);

		private int bonusSpawnWaitCounter = 0;

		public Game(Control gamePanelEntity, Control playerPanelEntity)
		{
			gamePanelManager = new GamePanelManager(gamePanelEntity, random);
			playerPanelManager = new PlayerPanelManager(playerPanelEntity);

			playerFactory = new PlayerFactory(gamePanelManager, playerPanelManager);
			ballFactory = new BallFactory(gamePanelManager);
			bonusFactory = new BonusFactory(gamePanelManager, ballFactory, random);

			playerMovementEngine = new PlayerMovementEngine(gamePanelManager);
			ballMovementEngine = new BallMovementEngine(gamePanelManager, players);
		}

		public void RegisterPlayer(PlayerCreationRecord pcr)
		{
			var player = playerFactory.CreatePlayer(pcr.PlayerColor, pcr.Controler);
			playerMovementEngine.SetSpawnPosition(player.Entity);
			player.Throwment.SetThrownBall(() => ballFactory.CreateBall<SnowBall>(player));
			players.Add(player);
		}

		public void TickAction(Dictionary<Keys, bool> pressedKeys)
		{
			bonusSpawnWaitCounter++;

			players.ForEach(x => {
				playerMovementEngine.Move(x, pressedKeys);
				CheckForPlayerThrow(x, pressedKeys);
			});

			if (bonus != null) CheckBonusCollect();

			balls.ForEach(x => ballMovementEngine.Move(x));

			if (bonusSpawnWaitCounter >= 350)
			{
				if (bonus != null) gamePanelManager.UnRegister(bonus.Entity);
				bonusSpawnWaitCounter = 0;
				bonus = bonusFactory.CreateRandomBonus();
			}

			RemoveDeadPlayers();
			RemoveUnactiveSnowBalls();
		}

		private void CheckForPlayerThrow(Player p, Dictionary<Keys, bool> pressedKeys)
		{
			var throwControler = p.Controler.ThrowContoler;
			var throwment = p.Throwment;

			throwment.ThrowTick();

			if (throwment.CanThrow && pressedKeys[throwControler.Throw])
			{	
				balls.Add(throwment.ThrowBall());
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
					bonus.AplyBonus(p);
					bonus = null;
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
		}
	}
}
