﻿using System;
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

