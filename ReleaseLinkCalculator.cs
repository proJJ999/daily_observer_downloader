using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
{
    public static class ReleaseLinkCalculator
    {
        public static string CalcReleaseLink(string release)
        {
            string LINK_PREFFIX = "https://gpa.eastview.com/crl/doda/?a=d&d=lodo";
            string LINK_SUFFIX = "-01.1.1&e=-------en-25--1-byDA-img-txIN-eltv---------";
            return LINK_PREFFIX + release + LINK_SUFFIX;
        }
    }
}
