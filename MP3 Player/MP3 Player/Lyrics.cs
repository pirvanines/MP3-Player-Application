/**************************************************************************
 *                                                                        *
 *  File:        Lyrics.cs                                                *
 *  Copyright:   (c) 2023, Apostol Roxana-Maria                           *
 *  E-mail:      roxana-maria.apostol@student.tuiasi.ro                   *
 *  Description: Descrie procesul de adaugare a versurilor la melodii.    *
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
    class Lyrics
    {
        //variabila de tip textbox in care voi salva ceea ce introduce utilizatorul ca si lyrics
        private string lyricsTextBox;

        public string addLyrics()
        {
            return lyricsTextBox;
        }

        //deschid fisierul de unde vreau sa adaug versurile pentru melodie
        public string OpenFileDialogAndSaveLyrics()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.Title = "Selectează fișierul cu versuri pe care vrei sa il adaugi.";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Returnează conținutul fișierului
                    return System.IO.File.ReadAllText(filePath);
                }
            }
            // În cazul în care nu a fost selectat niciun fișier nu returnez nimic
            return string.Empty; 
        }

        //adaug versurile din document in textbox
        private void SaveLyrics(string filePath)
        {
            string lyricsText = lyricsTextBox;
            System.IO.File.WriteAllText(filePath, lyricsText);
            MessageBox.Show("Lyrics-ul a fost salvat cu succes!");
        }
    }
}
