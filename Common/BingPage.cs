using System.Threading;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

public class BingPage
{
    // URLS
    private string RewardsDashboardUrl = "https://account.microsoft.com/rewards/?refd=www.bing.com";
    private string InitSearch = "https://www.bing.com/search?q=hello&cvid=3087b4535abe40b2b41d13f4d462c7fd&FORM=ANSPA1&PC=U531";
    private string InitSignIn = "https://www.microsoft.com/en-us/rewards?rtc=1";


    public IWebDriver _driver { get; set; }

    public By SignInButton = By.Id("mectrl_headerPicture");
    public By EmailField = By.Name("loginfmt");
    public By NextButton = By.Id("idSIButton9");
    public By PasswordField = By.Name("passwd");
    public By SearchField = By.Name("q");
    public By AvailablePoints = By.XPath("(//mee-rewards-counter-animation/span)[1]");
    public By AvailablePointsMobile = By.XPath("//div[@class='availablePoints']/span");

    public BingPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void PerformSignIn(string username, string password)
    {
        _driver.Navigate().GoToUrl(InitSignIn);
        ClickSignIn();
        EnterEmail(username);
        EnterPassword(password);
        _driver.Navigate().GoToUrl(InitSearch);
    }

    public void ClickSignIn()
    {
        _driver.FindElement(SignInButton).Click();
        Thread.Sleep(2000);
    }

    public void EnterEmail(string username)
    {
        _driver.FindElement(EmailField).SendKeys(username);
        _driver.FindElement(NextButton).Click();
        Thread.Sleep(2000);
    }

    public void EnterPassword(string password)
    {
        _driver.FindElement(PasswordField).SendKeys(password);
        _driver.FindElement(NextButton).Click();
        Thread.Sleep(2000);
    }

    public void Search(string searchTerm)
    {
        // check for alert
        if (isDialogPresent()) 
        {
            var alert = _driver.SwitchTo().Alert();
            Thread.Sleep(1000);
            alert.Dismiss();
        }

        _driver.FindElement(SearchField).Clear();
        _driver.FindElement(SearchField).SendKeys(searchTerm + Keys.Enter);
        Thread.Sleep(1000);
    }

    bool isDialogPresent()
    {
        IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(_driver);
        return (alert != null);
    }

    public string GetPoints() 
    {
        _driver.Navigate().GoToUrl(RewardsDashboardUrl);
        Thread.Sleep(5000);
        return _driver.FindElement(AvailablePoints).Text;
    }

    public string GetPointsMobile() {
        _driver.Navigate().GoToUrl(RewardsDashboardUrl);
        Thread.Sleep(5000);
        return _driver.FindElement(AvailablePointsMobile).Text;
    }
}