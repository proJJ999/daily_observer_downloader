using PDF_Downloader.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
{
    public static class ArgumentChecker
    {
        public static DownloadArguments CheckArguments(string[] args)
        {
            string releasesFile = "C:\\daily_observer\\releases.txt";
            string downloadPath = "C:\\daily_observer\\PDFs";
            bool deleteSinglePagesFlag = true;

            if (args.Length == 3)
            {
                releasesFile = args[0];
                downloadPath = args[1];
                deleteSinglePagesFlag = InterpretFlag(args[2]);
            }

            DownloadArguments downloadArguments = new DownloadArguments();
            downloadArguments.releasesFile = releasesFile;
            downloadArguments.downloadPath = downloadPath;
            downloadArguments.deleteSinglePagesFlag= deleteSinglePagesFlag;

            return downloadArguments;
        }

        private static bool InterpretFlag(string flag)
        {
            switch (flag)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    throw new ArgumentException("Argument is neather \'y\' nor \'n\'");
            }
        }
    }
}
