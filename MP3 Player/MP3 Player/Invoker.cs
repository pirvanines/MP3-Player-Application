using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3_Player
{
    public class Invoker 
    {
        private Stack<ICommand> commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command,string currentLyrics)
        {
            if (command is LyricsCommand lyricsCommand)
            {
                // seteaza versurile curente în comanda LyricsCommand
                lyricsCommand.CurrentLyrics = currentLyrics;

                // Adaugă comanda în istoricul de comenzi
                commandHistory.Push(lyricsCommand);
            }
            else
            {
                // Adaugă comanda în istoricul de comenzi
                commandHistory.Push(command);
            }
            command.Execute();
        }

        public void Undo()
        {
            //verific ca am mai accesat melodii
            if (commandHistory.Count > 0)
            {
                ICommand previousCommand = commandHistory.Pop();
                previousCommand.Undo();
            }
        }

        public string GetCurrentLyrics()
        {
            if (commandHistory.Count > 0)
            {
                ICommand previousCommand = commandHistory.Peek();
                // Returnez versurile din comanda anterioară
                if (previousCommand is LyricsCommand lyricsCommand)
                {
                    return lyricsCommand.GetCurrentLyrics();
                }
            }
            MessageBox.Show("Nu am melodii anterioare.");
            return string.Empty;
        }
    }
}
