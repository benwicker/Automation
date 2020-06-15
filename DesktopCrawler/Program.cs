using System;
using System.Threading;
using Common;

namespace DesktopCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var username = "";
                var password = "";
                var points = "";

                if (args.Length > 0)
                {
                    username = args[0];
                    password = args[1];
                }

                using (var driver = Driver.GetDesktopDriver())
                {
                    var bingPage = new BingPage(driver);
                    var searches = Driver.GetSearches();

                    Thread.Sleep(2000);
                    bingPage.PerformSignIn(username, password);

                    foreach (var searchTerm in searches)
                    {
                        bingPage.Search(searchTerm);
                    }

                    points = bingPage.GetPoints();
                }

                Logger.LogResult(true, points);
            }
            catch (Exception e)
            {
                Logger.LogResult(false, e.Message);
            }
        }
    }
}
