using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace SnowBallGame
{
	public partial class Form1 : Form
	{
		private Dictionary<Keys, bool> _pressedKeys = new Dictionary<Keys, bool>();

		private Dictionary<string,PlayerCreationRecord> _playerRecordsList;

		private Dictionary<string, bool> _bonusesSettings;

		private static string PLAYER1_RECORD_TAG = "player1_record";
		private static string PLAYER2_RECORD_TAG = "player2_record";
		private static string PLAYER3_RECORD_TAG = "player3_record";
		private static string PLAYER4_RECORD_TAG = "player4_record";

		private Game game;

		public Form1()
		{
			InitializeComponent();

			this.ActiveControl = start_game_btn;

			player1_record.Tag = PLAYER1_RECORD_TAG;
			player2_record.Tag = PLAYER2_RECORD_TAG;
			player3_record.Tag = PLAYER3_RECORD_TAG;
			player4_record.Tag = PLAYER4_RECORD_TAG;

			RegisterDefaultBonusesSetings();
			RegisterDefaultPlayersSettings();
		}

		private void RegisterDefaultBonusesSetings()
		{
			this._bonusesSettings = new Dictionary<string, bool>();

			this._bonusesSettings.Add(Config.GIANT_SIZE_NAME, true);
			this._bonusesSettings.Add(Config.DWARF_SIZE_NAME, true);
			this._bonusesSettings.Add(Config.EXTRA_LIVE_NAME, true);
			this._bonusesSettings.Add(Config.JUMP_BOOST_NAME, true);
			this._bonusesSettings.Add(Config.SPEEDBALL_NAME, true);
			this._bonusesSettings.Add(Config.JELLYBALL_NAME, true);
			this._bonusesSettings.Add(Config.PROTECTION_NAME, true);
		}

		private void RegisterDefaultPlayersSettings()
		{
			this._pressedKeys = new Dictionary<Keys, bool>();
			this._playerRecordsList = new Dictionary<string, PlayerCreationRecord>();

			var player1 = new PlayerCreationRecord(true);
			player1.Color = Color.Red;
			player1.Name = "Player Name";
			player1.Controler.MovementContoler.Jump = Keys.W;
			player1.Controler.MovementContoler.Down = Keys.S;
			player1.Controler.MovementContoler.Left = Keys.A;
			player1.Controler.MovementContoler.Right = Keys.D;
			player1.Controler.ThrowContoler.Throw = Keys.V;

			RegisterPlayerDefaultHooks(player1.Controler);

			var player2 = new PlayerCreationRecord(true);
			player2.Color = Color.Blue;
			player2.Name = "Player Name";
			player2.Controler.MovementContoler.Jump = Keys.Up;
			player2.Controler.MovementContoler.Down = Keys.Down;
			player2.Controler.MovementContoler.Left = Keys.Left;
			player2.Controler.MovementContoler.Right = Keys.Right;
			player2.Controler.ThrowContoler.Throw = Keys.M;

			RegisterPlayerDefaultHooks(player2.Controler);

			var player3 = new PlayerCreationRecord(false);
			player3.Color = Color.LimeGreen;
			player3.Name = "Player Name";
			player3.Controler.MovementContoler.Jump = Keys.U;
			player3.Controler.MovementContoler.Down = Keys.J;
			player3.Controler.MovementContoler.Left = Keys.H;
			player3.Controler.MovementContoler.Right = Keys.K;
			player3.Controler.ThrowContoler.Throw = Keys.B;

			RegisterPlayerDefaultHooks(player3.Controler);

			var player4 = new PlayerCreationRecord(false);
			player4.Color = Color.Yellow;
			player4.Name = "Player Name";
			player4.Controler.MovementContoler.Jump = Keys.NumPad8;
			player4.Controler.MovementContoler.Down = Keys.NumPad5;
			player4.Controler.MovementContoler.Left = Keys.NumPad4;
			player4.Controler.MovementContoler.Right = Keys.NumPad6;
			player4.Controler.ThrowContoler.Throw = Keys.NumPad0;

			RegisterPlayerDefaultHooks(player4.Controler);

			this._playerRecordsList.Add(PLAYER1_RECORD_TAG, player1);
			this._playerRecordsList.Add(PLAYER2_RECORD_TAG, player2);
			this._playerRecordsList.Add(PLAYER3_RECORD_TAG, player3);
			this._playerRecordsList.Add(PLAYER4_RECORD_TAG, player4);
		}

		private void RegisterPlayerDefaultHooks(PlayerControler controler)
		{
			_pressedKeys.Add(controler.MovementContoler.Jump, false);
			_pressedKeys.Add(controler.MovementContoler.Down, false);
			_pressedKeys.Add(controler.MovementContoler.Left, false);
			_pressedKeys.Add(controler.MovementContoler.Right, false);
			_pressedKeys.Add(controler.ThrowContoler.Throw, false);
		}

		private void RegisterPlayersToGame()
		{
			var players = from p in _playerRecordsList.Values where p.Active select p;

			foreach (var x in players)
			{
				this.game.RegisterPlayer(x);
			}
		}

		private void BtnClickNewGame(object sender, EventArgs e)
		{
			end_panel.Visible = false;
			start_panel.Visible = true;
		}

		private void BtnClickStartGame(object sender, EventArgs e)
		{
			start_panel.Visible = false;
			this.ActiveControl = game_panel;

			this.game = new Game(game_panel, player_panel, this._pressedKeys, _bonusesSettings);

			RegisterPlayersToGame();
			game.Start();
			game_timer.Start();
		}

		private void GameTimerTick(object sender, EventArgs e)
		{
			switch(this.game.State)
			{
				case GameState.RUN:
					this.game.TickAction();
					break;
				case GameState.END:
					game_timer.Stop();
					end_panel.Visible = true;
					if (game.GameWinner != null)
					{
						win_player_name.Text = game.GameWinner.Name;
						win_player_score.Text = game.GameWinner.Score.ToString();
						win_player_avatar.BackColor = game.GameWinner.Entity.BackColor;
					}
					break;
				default:
					throw new Exception("Not Allowed Game State");
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

		private void ColorChange(object sender, EventArgs e)
		{
			var colorResult = color_dialog.ShowDialog();

			if(colorResult == DialogResult.OK && color_dialog.Color != Color.Black)
			{
				var entity = (Control)sender;
				
				if(_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
				{
					entity.BackColor = color_dialog.Color;
					record.Color = color_dialog.Color;
				}
			}
		}

		private void PlayerNameChange(object sender, EventArgs e)
		{
			var entity = (Control)sender;

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				record.Name = entity.Text;
			}
		}

		private bool RegisterKeyHook(Keys newHook, Keys oldHook)
		{
			if (oldHook != newHook)
			{
				if (_pressedKeys.ContainsKey(newHook)) return false;
				if (oldHook != Keys.None) _pressedKeys.Remove(oldHook);
				_pressedKeys.Add(newHook, false);
				return true;
			}

			return false;
		}

		private void SelectKeyJump(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controler.MovementContoler.Jump;

				if(RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controler.MovementContoler.Jump = e.KeyData;
				}
			}
		}

		private void SelectKeyDown(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;
			entity.Text = e.KeyData.ToString();

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controler.MovementContoler.Down;

				if (RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controler.MovementContoler.Down = e.KeyData;
				}
			}
		}

		private void SelectKeyLeft(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;
			entity.Text = e.KeyData.ToString();

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controler.MovementContoler.Left;

				if (RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controler.MovementContoler.Left = e.KeyData;
				}
			}
		}

		private void SelectKeyRight(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;
			entity.Text = e.KeyData.ToString();

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controler.MovementContoler.Right;

				if (RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controler.MovementContoler.Right = e.KeyData;
				}
			}
		}

		private void SelectKeyThrow(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;
			entity.Text = e.KeyData.ToString();

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controler.ThrowContoler.Throw;

				if (RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controler.ThrowContoler.Throw = e.KeyData;
				}
			}
		}

		private void BtnClickAddPlayer3(object sender, EventArgs e)
		{
			var entity = (Button)sender;
			entity.Visible = false;
			player3_record.Visible = true;
			_playerRecordsList["player3_record"].Active = true;
		}

		private void BtnClickAddPlayer4(object sender, EventArgs e)
		{
			var entity = (Button)sender;
			entity.Visible = false;
			player4_record.Visible = true;
			_playerRecordsList["player4_record"].Active = true;
		}

		private void BtnClickRemovePlayer3(object sender, EventArgs e)
		{
			player3_record.Visible = false;
			AddPlayer3.Visible = true;
			_playerRecordsList["player3_record"].Active = false;
		}

		private void BtnClickRemovePlayer4(object sender, EventArgs e)
		{
			player4_record.Visible = false;
			AddPlayer4.Visible = true;
			_playerRecordsList["player4_record"].Active = false;
		}

		private void ChangeBonusSetting(object sender, EventArgs e)
		{
			var entity = (CheckBox)sender;
			if(_bonusesSettings.ContainsKey(entity.Tag.ToString()))
			{
				_bonusesSettings[entity.Tag.ToString()] = entity.Checked;
			}
		}
	}
}
