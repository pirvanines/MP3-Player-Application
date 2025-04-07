/**************************************************************************
 *                                                                        *
 *  File:        MusicManager.cs                                          *
 *  Copyright:   (c) 2023, Baciu Raluca-Daniela                           *
 *  E-mail:      raluca-daniela.baciu@student.tuiasi.ro                   *
 *  Description: Gestionează datele și manipulează melodiile și           *
 *               playlist-urile.                                          *
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
using System.Windows.Forms;

namespace MP3_Player
{
    //Acest cod definește o clasă numită MusicManager
    //care are un câmp privat playlists, care este o listă de obiecte de tipul Playlist.
    //Constructorul inițializează lista playlists.
    public class MusicManager
    {
        private List<Playlist> playlists;

        public MusicManager()
        {
            playlists = new List<Playlist>();
        }

       // Această metodă ListPlaylistName primește un obiect ListBox ca parametru
       // iterează prin fiecare obiect Playlist din lista playlists.
       // Ea extrage numele fiecărui playlist și îl adaugă în controlul listbox.
        public void ListPlaylistName( ListBox listbox)
        {
            foreach( Playlist lista in playlists)
            {
                string nume = lista.Name;
                listbox.Items.Add(nume);
            }
        }

        // Se iterează prin fiecare obiect Song din lista de melodii (Songs) a playlistului cu indexul specificat (index).
        // Numele fiecărei melodii este adăugat în controlul listbox.
        public void ListSongsName(ListBox listbox, int index)
        {
            foreach (Song song in playlists[index].Songs)
            {
                listbox.Items.Add(song.Name);
            }
        }
        //primește un obiect Playlist ca parametru și adaugă playlistul în lista playlists
        public void AddPlaylist(Playlist playlist)
        {
            playlists.Add(playlist);
        }

        //primeste indexul melodiei pe care vreau sa o sterg
        public void DeletePlaylist(int index)
        {
            playlists.RemoveAt(index);
        }

        //primește un nume de playlist ca parametru și returnează playlistul cu acel nume din lista playlists
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
        //primește un index ca parametru și returnează playlistul corespunzător din lista playlists în funcție de index. 
        public Playlist GetPlaylistByIndex(int index)
        {
            if (index < playlists.Capacity)
                return playlists[index];
            return null;
        }


        //primește un obiect Song și un index ca parametri.
        //Adaugă melodia în playlistul corespunzător din lista playlists în funcție de index. 
        public void AddSong(Song song, int index)
        {
            if (index >= 0 && index < playlists.Count)
            {
                playlists[index].Add(song);
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
            }
            else
            {
                Console.WriteLine($"Invalid playlist index: {index}");
            }
        } 
    }
}
