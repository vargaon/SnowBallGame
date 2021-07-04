﻿using System;
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

		private PlayerFactory playerFactory;
		private SnowBallFactory snowBallFactory;

		private List<Player> players = new List<Player>();

		public Game(Control gamePanel)
		{
			playerFactory = new PlayerFactory(gamePanel);
			snowBallFactory = new SnowBallFactory(gamePanel);

			playerMovementEngine = new PlayerMovementEngine(gamePanel, snowBallFactory);
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
			}

			playerMovementEngine.MoveSnowBalls();
		}
	}
}