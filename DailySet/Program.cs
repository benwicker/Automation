using System;
using Common;

namespace DailySet
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

                using (var driver = Driver.GetDesktopDriver())
                {
                    var bingPage = new BingPage(driver);
                    var dailySetPages = new DailySetsPages(driver);
                    bingPage.PerformSignIn(username, password);
                    // dailySetPages.DoDailySet1();
                    dailySetPages.DoDailySet2();
                    // dailySetPages.DoDailySet3();
                }

                System.Console.WriteLine("Succeeded");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Failed", e.Message);
            }
        }
    }
}
