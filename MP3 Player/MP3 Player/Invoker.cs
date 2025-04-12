/**************************************************************************
 *                                                                        *
 *  File:        Invoker.cs                                               *
 *  Copyright:   (c) 2023, Apostol Roxana-Maria                           *
 *  E-mail:      roxana-maria.apostol@student.tuiasi.ro                   *
 *  Description: Descrie realizarea sablonulului de proiectare COMANDA.   *
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
            try
            {
                if (commandHistory.Count > 0)
                {
                    ICommand previousCommand = commandHistory.Peek();
                    if (previousCommand is LyricsCommand lyricsCommand)
                    {
                        return lyricsCommand.GetCurrentLyrics();
                    }
                }

                throw new Exception("Nu am melodii anterioare.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o excepție: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
