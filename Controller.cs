using System.Net;
using System.Text;
using OpenQA.Selenium;

using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace PDF_Downloader
{
    public class Controller
    {

        public void DownloadAllMagazines(string[] args)
        {
            (string releasesFile, string downloadPath) = ArgumentChecker.CheckArguments(args);

            var releases = ReleaseGetter.GetReleases(releasesFile);
            using DownloadGetter downloadGetter = new DownloadGetter();
            foreach (var release in releases)
            {
                var releaseLink = ReleaseLinkCalculator.CalcReleaseLink(release);
                var downloads = downloadGetter.GetDownloads(releaseLink);
                string folder = FolderCalculator.CalculateFolder(downloadPath, release);
                Directory.CreateDirectory(folder);
                foreach (var download in downloads)
                {
                    PdfDownloader.DownloadPdf(download.DownloadUrl, folder, download.FileName);
                }
                PageMerger.MergeRelease(folder);
            }
        }
    }
}
