using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyObserverDownloader
{
    public static class ReleaseGetter
    {
        public static IEnumerable<String> GetReleases(string filepath)
        {
            return File.ReadLines(filepath);
        }
    }
}
