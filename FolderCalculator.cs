using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
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
                    break;
                case "02":
                    return "Feb";
                    break;
                case "03":
                    return "Mar";
                    break;
                case "04":
                    return "Apr";
                    break;
                case "05":
                    return "Mai";
                    break;
                case "06":
                    return "Jun";
                    break;
                case "07":
                    return "Jul";
                    break;
                case "08":
                    return "Aug";
                    break;
                case "09":
                    return "Sep";
                    break;
                case "10":
                    return "Okt";
                    break;
                case "11":
                    return "Nov";
                    break;
                case "12":
                    return "Dec";
                    break;
                default:
                    return "missing month";
                    break;

            }
        }
    }
}
