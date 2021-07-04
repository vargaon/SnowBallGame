
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
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.platform_4 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.game_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.platform_4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
			this.game_panel.Controls.Add(this.pictureBox4);
			this.game_panel.Controls.Add(this.pictureBox3);
			this.game_panel.Controls.Add(this.pictureBox2);
			this.game_panel.Controls.Add(this.pictureBox1);
			this.game_panel.Controls.Add(this.pictureBox5);
			this.game_panel.Controls.Add(this.platform_4);
			this.game_panel.Location = new System.Drawing.Point(61, 46);
			this.game_panel.Name = "game_panel";
			this.game_panel.Size = new System.Drawing.Size(1126, 664);
			this.game_panel.TabIndex = 0;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Black;
			this.pictureBox2.Location = new System.Drawing.Point(282, 319);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(217, 11);
			this.pictureBox2.TabIndex = 10;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Tag = "platform";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Location = new System.Drawing.Point(439, 489);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(217, 11);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Tag = "platform";
			// 
			// pictureBox5
			// 
			this.pictureBox5.BackColor = System.Drawing.Color.Black;
			this.pictureBox5.Location = new System.Drawing.Point(186, 412);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(217, 11);
			this.pictureBox5.TabIndex = 8;
			this.pictureBox5.TabStop = false;
			this.pictureBox5.Tag = "platform";
			// 
			// platform_4
			// 
			this.platform_4.BackColor = System.Drawing.Color.Black;
			this.platform_4.Location = new System.Drawing.Point(707, 421);
			this.platform_4.Name = "platform_4";
			this.platform_4.Size = new System.Drawing.Size(217, 11);
			this.platform_4.TabIndex = 3;
			this.platform_4.TabStop = false;
			this.platform_4.Tag = "platform";
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Black;
			this.pictureBox3.Location = new System.Drawing.Point(579, 332);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(217, 11);
			this.pictureBox3.TabIndex = 11;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Tag = "platform";
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackColor = System.Drawing.Color.Black;
			this.pictureBox4.Location = new System.Drawing.Point(426, 227);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(217, 11);
			this.pictureBox4.TabIndex = 12;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Tag = "platform";
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.platform_4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel game_panel;
		private System.Windows.Forms.PictureBox platform_4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox3;
	}
}

