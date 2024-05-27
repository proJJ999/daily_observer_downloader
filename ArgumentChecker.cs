using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
{
    public static class ArgumentChecker
    {
        public static (string, string) CheckArguments(string[] args)
        {
            string releasesFile = "C:\\daily_observer\\releases.txt";
            string downloadPath = "C:\\daily_observer\\PDFs";

            if (args.Length == 2)
            {
                releasesFile = args[0];
                downloadPath = args[1];
            }

            return (releasesFile, downloadPath);
        }
    }
}
