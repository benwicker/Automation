using System.Collections.Generic;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Common
{
    public class Driver
    {
        private static readonly string DriverLocation = @"C:\Users\Benwi\Desktop\Repos\web-crawler\edgedriver_win64";

        public static IWebDriver GetDesktopDriver()
        {
            var options = new EdgeOptions();
            options.UseChromium = true;
            // options.AddArgument("headless");
            // options.AddArgument("disable-gpu");
            var driver = new EdgeDriver(DriverLocation, options);
            driver.Manage().Window.Maximize();

            return driver;
        }

        public static IWebDriver GetMobileDriver()
        {
            var options = new FirefoxOptions();
            options.SetPreference("general.useragent.override", "Mozilla/5.0 (Android 9; Mobile; rv:74.0) Gecko/74.0 Firefox/74.0");
            options.SetPreference("browser.privatebrowsing.autostart", true);
            var driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static List<string> GetSearches() {
            return new List<string>() {
                "Piano",
                "Korg",
                "Micro Korg",
                "Nord Stage 3",
                "Blues Piano",
                "All music genres",
                "Most popular music genres",
                "Weird musical instruments",
                "Dog training",
                "how to train a dog",
                "how to train a service dog",
                "what kind of dogs make good service dogs",
                "best service dog breeds",
                "automation",
                "selenium automation",
                "C# selenium automation",
                "C# selenium automation using Edge",
                "Columbus",
                "Columbus events",
                "Concerts coming up in columbus",
                "Experimental airplanes",
                "Experimental gliders",
                "Paper airplanes",
                "Coolest paper airplanes",
                "Weird world records",
                "Cool party tricks",
                "exotic animals you didn't know existed",
                "gloomhaven",
                "gloomhaven rules pdf",
                "best board game ever",
                "good two player board games",
                "vue js",
                "vuetify",
                "vue awesome",
                "archetecting a vue application",
                "mvc architecture in c#",
                "word of the day",
                "pun of the day"
            };
        }
    }
}





