/**************************************************************************
 *                                                                        *
 *  File:        LyricsCommand.cs                                         *
 *  Copyright:   (c) 2023, Apostol Roxana-Maria                           *
 *  E-mail:      roxana-maria.apostol@student.tuiasi.ro                   *
 *  Description: Descrie starea versurilor, daca apartin melodiei curente *
 *  sau precedente.                                                       *
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
    class LyricsCommand:ICommand
    {
        private string lyrics;
        private RichTextBox lyricsTextBox; 
        private string previousLyrics; //versurile de la melodia precedenta
        private string currentLyrics; //versurile de la melodia curenta
        
        public string CurrentLyrics { get; set; }

        public LyricsCommand(string currentLyrics, RichTextBox lyricsTextBox)
        {
            this.currentLyrics = currentLyrics;
            this.previousLyrics = lyricsTextBox.Text;
            this.lyricsTextBox = lyricsTextBox;
        }

        //afiseaza versurile curente 
        public void Execute()
        {
            // Salvarea versurilor anterioare
            previousLyrics = lyricsTextBox.Text;

            // Actualizarea versurilor curente
            lyricsTextBox.Text = currentLyrics;
        }

        // Restaurarea versurilor anterioare
        public void Undo()
        {
            lyricsTextBox.Text = previousLyrics;
        }

        //returnez versurile curente
        public string GetCurrentLyrics()
        {
            return currentLyrics;
        }

    }
}
