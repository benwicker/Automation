﻿using System.Collections.Generic;
using System.Threading;
using Common;

namespace DesktopCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = "";
            var password = "";

            using(var driver = Driver.GetDesktopDriver()) {
                var bingPage = new BingPage(driver);
                var searches = Driver.GetSearches();

                Thread.Sleep(2000);
                bingPage.PerformSignIn();
                driver.Navigate().GoToUrl("https://www.bing.com/search?q=hello&cvid=3087b4535abe40b2b41d13f4d462c7fd&FORM=ANSPA1&PC=U531");

                foreach(var searchTerm in searches) {
                    bingPage.Search(searchTerm);
                }
            }

            System.Console.WriteLine("Done");
        }
    }
}