using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3_Player
{
    class MusicManager
    {
        private List<Playlist> playlists;

        public MusicManager()
        {
            playlists = new List<Playlist>();
        }

        public void listPlaylistName( ListBox listbox)
        {
            foreach( Playlist lista in playlists)
            {
                string nume = lista.Name;
                listbox.Items.Add(nume);
            }
        }

        //Aceasta functie trebuie mutata
        public void listSongsName(ListBox listbox, int index)
        {
            foreach (Song song in playlists[index].Songs)
            {
                listbox.Items.Add(song.Name);
            }
        }
        public void AddPlaylist(Playlist playlist)
        {
            playlists.Add(playlist);
            Console.WriteLine($"Playlist '{playlist.Name}' added.");
        }

        public void DeletePlaylist(int index)
        {
            playlists.RemoveAt(index);
        }

        public Playlist GetPlaylistByName(string nume)
        {
            foreach (Playlist lista in playlists)
            {
                if(lista.Name == nume)
                {
                    return lista;
                }
            }

            return null;
        }

        public Playlist GetPlaylistByIndex(int index)
        {
            if (index < playlists.Capacity)
                return playlists[index];
            return null;
        }

        //internal void listPlaylistName(object playlistListBox)
        //{
        //throw new NotImplementedException();
        //}

        public void AddSong(Song song, int index)
        {
            if (index >= 0 && index < playlists.Count)
            {
                playlists[index].Add(song);
               // Console.WriteLine($"Song '{song.Title}' added to playlist '{playlists[index].Name}'.");
            }
            else
            {
                Console.WriteLine($"Invalid playlist index: {index}");
            }
             
        }

        public void DeleteSong(Song song, int index)
        {
            if (index >= 0 && index < playlists.Count)
            {
                playlists[index].Remove(song);
               // Console.WriteLine($"Song '{song.Title}' removed from playlist '{playlists[index].Name}'.");
            }
            else
            {
                Console.WriteLine($"Invalid playlist index: {index}");
            }
            
        }

        
    }
}
