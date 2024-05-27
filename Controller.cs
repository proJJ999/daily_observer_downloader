using System.Net;
using System.Text;
using OpenQA.Selenium;

using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using DailyObserverDownloader.DataClasses;

namespace DailyObserverDownloader
{
    public class Controller
    {

        public void DownloadAllMagazines(string[] args)
        {
            DownloadArguments arguments = ArgumentChecker.CheckArguments(args);

            var releases = ReleaseGetter.GetReleases(arguments.ReleasesFile);
            using DownloadGetter downloadGetter = new DownloadGetter();
            foreach (var release in releases)
            {
                var releaseLink = ReleaseLinkCalculator.CalcReleaseLink(release);
                var downloads = downloadGetter.GetDownloads(releaseLink);
                string folder = FolderCalculator.CalculateFolder(arguments.DownloadPath, release);
                Directory.CreateDirectory(folder);
                List<Thread> downloadThreads = new List<Thread>();
                foreach (var download in downloads)
                {
                    Thread thread = new Thread(() => PdfDownloader.DownloadPdf(download.DownloadUrl, folder, download.FileName));
                    thread.Start();
                    downloadThreads.Add(thread);
                }
                foreach(Thread thread in downloadThreads)
                {
                    thread.Join();
                }
                PageMerger.MergeRelease(folder);
                if (arguments.DeleteSinglePagesFlag)
                {
                    PageDeleter.DeleteSinglePages(folder);
                }
            }
        }
    }
}
