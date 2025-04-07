/**************************************************************************
 *                                                                        *
 *  File:        ICommand.cs                                              *
 *  Copyright:   (c) 2023, Apostol Roxana-Maria                           *
 *  E-mail:      roxana-maria.apostol@student.tuiasi.ro                   *
 *  Description: Descrie interfata Icommand sablonul de proiectare.       *
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

namespace MP3_Player
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
