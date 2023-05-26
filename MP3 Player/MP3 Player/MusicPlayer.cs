using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace MP3_Player
{
    class MusicPlayer
    {
        private Song _song;
        private Timer _timer;
        private WaveOutEvent _player;
        private String _playButtonText;
        private int _state;

        public MusicPlayer()
        {
            _player = new WaveOutEvent();
        }

        public void SetSong(Song song)
        {
            _song = song;
            _state = 0;
            _playButtonText = "Play";
        }

        public void PlaySong()
        {
            switch(_state)
            {
                case 0:
                    _player.Stop();
                    _player.Init(new AudioFileReader(_song.FilePath));
                    _playButtonText = "Pause";
                    _player.Play();
                    _state = 1;
                    break;
                case 1:
                    _player.Pause();
                    _playButtonText = "Play";
                    _state = 2;
                    break;
                case 2:
                    _player.Play();
                    _playButtonText = "Pause";
                    _state = 1;
                    break;
                default:
                    throw new Exception("State not found...");
            }
        }

        public void StopSong()
        {
            _player.Stop();
            _playButtonText = "Play";
            _state = 0;
        }

        public String PlayButtonText()
        {
            return _playButtonText;
        }


    }
}
