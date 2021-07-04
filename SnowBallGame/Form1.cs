using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SnowBallGame
{
	public partial class Form1 : Form
	{
		private Dictionary<Keys, bool> pressedKeys = new Dictionary<Keys, bool>();

		private List<PlayerCreationRecord> prc = new List<PlayerCreationRecord>();

		private Game game;

		public Form1()
		{
			InitializeComponent();

			this.game = new Game(game_panel);
			
			InitializePlayers();
		}

		private void InitializePlayers()
		{
			var player_1 = new PlayerCreationRecord();
			player_1.Controler = PlayerControler.FromKeys(Keys.W, Keys.S, Keys.A, Keys.D, Keys.V);
			player_1.PlayerColor = Color.Red;

			var player_2 = new PlayerCreationRecord();
			player_2.Controler = PlayerControler.FromKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.M);
			player_2.PlayerColor = Color.Blue;

			prc.Add(player_1);
			prc.Add(player_2); 

			AddPlayersToGame();
			InitializePlayerKeysHooks();
		}

		private void AddPlayersToGame()
		{
			foreach (var player in prc)
			{
				game.AddPlayer(player);
			}
		}

		private void InitializePlayerKeysHooks()
		{
			foreach (var player in prc)
			{
				var movementControler = player.Controler.MovementContoler;
				var throwControler = player.Controler.ThrowContoler;

				pressedKeys.Add(movementControler.Jump, false);
				pressedKeys.Add(movementControler.Down, false);
				pressedKeys.Add(movementControler.Left, false);
				pressedKeys.Add(movementControler.Right, false);
				pressedKeys.Add(throwControler.Throw, false);
			}
		}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
			return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

			Keys key = e.KeyData;

			if(pressedKeys.ContainsKey(key)) pressedKeys[key] = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

			Keys key = e.KeyData;

			if (pressedKeys.ContainsKey(key)) pressedKeys[key] = false;
		}

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.game.TickAction(pressedKeys);
		}
	}
}
