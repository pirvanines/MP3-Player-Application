using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3_Player
{
    public class Playlist
    {
        private string _name;
        private List<Song> _songs;

        public Playlist(string nume)
        {
            _name = nume;
            _songs = new List<Song>();
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Song> Songs
        {
            get { return _songs; }
            set { _songs = value; }
        }

        public Song getSong(int index)
        {
            if (index < _songs.Count)
                return _songs[index];
            return null;
        }

        public void Add(Song song)
        {
            _songs.Add(song);
        }

        public void Remove(Song song)
        {
            _songs.Remove(song);
        }
    }
}
