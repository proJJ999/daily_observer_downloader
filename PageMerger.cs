using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
{
    public static class PageMerger
    {
        public static void MergeRelease(string folder)
        {
            var dir = new DirectoryInfo(folder);
            var pages = dir.GetFiles().Select(x => File.ReadAllBytes(x.FullName)).ToArray();
            string mergedPdf = Path.Combine(folder, dir.Name + ".pdf");
            using FileStream mergedFile = File.Create(mergedPdf);

            var mergedData = MergeFiles(pages);

            MemoryStream mergedStream = new MemoryStream();
            mergedStream.Write(mergedData, 0, mergedData.Length);
            mergedStream.Seek(0, SeekOrigin.Begin);
            mergedStream.CopyTo(mergedFile);
        }

        private static byte[] MergeFiles(byte[][] sourceFiles)
        {
            Document document = new Document();
            using (MemoryStream ms = new MemoryStream())
            {
                PdfCopy copy = new PdfCopy(document, ms);
                document.Open();
                int documentPageCounter = 0;

                // Iterate through all pdf documents
                for (int fileCounter = 0; fileCounter < sourceFiles.Length; fileCounter++)
                {
                    // Create pdf reader
                    PdfReader reader = new PdfReader(sourceFiles[fileCounter]);
                    int numberOfPages = reader.NumberOfPages;

                    // Iterate through all pages
                    for (int currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
                    {
                        documentPageCounter++;
                        PdfImportedPage importedPage = copy.GetImportedPage(reader, currentPageIndex);
                        copy.AddPage(importedPage);
                    }

                    copy.FreeReader(reader);
                    reader.Close();
                }

                document.Close();
                return ms.GetBuffer();
            }
        }
    }
}
