using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class GlobalPage
{
    protected IWebDriver webDriver;
    protected WebDriverWait _wait;

    private readonly By NavigationSection = By.CssSelector("#menu.menu-main-nav-container [class*=menu-item] a");

    public GlobalPage()
    {
        webDriver = Hooks.GetWebDriver();
        _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
    }

    public void WaitForAjaxToComplete()
    {
        _wait.Until(driver =>
        {
            var ajaxIsComplete = (bool)((IJavaScriptExecutor)driver)
            .ExecuteScript("return (typeof jQuery == 'undefined' || jQuery.active == 0)");
            return ajaxIsComplete;
        });
    }

    public void WaitForElementToBeVisible(By elementSelector)
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementSelector));
        }
        catch (WebDriverTimeoutException)
        {
            throw new Exception($"Element with selector {elementSelector.ToString()} was not visible within the timeout period.");
        }
    }

    internal string GetCurrentURL()
    {
        return webDriver.Url;
    }

    internal void NavigateToPage(string page)
    {
        webDriver.Navigate().GoToUrl(page);
    }

    internal void ClickElementFromListByText(By locator, string option)
    {
        bool wasAnOptionClicked = false;
        IReadOnlyCollection<IWebElement> elements = new List<IWebElement>(webDriver.FindElements(locator));
        foreach (var element in elements)
        {
            if (option == element.Text)
            {
                element.Click();
                wasAnOptionClicked = true;
                break;
            }
        }
        if (!wasAnOptionClicked) { throw new Exception("No element with text " + option + " found. "); }
    }

    public string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}