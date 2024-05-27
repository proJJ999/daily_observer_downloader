using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
{
    public static class PageDeleter
    {
        public static void DeleteSinglePages(string folder)
        {
            var dir = new DirectoryInfo(folder);
            var pages = dir.GetFiles();
            foreach (var page in pages)
            {
                if(page.Name != dir.Name + ".pdf")
                {
                    page.Delete();
                }
            }
        }
    }
}
