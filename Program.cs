using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
{
    public class Program
    {
        static void Main(string[] args)
        {
            string releases = "C:\\daily_observer\\releases.txt";
            string downloadPath = "C:\\daily_observer\\PDFs";
            Controller c = new Controller();
            c.DownloadAllMagazines(releases, downloadPath);
        }
    }
}
