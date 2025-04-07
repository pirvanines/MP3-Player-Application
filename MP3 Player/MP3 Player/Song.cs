/**************************************************************************
 *                                                                        *
 *  File:        Song.cs                                                  *
 *  Copyright:   (c) 2023, Baciu Raluca-Daniela                           *
 *  E-mail:      raluca-daniela.baciu@student.tuiasi.ro                   *
 *  Description: Pentru o melodie se retine calea si numele acesteia.     *
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

public class Song
{
    private string _name;
    private string _filePath;

    public Song()
    {

    }

    public Song(string name, string filePath)
    {
        _name = name;
        _filePath = filePath;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string FilePath
    {
        get { return _filePath; }
        set { _filePath = value; }
    }

}
