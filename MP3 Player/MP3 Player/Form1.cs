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

        // Daca un element a fost selectat din lista de melodii, atunci playerul
        // initializeaza urmatoarea melodie de redare cu melodia pe care tocmai
        // am selectat-o
        private void ListBoxSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Song melodie = manager.GetPlaylistByIndex(playList.SelectedIndex).getSong(listBox.SelectedIndex);
            musicPlayer.SetSong(melodie);
            buttonStopPlay.Text = musicPlayer.PlayButtonText();
        }


        // Daca playlistul curent a fost schimbat atunci se afiseaza in ListBox melodiile 
        // corespunzatoare playlistului curent
        private void ListBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            addSongs.Enabled = true;
            if (playList.SelectedIndex != -1)
            {
                listBox.Items.Clear();
                manager.listSongsName(listBox, playList.SelectedIndex);
            }
        }


        // La apasarea butonului Add Playlist se creaza un nou obiect de tip
        // playlist cu numele pe care il primeste din TextBox-ul "Nume Playlist"
        // care va fi inserat in lista de redare
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


        // Daca exista un playlist selectat atunci la apasarea butonului Delete
        // se sterge din lista de redare elementul cu indexul aferent
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


        // Adaugarea unor fisiere de tip .mp3 in playlistul selectat curent 
        [STAThread]
        private void AddSongToPlaylist(object sender, EventArgs e)
        {
            // Se deschide o fereastra in care putem naviga pentru a selecta fisierele
            // pe care vrem sa le importam
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;


            // Adaugam noi obiecte <Song> in playlist, obiecte initializate cu 
            // campurile file si path ale fisierelor selectate din fereastra
            // proaspat deschisa; daca fereastra s-a deschis:
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Initializam campul file al obiectelor de tip <Song>
                foreach (String file in openFileDialog.SafeFileNames)
                {
                    Song song = new Song();
                    song.Name = file;
                    songs.Add(song);
                }

                // Initializam campul path al obiectelor de tip <Song>
                int j = 0;
                foreach (String path in openFileDialog.FileNames)
                {
                    songs[j].FilePath = path;
                    j++;
                }

                // Adaugam obiectele <Song> create anterior in playlistul curent
                foreach (Song song in songs)
                {
                    manager.AddSong(song, playList.SelectedIndex);
                }

                // Afisam obiectele <Song> in ListBox si curatam lista pentru
                // urmatoarea incarcare
                for (int i = 0; i < songs.Count; i++)
                {
                    listBox.Items.Add(songs[i].Name);
                }
                songs.Clear();
            }
        }


        // La apasarea butonului Play se apeleaza state-machineul care
        // decide starea butonului si intoarce un text care va fi afisat pe buton
        // in functie de aceasta stare curenta
        private void playSong(object sender, EventArgs e)
        {
            musicPlayer.PlaySong();
            buttonStopPlay.Text = musicPlayer.PlayButtonText();
        }

    }
}
