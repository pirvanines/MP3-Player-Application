/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
 *  Copyright:   (c) 2023, Pîrvan Ines-Iuliana                            *
 *  E-mail:      ines-iuliana.pirvan@student.tuiasi.ro                    *
 *  Website:                                                              *
 *  Description: Interfata MP3Player-ului                                 *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mp3_Player;


namespace MP3_Player
{
    public partial class Form1 : Form
    {
        private MusicManager manager = new MusicManager();
        private MusicPlayer musicPlayer = new MusicPlayer();
        List<Song> songs = new List<Song>();
        private MP3PlayerControl Mp3PlayerCtrl = new MP3PlayerControl();
   
        //creez o instanță a clasei Invoker și o utilizez
        //pentru a salva și afișa versurile anterioare
        private Invoker lyricsInvoker = new Invoker();
        
        public Form1()
        {
            InitializeComponent();
            addSongs.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Getter al continutului obiectului <richTextBox>
        public string LyricsTextBox
        {
            get { return richTextBox1.Text; }
        }

        // Event ce semnaleaza schimbarea melodiei ce urmeaza a fi redate
        private void ListBoxSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mp3PlayerCtrl.SelectSongToPlay(listBox.SelectedIndex, playList.SelectedIndex);
            richTextBox1.Text = string.Empty;
        }

        // Event ce semnaleaza schimbarea playlistului curent
        private void ListBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            addSongs.Enabled = true;
            Mp3PlayerCtrl.ListSongsFromPlaylist(playList.SelectedIndex, listBox);
        }

        // Event ce semnaleaza trecerea la melodia anterioara
        // Momentan poate sa redea doar versurile melodiei anterioare
        // fara sa redea si melodia (mai e nevoie de un obiect comanda)
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (lyricsInvoker != null)
            {
                lyricsInvoker.Undo();
                richTextBox1.Text = lyricsInvoker.GetCurrentLyrics();

                /*int currentIndexP = playList.SelectedIndex;
                int currentIndexS = listBox.SelectedIndex;
                listBox.SelectedIndex = Mp3PlayerCtrl.PrevSong(currentIndexP, currentIndexS);
                buttonStopPlay.Text = Mp3PlayerCtrl.PlaySong();*/
            }
        }

        // Event pentru incarcarea versurilor in <RichBox>
        private void loadLyrics(object sender, EventArgs e)
        {
            Mp3PlayerCtrl.LoadLyrics(richTextBox1, listBox, lyricsInvoker);
        }
        
        // Event de adaugare a unei noi liste de redare 
        private void addPlaylist(object sender, EventArgs e)
        {
            Mp3PlayerCtrl.AddPlaylist(playList, numePlaylist);
        }

        // Event de stergere a unui playlist selectat din <ListBox>
        private void DeletePlaylist(object sender, EventArgs e)
        {
            Mp3PlayerCtrl.DeletePlaylist(playList.SelectedIndex, playList);
        }

        // Event ce declanseaza adaugarea unor melodii in playlistul 
        // selectat in <ListBox>
        [STAThread]
        private void AddSongToPlaylist(object sender, EventArgs e)
        {
            Mp3PlayerCtrl.AddSongsToPlaylist(playList.SelectedIndex, listBox);
        }

        // Event ce declanseaza redarea/pauza unei melodii
        private void PlaySong(object sender, EventArgs e)
        {
            buttonStopPlay.Text = Mp3PlayerCtrl.PlaySong();
        }

        // Event ce declanseaza stergerea unei melodii
        private void DeleteSongs(object sender, EventArgs e)
        {
            Mp3PlayerCtrl.DeleteSong(playList.SelectedIndex, listBox.SelectedIndex, listBox);
        }

        // Event ce extrage valoarea din <TrackBar>, converteste
        // valoarea in intervalul [0,1] si o seteaza obiectului de tip <MusicPlayer>
        private void Volume(object sender, EventArgs e)
        {
            int volume = trackBar2.Value;
            float volumeNormalized = volume / 100f;
            musicPlayer.SetVolume(volumeNormalized);
        }

        // Event pentru deschiderea ferestrei Help
        private void HelpButton(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MP3Player.chm");
        }

        private void NextSong(object sender, EventArgs e)
        {
            int currentIndexP = playList.SelectedIndex;
            int currentIndexS = listBox.SelectedIndex;
            listBox.SelectedIndex = Mp3PlayerCtrl.NextSong(currentIndexP, currentIndexS);
            buttonStopPlay.Text = Mp3PlayerCtrl.PlaySong();
        }
    }
}
