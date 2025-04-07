using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}
