using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace SnowBallGame
{
	/// <summary>
	/// Class representing game form.
	/// </summary>
	public partial class GameForm : Form
	{
		private Dictionary<Keys, bool> _pressedKeys = new Dictionary<Keys, bool>();

		private Dictionary<string,PlayerCreationRecord> _playerRecordsList;

		private Dictionary<string, bool> _bonusesSettings;

		private static string PLAYER1_RECORD_TAG = "player1_record";
		private static string PLAYER2_RECORD_TAG = "player2_record";
		private static string PLAYER3_RECORD_TAG = "player3_record";
		private static string PLAYER4_RECORD_TAG = "player4_record";

		private Game game;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameForm"/>.
		/// </summary>
		public GameForm()
		{
			InitializeComponent();

			//Default controls settings
			this.ActiveControl = start_game_btn;

			player1_record.Tag = PLAYER1_RECORD_TAG;
			player2_record.Tag = PLAYER2_RECORD_TAG;
			player3_record.Tag = PLAYER3_RECORD_TAG;
			player4_record.Tag = PLAYER4_RECORD_TAG;

			extraLive.Text = Config.EXTRA_LIVE_NAME;
			extraLive.Tag = Config.EXTRA_LIVE_NAME;
			extraLiveColor.BackColor = Config.EXTRA_LIVE_COLOR;

			giantSize.Text = Config.GIANT_SIZE_NAME;
			giantSize.Tag = Config.GIANT_SIZE_NAME;
			giantSizeColor.BackColor = Config.GIANT_SIZE_COLOR;

			dwarfSize.Text = Config.DWARF_SIZE_NAME;
			dwarfSize.Tag = Config.DWARF_SIZE_NAME;
			dwarfSizeColor.BackColor = Config.DWARF_SIZE_COLOR;

			jumpBoost.Text = Config.JUMP_BOOST_NAME;
			jumpBoost.Tag = Config.JUMP_BOOST_NAME;
			jumpBoostColor.BackColor = Config.JUMP_BOOST_COLOR;

			protection.Text = Config.PROTECTION_NAME;
			protection.Tag = Config.PROTECTION_NAME;
			protectionColor.BackColor = Config.PROTECTION_COLOR;

			gravityReverse.Text = Config.REVERSE_GRAVITY_NAME;
			gravityReverse.Tag = Config.REVERSE_GRAVITY_NAME;
			gravityReverseColor.BackColor = Config.REVERSE_GRAVITY_COLOR;

			jellyBall.Text = Config.JELLYBALL_NAME;
			jellyBall.Tag = Config.JELLYBALL_NAME;
			jellyBallColor.BackColor = Config.BALL_BONUS_COLOR;

			speedBall.Text = Config.SPEEDBALL_NAME;
			speedBall.Tag = Config.SPEEDBALL_NAME;
			speedBallColor.BackColor = Config.BALL_BONUS_COLOR;

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
			this._bonusesSettings.Add(Config.REVERSE_GRAVITY_NAME, true);
		}

		private void RegisterDefaultPlayersSettings()
		{
			this._pressedKeys = new Dictionary<Keys, bool>();
			this._playerRecordsList = new Dictionary<string, PlayerCreationRecord>();

			var player1 = new PlayerCreationRecord(true);
			player1.Color = Color.Red;
			player1.Name = "Player Name";
			player1.Controller.MovementContoller.Jump = Keys.W;
			player1.Controller.MovementContoller.Down = Keys.S;
			player1.Controller.MovementContoller.Left = Keys.A;
			player1.Controller.MovementContoller.Right = Keys.D;
			player1.Controller.ThrowContoler.Throw = Keys.V;

			RegisterPlayerDefaultHooks(player1.Controller);

			var player2 = new PlayerCreationRecord(true);
			player2.Color = Color.Blue;
			player2.Name = "Player Name";
			player2.Controller.MovementContoller.Jump = Keys.Up;
			player2.Controller.MovementContoller.Down = Keys.Down;
			player2.Controller.MovementContoller.Left = Keys.Left;
			player2.Controller.MovementContoller.Right = Keys.Right;
			player2.Controller.ThrowContoler.Throw = Keys.M;

			RegisterPlayerDefaultHooks(player2.Controller);

			var player3 = new PlayerCreationRecord(false);
			player3.Color = Color.LimeGreen;
			player3.Name = "Player Name";
			player3.Controller.MovementContoller.Jump = Keys.U;
			player3.Controller.MovementContoller.Down = Keys.J;
			player3.Controller.MovementContoller.Left = Keys.H;
			player3.Controller.MovementContoller.Right = Keys.K;
			player3.Controller.ThrowContoler.Throw = Keys.B;

			RegisterPlayerDefaultHooks(player3.Controller);

			var player4 = new PlayerCreationRecord(false);
			player4.Color = Color.Yellow;
			player4.Name = "Player Name";
			player4.Controller.MovementContoller.Jump = Keys.NumPad8;
			player4.Controller.MovementContoller.Down = Keys.NumPad5;
			player4.Controller.MovementContoller.Left = Keys.NumPad4;
			player4.Controller.MovementContoller.Right = Keys.NumPad6;
			player4.Controller.ThrowContoler.Throw = Keys.NumPad0;

			RegisterPlayerDefaultHooks(player4.Controller);

			this._playerRecordsList.Add(PLAYER1_RECORD_TAG, player1);
			this._playerRecordsList.Add(PLAYER2_RECORD_TAG, player2);
			this._playerRecordsList.Add(PLAYER3_RECORD_TAG, player3);
			this._playerRecordsList.Add(PLAYER4_RECORD_TAG, player4);
		}

		private void RegisterPlayerDefaultHooks(PlayerController controler)
		{
			_pressedKeys.Add(controler.MovementContoller.Jump, false);
			_pressedKeys.Add(controler.MovementContoller.Down, false);
			_pressedKeys.Add(controler.MovementContoller.Left, false);
			_pressedKeys.Add(controler.MovementContoller.Right, false);
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
				case Game.GameState.RUN:
					this.game.TickAction();
					break;
				case Game.GameState.END:
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
				var key = record.Controller.MovementContoller.Jump;

				if(RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controller.MovementContoller.Jump = e.KeyData;
				}
			}
		}

		private void SelectKeyDown(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;
			entity.Text = e.KeyData.ToString();

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controller.MovementContoller.Down;

				if (RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controller.MovementContoller.Down = e.KeyData;
				}
			}
		}

		private void SelectKeyLeft(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;
			entity.Text = e.KeyData.ToString();

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controller.MovementContoller.Left;

				if (RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controller.MovementContoller.Left = e.KeyData;
				}
			}
		}

		private void SelectKeyRight(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;
			entity.Text = e.KeyData.ToString();

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controller.MovementContoller.Right;

				if (RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controller.MovementContoller.Right = e.KeyData;
				}
			}
		}

		private void SelectKeyThrow(object sender, KeyEventArgs e)
		{
			var entity = (TextBox)sender;
			entity.Text = e.KeyData.ToString();

			if (_playerRecordsList.TryGetValue((string)entity.Parent.Tag, out PlayerCreationRecord record))
			{
				var key = record.Controller.ThrowContoler.Throw;

				if (RegisterKeyHook(e.KeyData, key))
				{
					entity.Text = e.KeyData.ToString();
					record.Controller.ThrowContoler.Throw = e.KeyData;
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
