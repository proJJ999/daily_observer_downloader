using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyObserverDownloader
{
    public static class FolderCalculator
    {

        public static string CalculateFolder(string basePath, string release)
        {
            string year = release.Substring(0, 4);
            string month = ConvertMonth(release.Substring(4, 2));
            string day = release.Substring(6,2);
            return Path.Combine(basePath, year, month, month + "-" + day);

        }

        private static string ConvertMonth(string month)
        {
            switch(month)
            {
                case "01":
                    return "Jan";
                case "02":
                    return "Feb";
                case "03":
                    return "Mar";
                case "04":
                    return "Apr";
                case "05":
                    return "Mai";
                case "06":
                    return "Jun";
                case "07":
                    return "Jul";
                case "08":
                    return "Aug";
                case "09":
                    return "Sep";
                case "10":
                    return "Okt";
                case "11":
                    return "Nov";
                case "12":
                    return "Dec";
                default:
                    return "missing month";
            }
        }
    }
}
