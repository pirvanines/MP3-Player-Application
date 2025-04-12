/**************************************************************************
 *                                                                        *
 *  File:        UnitTest1.cs                                             *
 *  Copyright:   (c) 2023, Pîrvan Ines-Iuliana                            *
 *  E-mail:      ines-iuliana.ines@student.tuiasi.ro                      *
 *  Description: Realizeaza teste pentru clasele MusicPlayer, Playlist,   *
 *               MusicManager.                                            *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MP3_Player;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private string name = "Black Eyed Peas - MAMACITA (Letra Lyrics) Ozuna, J. Rey Soul.mp3";
        private string path = "D:/IP/Florina_FinalState/IP_team/Music/Music";

        [TestMethod]
        public void Test_MusicPlayer_1()
        {
            Song song = new Song(name, path);

            MP3_Player.MusicPlayer mp = new MP3_Player.MusicPlayer();
            mp.SetSong(song);

            Assert.AreEqual(0, mp.State());
        }

        [TestMethod]
        public void Test_MusicPlayer_2()
        {
            Song song = new Song(name, path);

            MP3_Player.MusicPlayer mp = new MP3_Player.MusicPlayer();
            mp.SetSong(song);
            mp.StopSong();

            Assert.AreEqual(0, mp.State());
        }

        [TestMethod]
        public void Test_Playlist_1()
        {
            MP3_Player.Playlist playlist = new MP3_Player.Playlist("Playlist de test");

            Assert.AreEqual(null, playlist.getSong(0));
        }

        [TestMethod]
        public void Test_Playlist_2()
        {
            Song song = new Song(name, path);
            MP3_Player.Playlist playlist = new MP3_Player.Playlist("Playlist de test");

            playlist.Add(song);

            Assert.IsTrue((playlist.getSong(0) != null));
        }

        [TestMethod]
        public void Test_Playlist_3()
        {
            Song song = new Song(name, path);
            Playlist playlist = new Playlist("Playlist de test");

            playlist.Add(song);
            playlist.Remove(song);

            Assert.IsTrue((playlist.getSong(0) == null));
        }

        [TestMethod]
        public void Test_MusicManager_1()
        {
            Song song = new Song(name, path);
            Playlist playlist = new Playlist("Playlist de test 1");
            MusicManager playlists = new MusicManager();

            playlist.Add(song);
            playlist.Add(song);
            playlists.AddPlaylist(playlist);

            Assert.IsTrue((playlists.GetPlaylistByName("Playlist de test 1") != null));
        }

        [TestMethod]
        public void Test_MusicManager_2()
        {
            Song song = new Song(name, path);
            Playlist playlist1 = new Playlist("Playlist de test 1");
            Playlist playlist2 = new Playlist("Playlist de test 2");
            MusicManager playlists = new MusicManager();

            playlist1.Add(song);
            playlist1.Add(song);
            playlists.AddPlaylist(playlist1);

            playlist2.Add(song);
            playlist2.Add(song);
            playlists.AddPlaylist(playlist2);

            Assert.IsTrue((playlists.GetPlaylistByIndex(1) != null));
        }

        [TestMethod]
        public void Test_MusicManager_3()
        {
            MusicManager playlists = new MusicManager();

            Assert.IsTrue((playlists.GetPlaylistByIndex(1) == null));
        }

        [TestMethod]
        public void Test_MusicManager_4()
        {
            MusicManager playlists = new MusicManager();

            Assert.IsTrue((playlists.GetPlaylistByName("Playlist de test 1") == null));
        }

        [TestMethod]
        public void Test_MusicManager_5_AddSongTo_Playlists_index1()
        {
            Song song = new Song(name, path);
            MusicManager playlists = new MusicManager();

            playlists.AddSong(song,0);

            Assert.IsTrue((playlists.GetPlaylistByIndex(0) == null));
        }

        [TestMethod]
        public void Test_MusicManager_6_DeletePlaylistFrom_Playlist()
        {
            Song song = new Song(name, path);
            Playlist playlist1 = new Playlist("Playlist de test 1");
            Playlist playlist2 = new Playlist("Playlist de test 2");
            MusicManager playlists = new MusicManager();

            playlist1.Add(song);
            playlist1.Add(song);
            playlists.AddPlaylist(playlist1);

            playlist2.Add(song);
            playlist2.Add(song);
            playlists.AddPlaylist(playlist2);

            playlists.DeletePlaylist(1);

            Assert.IsTrue((playlists.GetPlaylistByName("Playlist de test 2") == null));
        }

        // Nu se sterge si lista daca am un singur element
        [TestMethod]
        public void Test_MusicManager_7_DeleteSongFrom_Playlist()
        {
            Song song = new Song(name, path);
            Playlist playlist1 = new Playlist("Playlist de test 1");
            MusicManager playlists = new MusicManager();

            playlist1.Add(song);
            playlists.AddPlaylist(playlist1);

            playlists.DeleteSong(song,0);

            Assert.IsTrue((playlists.GetPlaylistByName("Playlist de test 1") == null));
        }
    }
}
