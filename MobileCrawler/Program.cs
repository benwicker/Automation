using System;
using Common;

namespace MobileCrawler
{
    class Program
    {
        static void Main(string[] args)
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

            try
            {
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

                Logger.LogResult($"{username} Mobile", true, points);
            }
            catch (Exception e)
            {
                Logger.LogResult($"{username} Mobile", false, e.Message);
            }

        }
    }
}
