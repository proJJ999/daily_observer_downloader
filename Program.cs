﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyObserverDownloader
{
    public class Program
    {
        static void Main(string[] args)
        {
            Controller c = new Controller();
            c.DownloadAllMagazines(args);
        }
    }
}
