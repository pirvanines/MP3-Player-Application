
namespace MP3_Player
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.playList = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.addSongs = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonStopPlay = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.numePlaylist = new System.Windows.Forms.TextBox();
            this.Nume = new System.Windows.Forms.Label();
            this.Help = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.playList);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Location = new System.Drawing.Point(44, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(314, 405);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PlayList";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(152, 342);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(142, 55);
            this.button6.TabIndex = 12;
            this.button6.Text = "Delete";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.DeletePlaylist);
            // 
            // playList
            // 
            this.playList.FormattingEnabled = true;
            this.playList.ItemHeight = 20;
            this.playList.Location = new System.Drawing.Point(14, 35);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(282, 304);
            this.playList.TabIndex = 10;
            this.playList.SelectedIndexChanged += new System.EventHandler(this.ListBoxPlaylist_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(14, 342);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 55);
            this.button5.TabIndex = 11;
            this.button5.Text = "Add";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.addPlaylist);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.listBox);
            this.groupBox3.Controls.Add(this.addSongs);
            this.groupBox3.Location = new System.Drawing.Point(381, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 212);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Melodii";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 55);
            this.button2.TabIndex = 21;
            this.button2.Text = "Delete Songs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DeleteSongs);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(6, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(457, 124);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBoxSong_SelectedIndexChanged);
            // 
            // addSongs
            // 
            this.addSongs.Location = new System.Drawing.Point(6, 151);
            this.addSongs.Name = "addSongs";
            this.addSongs.Size = new System.Drawing.Size(225, 55);
            this.addSongs.TabIndex = 2;
            this.addSongs.Text = "Add Songs";
            this.addSongs.UseVisualStyleBackColor = true;
            this.addSongs.Click += new System.EventHandler(this.AddSongToPlaylist);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(226, 537);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(385, 99);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = "";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(14, 42);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(172, 69);
            this.trackBar2.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(436, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "next";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.NextSong);
            // 
            // buttonStopPlay
            // 
            this.buttonStopPlay.Location = new System.Drawing.Point(346, 42);
            this.buttonStopPlay.Name = "buttonStopPlay";
            this.buttonStopPlay.Size = new System.Drawing.Size(84, 37);
            this.buttonStopPlay.TabIndex = 4;
            this.buttonStopPlay.Text = "Play";
            this.buttonStopPlay.UseVisualStyleBackColor = true;
            this.buttonStopPlay.Click += new System.EventHandler(this.PlaySong);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(788, 9);
            this.progressBar1.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(266, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 37);
            this.button4.TabIndex = 6;
            this.button4.Text = "prev";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.buttonStopPlay);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.trackBar2);
            this.groupBox1.Location = new System.Drawing.Point(44, 422);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Play";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(381, 642);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(98, 35);
            this.button7.TabIndex = 23;
            this.button7.Text = "Add lyrics";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.loadLyrics);
            // 
            // numePlaylist
            // 
            this.numePlaylist.Location = new System.Drawing.Point(387, 322);
            this.numePlaylist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numePlaylist.Name = "numePlaylist";
            this.numePlaylist.Size = new System.Drawing.Size(148, 26);
            this.numePlaylist.TabIndex = 24;
            // 
            // Nume
            // 
            this.Nume.AutoSize = true;
            this.Nume.Location = new System.Drawing.Point(386, 297);
            this.Nume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Nume.Name = "Nume";
            this.Nume.Size = new System.Drawing.Size(103, 20);
            this.Nume.TabIndex = 25;
            this.Nume.Text = "Nume Playlist";
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(694, 589);
            this.Help.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(112, 35);
            this.Help.TabIndex = 26;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.HelpButton);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 686);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Nume);
            this.Controls.Add(this.numePlaylist);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Mp3 Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListBox playList;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button addSongs;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonStopPlay;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox numePlaylist;
        private System.Windows.Forms.Label Nume;
        private System.Windows.Forms.Button Help;
    }
}

