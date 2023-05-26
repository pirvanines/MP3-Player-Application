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
        private MusicManager manager = new MusicManager();
        private MusicPlayer musicPlayer = new MusicPlayer();
        List<Song> songs = new List<Song>();

        // Pentru versuri
        private string currentLyrics;
        private int currentSong;


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

        //returnez textul din textbox
        public string LyricsTextBox
        {
            get { return richTextBox1.Text; }
        }


        // Daca un element a fost selectat din lista de melodii, atunci playerul
        // initializeaza urmatoarea melodie de redare cu melodia pe care tocmai
        // am selectat-o
        private void ListBoxSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Song melodie = manager.GetPlaylistByIndex(playList.SelectedIndex).getSong(listBox.SelectedIndex);
            musicPlayer.SetSong(melodie);
            buttonStopPlay.Text = musicPlayer.PlayButtonText();
            richTextBox1.Text = string.Empty;
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

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            //am apasat pe buton
            if (lyricsInvoker != null)
            {
                lyricsInvoker.Undo();
                richTextBox1.Text = lyricsInvoker.GetCurrentLyrics();
            }
        }

        private void loadLyrics(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text) && (listBox.SelectedIndex != -1))
            {
                //richTextBox1.Text = string.Empty;
                Lyrics lyrics = new Lyrics();
                string selectedLyrics = lyrics.OpenFileDialogAndSaveLyrics();
                richTextBox1.Text = selectedLyrics;
                currentLyrics = richTextBox1.Text;
                // Crearea comenzii și executarea acesteia
                ICommand lyricsCommand = new LyricsCommand(currentLyrics, richTextBox1);
                lyricsInvoker.ExecuteCommand(lyricsCommand, currentLyrics);
            }
            else if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Ati adaugat deja versuri pentru melodie.");
            }
            else if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Pentru a adauga versuri trebuie sa selectati mai intai o melodie.");
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

        private void DeleteSongs(object sender, EventArgs e)
        {
            int selectedPlaylistIndex = playList.SelectedIndex;
            int selectedSongIndex = listBox.SelectedIndex;

            if (selectedPlaylistIndex >= 0 && selectedSongIndex >= 0)
            {
                Playlist selectedPlaylist = manager.GetPlaylistByIndex(selectedPlaylistIndex);
                Song selectedSong = selectedPlaylist.getSong(selectedSongIndex);

                if (selectedSong != null)
                {
                    manager.DeleteSong(selectedSong, selectedPlaylistIndex);
                    listBox.Items.RemoveAt(selectedSongIndex);
                }
                else
                {
                    MessageBox.Show("Selectați un cântec pentru a șterge.", "Eroare");
                }
            }
            else
            {
                MessageBox.Show("Selectați un playlist și un cântec pentru a șterge.", "Eroare");
            }
        }

    }
}
