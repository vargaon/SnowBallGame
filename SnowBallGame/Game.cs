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
		private SnowBallMovementEngine snowBallMovementEngine;

		private PlayerFactory playerFactory;
		private SnowBallFactory snowBallFactory;

		private List<Player> players = new List<Player>();
		private List<SnowBall> snowballs = new List<SnowBall>();

		public Game(Control gamePanel)
		{
			playerFactory = new PlayerFactory(gamePanel);
			snowBallFactory = new SnowBallFactory(gamePanel);

			playerMovementEngine = new PlayerMovementEngine(gamePanel);
			snowBallMovementEngine = new SnowBallMovementEngine(gamePanel, players);
		}

		public void AddPlayer(PlayerCreationRecord pcr)
		{
			var player = playerFactory.CreatePlayer(pcr.PlayerColor, pcr.Controler);
			playerMovementEngine.SetSpawnPosition(player.Entity);
			players.Add(player);
		}

		public void AddSnowBall(SnowBall s)
		{
			snowballs.Add(s);
		}

		public void TickAction(Dictionary<Keys, bool> pressedKeys)
		{
			foreach (var player in players)
			{
				playerMovementEngine.Move(player, pressedKeys);
				CheckForPlayerThrow(player, pressedKeys);
			}

			foreach (var snowBall in snowballs)
			{
				snowBallMovementEngine.Move(snowBall);
			}

			removeUnactiveSnowBalls();
		}

		//TODO samostaný modul
		private void CheckForPlayerThrow(Player p, Dictionary<Keys, bool> pressedKeys)
		{
			var throwControler = p.Controler.ThrowContoler;
			var throwment = p.Throwment;

			throwment.ThrowTick();

			if (pressedKeys[throwControler.Throw])
			{
				if(throwment.CanThrow)
				{
					throwment.CanThrow = false;
					AddSnowBall(snowBallFactory.CreateSnowBall(p));
				}
			}
		}
		private void removeUnactiveSnowBalls()
		{
			snowballs.RemoveAll(x => x.Active == false);
		}
	}
}
