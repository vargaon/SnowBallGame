
namespace SnowBallGame
{
	partial class Form1
	{
		/// <summary>
		/// Vyžaduje se proměnná návrháře.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Uvolněte všechny používané prostředky.
		/// </summary>
		/// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kód generovaný Návrhářem Windows Form

		/// <summary>
		/// Metoda vyžadovaná pro podporu Návrháře - neupravovat
		/// obsah této metody v editoru kódu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.game_panel = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.player_panel = new System.Windows.Forms.Panel();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.game_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 20;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// game_panel
			// 
			this.game_panel.BackColor = System.Drawing.Color.Black;
			this.game_panel.Controls.Add(this.panel2);
			this.game_panel.Controls.Add(this.pictureBox4);
			this.game_panel.Controls.Add(this.pictureBox3);
			this.game_panel.Controls.Add(this.pictureBox2);
			this.game_panel.Controls.Add(this.pictureBox1);
			this.game_panel.Controls.Add(this.pictureBox8);
			this.game_panel.Location = new System.Drawing.Point(12, 12);
			this.game_panel.Name = "game_panel";
			this.game_panel.Size = new System.Drawing.Size(1142, 593);
			this.game_panel.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Location = new System.Drawing.Point(0, 597);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1142, 166);
			this.panel2.TabIndex = 3;
			// 
			// player_panel
			// 
			this.player_panel.BackColor = System.Drawing.Color.DimGray;
			this.player_panel.Location = new System.Drawing.Point(12, 612);
			this.player_panel.Name = "player_panel";
			this.player_panel.Size = new System.Drawing.Size(1142, 214);
			this.player_panel.TabIndex = 1;
			this.player_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.player_panel_Paint);
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackColor = System.Drawing.Color.Sienna;
			this.pictureBox4.Image = global::SnowBallGame.Properties.Resources.platform;
			this.pictureBox4.Location = new System.Drawing.Point(631, 307);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(220, 10);
			this.pictureBox4.TabIndex = 19;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Tag = "platform";
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Sienna;
			this.pictureBox3.Image = global::SnowBallGame.Properties.Resources.platform;
			this.pictureBox3.Location = new System.Drawing.Point(110, 228);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(220, 10);
			this.pictureBox3.TabIndex = 18;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Tag = "platform";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Sienna;
			this.pictureBox2.Image = global::SnowBallGame.Properties.Resources.platform;
			this.pictureBox2.Location = new System.Drawing.Point(791, 228);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(220, 10);
			this.pictureBox2.TabIndex = 17;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Tag = "platform";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Sienna;
			this.pictureBox1.Image = global::SnowBallGame.Properties.Resources.platform;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(251, 307);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(220, 10);
			this.pictureBox1.TabIndex = 16;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Tag = "platform";
			// 
			// pictureBox8
			// 
			this.pictureBox8.BackColor = System.Drawing.Color.Sienna;
			this.pictureBox8.Image = global::SnowBallGame.Properties.Resources.platform;
			this.pictureBox8.Location = new System.Drawing.Point(445, 394);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(220, 10);
			this.pictureBox8.TabIndex = 15;
			this.pictureBox8.TabStop = false;
			this.pictureBox8.Tag = "platform";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(1166, 838);
			this.Controls.Add(this.player_panel);
			this.Controls.Add(this.game_panel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SnowBallGame";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			this.game_panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel game_panel;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel player_panel;
	}
}

