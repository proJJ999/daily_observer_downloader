using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader.DataClasses
{
    public struct DownloadArguments
    {
        public string releasesFile { get; set; }

        public string downloadPath { get; set; }

        public bool deleteSinglePagesFlag { get; set; }
    }
}
