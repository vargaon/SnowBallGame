using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SnowBallGame
{
	public partial class Form1 : Form
	{
		Dictionary<Keys, bool> pressedKeys = new Dictionary<Keys, bool>();

		List<Player> players = new List<Player>();

		List<Control> platforms = new List<Control>();

		MovementEngine mEngine;

		public Form1()
		{
			InitializeComponent();

			mEngine = new MovementEngine(game_panel);

			InitializePlayers();
			InitializeKeysHooks();
		}

		private void InitializePlayers()
		{
			var en1 = new PictureBox();
			en1.Tag = "player";
			game_panel.Controls.Add(en1);
			var p1 = new Player(Color.Red,en1, PlayerControler.FromKeys(Keys.W, Keys.S, Keys.A, Keys.D));
			players.Add(p1);

			var en2 = new PictureBox();
			en2.Tag = "player";
			game_panel.Controls.Add(en2);
			var p2 = new Player(Color.Blue,en2, PlayerControler.FromKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right));
			players.Add(p2);

			mEngine.SetPlayersSpawnPosition();
		}

		private void InitializeKeysHooks()
		{
			foreach (var player in players)
			{
				var controler = player.Controler;

				pressedKeys.Add(controler.Up, false);
				pressedKeys.Add(controler.Down, false);
				pressedKeys.Add(controler.Left, false);
				pressedKeys.Add(controler.Right, false);
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

		private void OneTickAction()
		{
			foreach(var player in players)
			{
				mEngine.Move(player, pressedKeys);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			OneTickAction();
		}
	}
}
