
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
			this.platform_4 = new System.Windows.Forms.PictureBox();
			this.platform_3 = new System.Windows.Forms.PictureBox();
			this.platform_1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.pictureBox12 = new System.Windows.Forms.PictureBox();
			this.pictureBox14 = new System.Windows.Forms.PictureBox();
			this.game_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.platform_4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.platform_3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.platform_1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 15;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// game_panel
			// 
			this.game_panel.BackColor = System.Drawing.Color.Silver;
			this.game_panel.Controls.Add(this.pictureBox14);
			this.game_panel.Controls.Add(this.pictureBox12);
			this.game_panel.Controls.Add(this.pictureBox11);
			this.game_panel.Controls.Add(this.pictureBox9);
			this.game_panel.Controls.Add(this.pictureBox6);
			this.game_panel.Controls.Add(this.pictureBox5);
			this.game_panel.Controls.Add(this.pictureBox3);
			this.game_panel.Controls.Add(this.pictureBox2);
			this.game_panel.Controls.Add(this.platform_4);
			this.game_panel.Controls.Add(this.platform_3);
			this.game_panel.Controls.Add(this.platform_1);
			this.game_panel.Location = new System.Drawing.Point(61, 46);
			this.game_panel.Name = "game_panel";
			this.game_panel.Size = new System.Drawing.Size(1126, 664);
			this.game_panel.TabIndex = 0;
			// 
			// platform_4
			// 
			this.platform_4.BackColor = System.Drawing.Color.Black;
			this.platform_4.Location = new System.Drawing.Point(604, 357);
			this.platform_4.Name = "platform_4";
			this.platform_4.Size = new System.Drawing.Size(217, 11);
			this.platform_4.TabIndex = 3;
			this.platform_4.TabStop = false;
			this.platform_4.Tag = "platform";
			// 
			// platform_3
			// 
			this.platform_3.BackColor = System.Drawing.Color.Black;
			this.platform_3.Location = new System.Drawing.Point(329, 412);
			this.platform_3.Name = "platform_3";
			this.platform_3.Size = new System.Drawing.Size(220, 10);
			this.platform_3.TabIndex = 2;
			this.platform_3.TabStop = false;
			this.platform_3.Tag = "platform";
			// 
			// platform_1
			// 
			this.platform_1.BackColor = System.Drawing.Color.Black;
			this.platform_1.Location = new System.Drawing.Point(120, 501);
			this.platform_1.Name = "platform_1";
			this.platform_1.Size = new System.Drawing.Size(514, 12);
			this.platform_1.TabIndex = 0;
			this.platform_1.TabStop = false;
			this.platform_1.Tag = "platform";
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Black;
			this.pictureBox2.Location = new System.Drawing.Point(475, 285);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(217, 11);
			this.pictureBox2.TabIndex = 5;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Tag = "platform";
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Black;
			this.pictureBox3.Location = new System.Drawing.Point(796, 297);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(217, 11);
			this.pictureBox3.TabIndex = 6;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Tag = "platform";
			// 
			// pictureBox5
			// 
			this.pictureBox5.BackColor = System.Drawing.Color.Black;
			this.pictureBox5.Location = new System.Drawing.Point(31, 412);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(217, 11);
			this.pictureBox5.TabIndex = 8;
			this.pictureBox5.TabStop = false;
			this.pictureBox5.Tag = "platform";
			// 
			// pictureBox6
			// 
			this.pictureBox6.BackColor = System.Drawing.Color.Black;
			this.pictureBox6.Location = new System.Drawing.Point(308, 210);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(217, 11);
			this.pictureBox6.TabIndex = 9;
			this.pictureBox6.TabStop = false;
			this.pictureBox6.Tag = "platform";
			// 
			// pictureBox9
			// 
			this.pictureBox9.BackColor = System.Drawing.Color.Black;
			this.pictureBox9.Location = new System.Drawing.Point(475, 119);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(217, 11);
			this.pictureBox9.TabIndex = 12;
			this.pictureBox9.TabStop = false;
			this.pictureBox9.Tag = "platform";
			// 
			// pictureBox11
			// 
			this.pictureBox11.BackColor = System.Drawing.Color.Black;
			this.pictureBox11.Location = new System.Drawing.Point(218, 64);
			this.pictureBox11.Name = "pictureBox11";
			this.pictureBox11.Size = new System.Drawing.Size(217, 11);
			this.pictureBox11.TabIndex = 14;
			this.pictureBox11.TabStop = false;
			this.pictureBox11.Tag = "platform";
			// 
			// pictureBox12
			// 
			this.pictureBox12.BackColor = System.Drawing.Color.Black;
			this.pictureBox12.Location = new System.Drawing.Point(635, 566);
			this.pictureBox12.Name = "pictureBox12";
			this.pictureBox12.Size = new System.Drawing.Size(217, 11);
			this.pictureBox12.TabIndex = 15;
			this.pictureBox12.TabStop = false;
			this.pictureBox12.Tag = "platform";
			// 
			// pictureBox14
			// 
			this.pictureBox14.BackColor = System.Drawing.Color.Black;
			this.pictureBox14.Location = new System.Drawing.Point(680, 53);
			this.pictureBox14.Name = "pictureBox14";
			this.pictureBox14.Size = new System.Drawing.Size(217, 11);
			this.pictureBox14.TabIndex = 17;
			this.pictureBox14.TabStop = false;
			this.pictureBox14.Tag = "platform";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1257, 766);
			this.Controls.Add(this.game_panel);
			this.Name = "Form1";
			this.Text = "Form1";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			this.game_panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.platform_4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.platform_3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.platform_1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel game_panel;
		private System.Windows.Forms.PictureBox platform_4;
		private System.Windows.Forms.PictureBox platform_3;
		private System.Windows.Forms.PictureBox platform_1;
		private System.Windows.Forms.PictureBox pictureBox14;
		private System.Windows.Forms.PictureBox pictureBox12;
		private System.Windows.Forms.PictureBox pictureBox11;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
	}
}

