/**************************************************************************
 *                                                                        *
 *  File:        MusicPlayer.cs                                                *
 *  Copyright:   (c) 2023, Pîrvan Ines-Iuliana                           *
 *  E-mail:      ines-iuliana.ines@student.tuiasi.ro                      *
 *  Description: Descrie funcționalitatea de star/stop a melodiei.        *
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
using NAudio.Wave;

namespace MP3_Player
{
    public class MusicPlayer
    {
        private Song _song;
        private Timer _timer;
        private WaveOutEvent _player;
        private String _playButtonText;
        private int _state;
        VolumeController volumeController;

        public MusicPlayer()
        {
            _player = new WaveOutEvent();
            volumeController = new VolumeController(_player);
        }

        public void SetSong(Song song)
        {
            _song = song;
            _state = 0;
            _playButtonText = "Play";
        }

        public void PlaySong()
        {
            switch (_state)
            {
                case 0:
                    _player.Stop();
                    _player.Init(new AudioFileReader(_song.FilePath));
                    float currentVolume = volumeController.GetVolume(); // Obțineți volumul curent din VolumeController
                    _player.Volume = currentVolume; // Setează volumul player-ului cu volumul curent
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
        private float Clamp(float value, float min, float max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        public void SetVolume(float volume)
        {
            // verific daca am dat play la melodie
            if (_player != null)
            {
                volumeController.SetVolume(volume);
            }
        }

        public int State()
        {
            return _state;
        }
    }
}