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

		private PlayerFactory playerFactory;
		private BallFactory ballFactory;

		private List<Player> players = new List<Player>();
		private List<Ball> balls = new List<Ball>();

		public Game(Control gamePanelEntity)
		{
			gamePanelManager = new GamePanelManager(gamePanelEntity);

			playerFactory = new PlayerFactory(gamePanelManager);
			ballFactory = new BallFactory(gamePanelManager);

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

		public void AddSnowBall(Ball s)
		{
			balls.Add(s);
		}

		public void TickAction(Dictionary<Keys, bool> pressedKeys)
		{
			players.ForEach(x => {
				playerMovementEngine.Move(x, pressedKeys);
				CheckForPlayerThrow(x, pressedKeys);
			});

			balls.ForEach(x => ballMovementEngine.Move(x));

			RemoveDeadPlayers();
			RemoveUnactiveSnowBalls();
		}

		private void CheckForPlayerThrow(Player p, Dictionary<Keys, bool> pressedKeys)
		{
			var throwControler = p.Controler.ThrowContoler;
			var throwment = p.Throwment;

			throwment.ThrowTick();

			if (pressedKeys[throwControler.Throw])
			{
				if(throwment.CanThrow)
				{	
					AddSnowBall(throwment.ThrowBall());
				}
			}
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
