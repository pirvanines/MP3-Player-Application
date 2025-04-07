/**************************************************************************
 *                                                                        *
 *  File:        MP3PlayerControl.cs                                      *
 *  Copyright:   (c) 2023, Nistor Florina-Dumitrita                       *
 *  E-mail:      dumitrita-florina.nistor@student.tuiasi.ro               *
 *  Description: Descrie fațada programului, un alt șablon de proiectare. *
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
using MP3_Player;


namespace Mp3_Player
{
    public class MP3PlayerControl
    {
        private MusicManager _filesManager ;
        private MusicPlayer _musicPlayerManager;
        private List<Song> _songs;
        private string _currentLyrics;
        
        public MP3PlayerControl()
        {
            _filesManager = new MusicManager();
            _musicPlayerManager = new MusicPlayer();
            _songs = new List<Song>();
        }

        // Daca un element a fost selectat din lista de melodii, atunci playerul
        // initializeaza urmatoarea melodie de redare cu melodia pe care tocmai
        // am selectat-o
        public string SelectSongToPlay(int indexS, int indexP)
        {
            string text;
            Song melodie = _filesManager.GetPlaylistByIndex(indexP).getSong(indexS);
            _musicPlayerManager.SetSong(melodie);
            text =  _musicPlayerManager.PlayButtonText();
            return text;
        }

        // Daca playlistul curent a fost schimbat atunci se afiseaza in ListBox melodiile 
        // corespunzatoare playlistului curent
        public void ListSongsFromPlaylist(int indexP, ListBox listBoxSongs)
        {
            if (indexP != -1)
            {
                listBoxSongs.Items.Clear();
                _filesManager.ListSongsName(listBoxSongs, indexP);
            }
        }

        // La apasarea butonului Add Playlist se creaza un nou obiect de tip
        // playlist cu numele pe care il primeste din TextBox-ul "Nume Playlist"
        // care va fi inserat in lista de redare
        public void AddPlaylist(ListBox listBoxPlaylist, TextBox namePlaylist)
        {
            try
            {
                // Verificați dacă numele playlist-ului nu este gol
                if (!string.IsNullOrWhiteSpace(namePlaylist.Text))
                {
                    // Creați un nou playlist și adăugați-l în MusicManager
                    Playlist newPlaylist = new Playlist(namePlaylist.Text);
                    _filesManager.AddPlaylist(newPlaylist);

                    // Adăugați numele playlist-ului în listbox
                    listBoxPlaylist.Items.Add(namePlaylist.Text);

                    // Goliți caseta de text pentru numele playlist-ului
                    namePlaylist.Text = string.Empty;
                }
                else
                {
                    throw new Exception("Introduceți un nume valid pentru playlist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o excepție: " + ex.Message, "Eroare");
            }
        }

        // Daca exista un playlist selectat atunci la apasarea butonului Delete
        // se sterge din lista de redare elementul cu indexul aferent
        public void DeletePlaylist(int indexP, ListBox listBoxPlaylist)
        {
            try
            {
                if (indexP >= 0)
                {
                    // Ștergeți playlist-ul din MusicManager
                    _filesManager.DeletePlaylist(indexP);

                    // Ștergeți numele playlist-ului din listbox
                    listBoxPlaylist.Items.RemoveAt(indexP);
                }
                else
                {
                    throw new Exception("Selectați un playlist pentru a șterge.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o excepție: " + ex.Message, "Eroare");
            }
        }

        // Adaugarea unor fisiere de tip .mp3 in playlistul selectat curent 
        public void AddSongsToPlaylist(int indexP, ListBox listBoxSongs)
        {
            
            // Se deschide o fereastra in care putem naviga pentru a selecta fisierele
            // pe care vrem sa le importam
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
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
                    _songs.Add(song);
                }

                // Initializam campul path al obiectelor de tip <Song>
                int j = 0;
                foreach (String path in openFileDialog.FileNames)
                {
                    _songs[j].FilePath = path;
                    j++;
                }

                // Adaugam obiectele <Song> create anterior in playlistul curent
                foreach (Song song in _songs)
                {
                    _filesManager.AddSong(song, indexP);
                }

                // Afisam obiectele <Song> in ListBox si curatam lista pentru
                // urmatoarea incarcare
                for (int i = 0; i < _songs.Count; i++)
                {
                    listBoxSongs.Items.Add(_songs[i].Name);
                }
                _songs.Clear();
            }
        

        }

        // La apasarea butonului Play se apeleaza state-machineul care
        // decide starea butonului si intoarce un text care va fi afisat pe buton
        // in functie de aceasta stare curenta
        public string PlaySong()
        {
            _musicPlayerManager.PlaySong();
            return _musicPlayerManager.PlayButtonText();
        }

        public void LoadLyrics(RichTextBox richTextBox, ListBox listBox, Invoker lyricsInvoker)
        {
            try
            {
                if (string.IsNullOrEmpty(richTextBox.Text) && (listBox.SelectedIndex != -1))
                {
                    Lyrics lyrics = new Lyrics();
                    string selectedLyrics = lyrics.OpenFileDialogAndSaveLyrics();
                    richTextBox.Text = selectedLyrics;
                    _currentLyrics = richTextBox.Text;

                    // Crearea comenzii și executarea acesteia
                    ICommand lyricsCommand = new LyricsCommand(_currentLyrics, richTextBox);
                    lyricsInvoker.ExecuteCommand(lyricsCommand, _currentLyrics);
                }
                else if (!string.IsNullOrEmpty(richTextBox.Text))
                {
                    throw new Exception("Ați adăugat deja versuri pentru melodie.");
                }
                else if (listBox.SelectedIndex == -1)
                {
                    throw new Exception("Pentru a adăuga versuri trebuie să selectați mai întâi o melodie.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o excepție: " + ex.Message);
            }
        }

        public void DeleteSong(int indexP, int indexS, ListBox listBox)
        {
            try
            {
                // Daca exista melodii in lista
                if (indexP >= 0 && indexS >= 0)
                {
                    Playlist selectedPlaylist = _filesManager.GetPlaylistByIndex(indexP);
                    Song selectedSong = selectedPlaylist.getSong(indexS);

                    if (selectedSong != null)
                    {
                        _filesManager.DeleteSong(selectedSong, indexP);
                        listBox.Items.RemoveAt(indexS);
                    }
                    else
                    {
                        throw new Exception("Selectați un cântec pentru a șterge.");
                    }
                }
                else
                {
                    throw new Exception("Selectați un playlist și un cântec pentru a șterge.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o excepție: " + ex.Message, "Eroare");
            }
        }

        public int NextSong(int indexP, int currentIndex)
        {
            // Incrementăm indexul pentru a obține următorul index
            int nextIndex = currentIndex + 1;

            // Obținem numărul total de melodii în playlist
            int noSongs = _filesManager.GetPlaylistByIndex(indexP).SongsNumber();

            // Verificăm dacă suntem la ultima melodie din playlist
            if (nextIndex >= noSongs)
            {
                nextIndex = 0; // Dacă suntem la ultima melodie, trecem la prima melodie
            }

            // Obținem melodia următoare din playlist
            Song song = _filesManager.GetPlaylistByIndex(indexP).getSong(nextIndex);

            // Setăm melodia în MusicPlayerManager
            _musicPlayerManager.SetSong(song);

            // Returnăm indexul melodiei următoare
            return nextIndex;
        }

        public int PrevSong(int indexP, int currentIndex)
        {
            // Incrementăm indexul pentru a obține următorul index
            int nextIndex = currentIndex - 1;

            // Obținem numărul total de melodii în playlist
            int noSongs = _filesManager.GetPlaylistByIndex(indexP).SongsNumber();

            // Verificăm dacă suntem la ultima melodie din playlist
            if (nextIndex < 0)
            {
                nextIndex = noSongs -1; // Dacă suntem la prima melodie, trecem la prima melodie
            }

            // Obținem melodia următoare din playlist
            Song song = _filesManager.GetPlaylistByIndex(indexP).getSong(nextIndex);

            // Setăm melodia în MusicPlayerManager
            _musicPlayerManager.SetSong(song);

            // Returnăm indexul melodiei următoare
            return nextIndex;
        }


    }

}
