using DailyObserverDownloader.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyObserverDownloader
{
    public static class ArgumentChecker
    {
        public static DownloadArguments CheckArguments(string[] args)
        {
            if(args.Length % 2 != 0)
            {
                throw new Exception("Parameters are false.");
            }

            DownloadArguments downloadArguments = new DownloadArguments();
            downloadArguments.ReleasesFile = "C:\\daily_observer\\releases.txt";
            downloadArguments.DownloadPath = "C:\\daily_observer\\PDFs";
            downloadArguments.DeleteSinglePagesFlag = true;
            for (int i= 0; i < args.Length; i += 2)
            {
                string parameter = args[i];
                switch (parameter)
                {
                    case "-releasesFile":
                        downloadArguments.ReleasesFile = args[i + 1];
                        break;
                    case "-downloadPath":
                        downloadArguments.DownloadPath = args[i + 1];
                        break;
                    case "-deleteSinglePagesFlag":
                        bool flag = InterpretFlag(args[i + 1]);
                        downloadArguments.DeleteSinglePagesFlag = flag;
                        break;
                    default:
                        throw new Exception("Given parameter not found.");

                }
            }

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
