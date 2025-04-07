/**************************************************************************
 *                                                                        *
 *  File:        Playlist.cs                                              *
 *  Copyright:   (c) 2023, Baciu Raluca-Daniela                           *
 *  E-mail:      raluca-daniela.baciu@student.tuiasi.ro                   *
 *  Description:   This file describes the Playlist Model.                *
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
            if (index >= 0 && index < _songs.Count)
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

        public int SongsNumber()
        {
            return _songs.Count;
        }
    }
}
