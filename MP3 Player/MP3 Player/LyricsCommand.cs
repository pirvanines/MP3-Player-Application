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
