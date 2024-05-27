using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
{
    public static class PdfDownloader
    {
        public static void DownloadPdf(string downloadUrl, string folderPath, string fileName)
        {
            WebRequest request = WebRequest.Create(downloadUrl);
            using WebResponse response = request.GetResponse();
            using Stream dataStream = response.GetResponseStream();
            using StreamReader reader = new StreamReader(dataStream);

            fileName += ".pdf";
            string filePath = Path.Combine(folderPath, fileName);

            using FileStream file = File.Create(filePath);
            dataStream.CopyTo(file);
        }
    }
}
