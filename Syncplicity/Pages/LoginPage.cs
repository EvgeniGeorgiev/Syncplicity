using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;

public class LoginPage : GlobalPage
{
    private readonly By EmailInput = By.CssSelector("#MainContent_login_UserName");
    private readonly By PasswordInput = By.CssSelector("#MainContent_login_txtPassword");
    private readonly By NextButton = By.CssSelector("#MainContent_login_btnNext");
    private readonly By LoginButton = By.CssSelector("#MainContent_login_btnLogin");
    private readonly By InvalidEmailErrorMessage = By.CssSelector("#MainContent_login_UserName-error");


    internal void PopulateEmail(string email)
    {
        webDriver.FindElement(EmailInput).SendKeys(email);
    }

    internal void ClickNextButton() 
    { 
        webDriver.FindElement(NextButton).Click();
    }

    internal void PopulatePassword(string password)
    {
        webDriver.FindElement(PasswordInput).SendKeys(password);
    }

    internal void ClickLoginButton()
    {
        webDriver.FindElement(LoginButton).Click();
    }

    internal string ReturnEmailErrorMessageText() 
    {
        return webDriver.FindElement(InvalidEmailErrorMessage).Text;
    }
}