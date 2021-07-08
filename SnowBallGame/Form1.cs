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
		private Dictionary<Keys, bool> _pressedKeys = new Dictionary<Keys, bool>();

		private List<PlayerCreationRecord> _playerRecordsList = new List<PlayerCreationRecord>();

		private Game game;

		public Form1()
		{
			InitializeComponent();

			this.game = new Game(game_panel, player_panel, _pressedKeys);

			InitializePlayers();

			RegisterPlayers(game);
		}

		private void InitializePlayers()
		{
			var player_1 = new PlayerCreationRecord();
			player_1.Name = "Ondra";
			player_1.Controler = PlayerControler.FromKeys(Keys.W, Keys.S, Keys.A, Keys.D, Keys.V);
			player_1.Color = Color.Red;

			var player_2 = new PlayerCreationRecord();
			player_2.Name = "Petr";
			player_2.Controler = PlayerControler.FromKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.M);
			player_2.Color = Color.Blue;

			var player_3 = new PlayerCreationRecord();
			player_3.Name = "Terka";
			player_3.Controler = PlayerControler.FromKeys(Keys.U, Keys.J, Keys.H, Keys.K, Keys.B);
			player_3.Color = Color.Green;

			_playerRecordsList.Add(player_1);
			_playerRecordsList.Add(player_2);
			_playerRecordsList.Add(player_3);

			InitializePlayerKeysHooks();
		}

		private void RegisterPlayers(Game g)
		{
			_playerRecordsList.ForEach(x => g.RegisterPlayer(x));
		}

		private void InitializePlayerKeysHooks()
		{
			foreach (var player in _playerRecordsList)
			{
				var movementControler = player.Controler.MovementContoler;
				var throwControler = player.Controler.ThrowContoler;

				_pressedKeys.Add(movementControler.Jump, false);
				_pressedKeys.Add(movementControler.Down, false);
				_pressedKeys.Add(movementControler.Left, false);
				_pressedKeys.Add(movementControler.Right, false);
				_pressedKeys.Add(throwControler.Throw, false);
			}
		}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

			Keys key = e.KeyData;

			if(_pressedKeys.ContainsKey(key)) _pressedKeys[key] = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

			Keys key = e.KeyData;

			if (_pressedKeys.ContainsKey(key)) _pressedKeys[key] = false;
		}

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.game.TickAction();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void player_panel_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
