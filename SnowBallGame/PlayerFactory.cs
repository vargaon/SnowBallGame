﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	class PlayerFactory : Factory
	{
		public static string PLAYER_TAG = "player";

		public PlayerFactory(GamePanelManager gamePanel) :base(gamePanel)
		{
		}

		public Player CreatePlayer(Color c, PlayerControler controler)
		{
			var entity = CreatePlayerEntity(c);
			gamePanel.Register(entity);

			return new Player(entity, controler);
		}

		private Control CreatePlayerEntity(Color c)
		{
			var entity = new PictureBox();
			entity.Tag = PLAYER_TAG;
			entity.BackColor = c;

			return entity;
		}

	}
}
