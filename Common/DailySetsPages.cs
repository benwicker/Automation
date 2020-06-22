using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace Common
{
    public class DailySetsPages
    {
        // URLS
        private string RewardsDashboardUrl = "https://account.microsoft.com/rewards/?refd=www.bing.com";


        public IWebDriver _driver { get; set; }

        public By DailySet1Link = By.XPath("(//mee-rewards-daily-set-item-content/div/div[contains(@class, 'actionLink')]/a)[1]");
        public By DailySet2Link = By.XPath("(//mee-rewards-daily-set-item-content/div/div[contains(@class, 'actionLink')]/a)[2]");
        public By DailySet3Link = By.XPath("(//mee-rewards-daily-set-item-content/div/div[contains(@class, 'actionLink')]/a)[3]");
        public By DailyPollTopOption = By.Id("btoption0");
        public By SetTypeText = By.XPath("//*[@class='b_topTitle']");

        


        public DailySetsPages(IWebDriver driver)
        {
            _driver = driver;
        }

        public void DoDailySet1()
        {
            _driver.Navigate().GoToUrl(RewardsDashboardUrl);
            Thread.Sleep(2000);
            _driver.FindElement(DailySet1Link).Click();
            Thread.Sleep(2000);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        public string DoDailySet2()
        {
            _driver.Navigate().GoToUrl(RewardsDashboardUrl);
            Thread.Sleep(2000);
            _driver.FindElement(DailySet2Link).Click();
            Thread.Sleep(5000);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            handleNotLoggedInScreen();
            var setType = _driver.FindElement(SetTypeText).Text;

            switch(setType) 
            {
                case "Lightspeed quiz":
                    RunLightSpeedQuiz();
                    break;
                default:
                    return "Could not identify set";
            }

            _driver.Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            return null;
        }

        public void DoDailySet3()
        {
            _driver.Navigate().GoToUrl(RewardsDashboardUrl);
            Thread.Sleep(2000);
            _driver.FindElement(DailySet3Link).Click();
            Thread.Sleep(5000);
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.FindElement(DailyPollTopOption).Click();
            Thread.Sleep(2000);
            _driver.Close();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        private void handleNotLoggedInScreen()
        {
            var signInButton = By.XPath("//a[text()='Sign in']");

            if (_driver.FindElements(signInButton).Count > 0) {
                _driver.FindElement(signInButton).Click();
                Thread.Sleep(5000);
            }
        }

        private void RunLightSpeedQuiz()
        {
            // locators
            var StartButton = By.Id("rqStartQuiz");
            var Option0 = By.Id("rqAnswerOption0");

            _driver.FindElement(StartButton).Click();
            Thread.Sleep(2000);
            for(int i = 0; i < 4; i++) {
                _driver.FindElement(Option0).Click();
                Thread.Sleep(2000);
            }
        }
    }
}
