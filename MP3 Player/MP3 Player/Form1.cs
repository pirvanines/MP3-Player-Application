using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace MP3_Player
{
    public partial class Form1 : Form
    {
        List<string[]> path = new List<string[]>();

        private MusicManager manager = new MusicManager();
        private MusicPlayer musicPlayer = new MusicPlayer();
        List<Song> songs = new List<Song>();

        public Form1()
        {
            InitializeComponent();
            addSongs.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ListBoxSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Song melodie = manager.GetPlaylistByIndex(playList.SelectedIndex).getSong(listBox.SelectedIndex);
            musicPlayer.SetSong(melodie);
            buttonStopPlay.Text = musicPlayer.PlayButtonText();
        }

        private void ListBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            addSongs.Enabled = true;
            if (playList.SelectedIndex != -1)
            {
                listBox.Items.Clear();
                manager.listSongsName(listBox, playList.SelectedIndex);
            }
        }

        private void addPlaylist(object sender, EventArgs e)
        {
            string playlistName = numePlaylist.Text;

            // Verificați dacă numele playlist-ului nu este gol
            if (!string.IsNullOrWhiteSpace(playlistName))
            {
                // Creați un nou playlist și adăugați-l în MusicManager
                Playlist newPlaylist = new Playlist(playlistName);
                manager.AddPlaylist(newPlaylist);

                // Adăugați numele playlist-ului în listbox
                playList.Items.Add(playlistName);

                // Goliți caseta de text pentru numele playlist-ului
                numePlaylist.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Introduceți un nume valid pentru playlist.", "Eroare");
            }

        }

        private void DeletePlaylist(object sender, EventArgs e)
        {
            if (playList.SelectedIndex >= 0)
            {
                // Ștergeți playlist-ul din MusicManager
                manager.DeletePlaylist(playList.SelectedIndex);

                // Ștergeți numele playlist-ului din listbox
                playList.Items.RemoveAt(playList.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selectați un playlist pentru a șterge.", "Eroare");
            }
        }

        [STAThread]
        private void AddSongToPlaylist(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //files = openFileDialog.SafeFileNames;
                //paths = openFileDialog.FileNames;


                foreach (String file in openFileDialog.SafeFileNames)
                {
                    Song song = new Song();
                    song.Name = file;
                    songs.Add(song);

                }

                int j = 0;
                foreach (String path in openFileDialog.FileNames)
                {
                    songs[j].FilePath = path;
                    j++;
                }

                for (int i = 0; i < songs.Count; i++)
                {
                    listBox.Items.Add(songs[i].Name);
                }

                foreach (Song song in songs)
                {
                    manager.AddSong(song, playList.SelectedIndex);
                }

                songs.Clear();
            }
        }

        private void playSong(object sender, EventArgs e)
        {
            musicPlayer.PlaySong();
            buttonStopPlay.Text = musicPlayer.PlayButtonText();
        }

    }
}
