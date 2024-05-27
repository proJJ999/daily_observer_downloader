using DailyObserverDownloader.DataClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyObserverDownloader
{
    public class DownloadGetter : IDisposable
    {
        private FirefoxDriver driver;
        public DownloadGetter()
        {
            driver = new FirefoxDriver();
        }

        public IEnumerable<Download> GetDownloads(string magazinUrl)
        {
            driver.Url = magazinUrl;

            TimeSpan timeout = TimeSpan.FromSeconds(20);
            DateTime start = DateTime.Now;
            while(DateTime.Now - start < timeout)
            {
                try
                {
                    if (driver.FindElement(By.ClassName("pagetocnodecontainer")).Displayed)
                    {
                        break;
                    }
                }
                catch (NoSuchElementException ex)
                {
                    Thread.Sleep(500);
                }
            }

            var pages = driver.FindElements(By.ClassName("pagetocnodecontainer"));
            string id = pages[0].GetAttribute("id").Substring(4,12);
            return CreateDownloads(id, pages);
        }

        private IEnumerable<Download> CreateDownloads(string id, IEnumerable<IWebElement> pages)
        {
            List<Download> downloads = new List<Download>();
            int counter = 1;
            StringBuilder sb = new StringBuilder();
            foreach (var page in pages)
            {
                Download download = new Download();

                sb.Clear();
                sb.Append("https://gpa.eastview.com/crl/doda/?a=is&oid=");
                sb.Append(id);
                sb.Append("-01.1.");
                sb.Append(counter);
                sb.Append("&type=pagepdf&e=-------en-25--1-byDA-img-txIN-eltv---------");
                download.DownloadUrl = sb.ToString();

                sb.Clear();
                sb.Append(id);
                sb.Append("-01.1.");
                sb.Append(counter.ToString("D2"));
                download.FileName = sb.ToString();

                downloads.Add(download);
                counter++;
            }
            return downloads;
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
