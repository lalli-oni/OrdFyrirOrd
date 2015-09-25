using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abot.Crawler;
using Abot.Poco;
using CsQuery.ExtensionMethods;

namespace OrdFyrirOrd
{
    /// <summary>
    /// Lists the supported web pages that the crawler knows how to extract the text from
    /// </summary>
    enum WebPages
    {
        Mbl
    }

    /// <summary>
    /// A webcrawler using Abot NugetPackage. Returns Streams
    /// </summary>
    class WebCrawler
    {
        private int maxPages;
        private CancellationTokenSource cancelCrawlTokenSource;
        private List<CrawledPage> crawledPages;
        private List<Stream> crawledStream;
        public delegate List<Stream> ProcessPageResult(List<CrawledPage> pages);

        /// <summary>
        /// Creates the Crawler (with cancelToken) and gets the site and
        /// underlying pages (up to a certain amount).
        /// </summary>
        /// <param name="url">The page url to start crawling from</param>
        /// <returns>A collection of Readable streams containing the main body text</returns>
        public List<Stream> GetSiteText(string url)
        {
            crawledPages = new List<CrawledPage>();
            PoliteWebCrawler abotCrawler = new PoliteWebCrawler();
            cancelCrawlTokenSource = new CancellationTokenSource();
            abotCrawler.PageCrawlStartingAsync += crawler_ProcessPageCrawlStarting;
            abotCrawler.PageCrawlCompletedAsync += crawler_ProcessPageCrawlCompleted;
            abotCrawler.PageCrawlDisallowedAsync += crawler_PageCrawlDisallowed;
            abotCrawler.PageLinksCrawlDisallowedAsync += crawler_PageLinksCrawlDisallowed;
            CrawlResult result = abotCrawler.Crawl(new Uri(url), cancelCrawlTokenSource);
            if (crawledPages.Count > 1)
            {
                ProcessPageResult processPage = new ProcessPageResult(ProcessMblPageResult);
                return processPage(crawledPages);
            }
            return null;
        }

        /// <summary>
        /// Processess the pages of mbl.is news site, extracts the news text and returns the streams for that text.
        /// Used only by the ProcessPageResult delegate
        /// </summary>
        /// <param name="pages">The pages that have been crawled</param>
        /// <returns>News texts in Stream collection</returns>
        public List<Stream> ProcessMblPageResult(List<CrawledPage> pages)
        {
            List<Stream> streams = new List<Stream>();
            foreach (CrawledPage page in crawledPages)
            {
                string pageContent = page.Content.Text;
                try
                {
                    pageContent = pageContent.Substring(pageContent.IndexOf("maintext cleared-maintext") + 39);
                    pageContent = pageContent.Remove(pageContent.IndexOf("<strong>") - 16);
                }
                catch (Exception)
                {
                    Trace.WriteLine("Invalid format of site: " + page.Uri);
                }
            }
            return streams;
        }

        #region Events
        void crawler_ProcessPageCrawlStarting(object sender, PageCrawlStartingArgs e)
        {
            if (crawledPages.Count() >= 10)
            {
                cancelCrawlTokenSource.Cancel(true);
            }
            PageToCrawl pageToCrawl = e.PageToCrawl;
            Console.WriteLine("About to crawl link {0} which was found on page {1}", pageToCrawl.Uri.AbsoluteUri, pageToCrawl.ParentUri.AbsoluteUri);
        }

        void crawler_ProcessPageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
        {
            CrawledPage crawledPage = e.CrawledPage;

            if (crawledPage.WebException != null || crawledPage.HttpWebResponse.StatusCode != HttpStatusCode.OK)
                Console.WriteLine("Crawl of page failed {0}", crawledPage.Uri.AbsoluteUri);
            else
            {
                Console.WriteLine("Crawl of page succeeded {0}", crawledPage.Uri.AbsoluteUri);
                if (crawledPages.Count() < 10)
                {
                    crawledPages.Add(crawledPage);
                }
            }

            if (string.IsNullOrEmpty(crawledPage.Content.Text))
                Console.WriteLine("Page had no content {0}", crawledPage.Uri.AbsoluteUri);

            if (crawledPages.Count() >= 10)
            {
                cancelCrawlTokenSource.Cancel(true);
            }
        }

        void crawler_PageLinksCrawlDisallowed(object sender, PageLinksCrawlDisallowedArgs e)
        {
            CrawledPage crawledPage = e.CrawledPage;
            Console.WriteLine("Did not crawl the links on page {0} due to {1}", crawledPage.Uri.AbsoluteUri, e.DisallowedReason);
        }

        void crawler_PageCrawlDisallowed(object sender, PageCrawlDisallowedArgs e)
        {
            PageToCrawl pageToCrawl = e.PageToCrawl;
            Console.WriteLine("Did not crawl page {0} due to {1}", pageToCrawl.Uri.AbsoluteUri, e.DisallowedReason);
        }
        #endregion
    }
}
