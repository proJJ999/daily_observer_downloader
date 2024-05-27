using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyObserverDownloader.DataClasses
{
    public struct DownloadArguments
    {
        public string ReleasesFile { get; set; }

        public string DownloadPath { get; set; }

        public bool DeleteSinglePagesFlag { get; set; }
    }
}
