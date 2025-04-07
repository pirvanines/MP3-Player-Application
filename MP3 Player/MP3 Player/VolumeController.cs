/**************************************************************************
 *                                                                        *
 *  File:        VolumeController.cs                                      *
 *  Copyright:   (c) 2023, Apostol Roxana-Maria                           *
 *  E-mail:      roxana-maria.apostol@student.tuiasi.ro                   *
 *  Description: Descrie modul in care poti controla si seta volumul.     *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace MP3_Player
{
    public class VolumeController
    {
        private readonly WaveOutEvent waveOutEvent; // obiect din biblioteca NAudio responsabil cu redarea sunetului
        private float volume; // volumul curent

        public VolumeController(WaveOutEvent _player)
        {
            waveOutEvent = _player; // inițializarea obiectului
            volume = 1.0f; // Volumul inițial este setat la maxim (1.0)
        }

        //setez volumul la o anumita valoare
        public void SetVolume(float newVolume)
        {
            volume = Math.Max(0.0f, Math.Min(newVolume, 1.0f)); // volumul rămâne între 0.0 și 1.0

            if (waveOutEvent.PlaybackState == PlaybackState.Playing)
                waveOutEvent.Volume = volume; // Actualizăm volumul redării dacă suntem în timpul redării
        }

        internal float GetVolume()
        {
            return volume;
        }
    }
}