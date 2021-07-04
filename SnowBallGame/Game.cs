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

		public void TickAction(Dictionary<Keys, bool> pressedKeys)
		{
			foreach (var player in players)
			{
				playerMovementEngine.Move(player, pressedKeys);
				ThrowingSnowBall(player, pressedKeys);
			}

			snowBallMovementEngine.MoveSnowBalls();
		}

		//TODO samostaný modul
		private void ThrowingSnowBall(Player p, Dictionary<Keys, bool> pressedKeys)
		{
			var throwControler = p.Controler.ThrowContoler;
			var throwment = p.Throwment;

			throwment.DecreaseThrowSpeedCounter();
			if(throwment.ThrowSpeedCounter < 0)
			{
				throwment.ResetThrowSpeedCounter();
				throwment.CanThrow = true;
			}

			if (pressedKeys[throwControler.Throw])
			{
				if(throwment.CanThrow)
				{
					throwment.CanThrow = false;
					snowBallMovementEngine.AddSnowBall(snowBallFactory.CreateSnowBall(p));
				}
			}
		}
	}
}
