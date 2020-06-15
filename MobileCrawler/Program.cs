using System;
using System.Collections.Generic;
using System.Threading;
using Common;

namespace MobileCrawler
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

                // parse args
                if (args.Length > 0)
                {
                    username = args[0];
                    password = args[1];
                }

                using (var driver = Driver.GetMobileDriver())
                {
                    var searches = Driver.GetSearches();

                    var bingPage = new BingPage(driver);
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
