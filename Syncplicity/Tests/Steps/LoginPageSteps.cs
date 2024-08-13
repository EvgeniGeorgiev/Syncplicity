using NUnit.Framework.Legacy;
using TechTalk.SpecFlow;


[Binding]
public class LoginPageSteps
{
    private readonly LoginPageInteractions _loginPageInteractions;
    private readonly string baseUrl;

    public LoginPageSteps(LoginPageInteractions loginPageInteractions)
    {
        _loginPageInteractions = loginPageInteractions;
        baseUrl = ConfigurationSettings.GetConfig().BaseUrl;
    }

    [Given(@"the user navigates to the login page")]
    public void GivenTheUserNavigatesToTheLoginPage()
    {
        _loginPageInteractions.NavigateToPage(baseUrl);
    }

    [When(@"the user logs in with '(.*)' username and '(.*)' password")]
    public void WhenTheUserLogsInWithProvidedCredentials(string username, string password)
    {
        _loginPageInteractions.EnterEmail(username);
        _loginPageInteractions.EnterPassword(password);
    }

    [Given(@"the user is logged in with '(.*)' username and '(.*)' password")]
    public void GivenTheUserIsLoggedInWithProvidedCredentials(string username, string password)
    {
        GivenTheUserNavigatesToTheLoginPage();
        _loginPageInteractions.EnterEmail(username);
        _loginPageInteractions.EnterPassword(password);
    }

    [Then(@"the user should be logged in")]
    public void ThenTheUserShouldBeLoggedIn()
    {
        string expectedUrl = "https://eu.syncplicity.com/Business/";
        string currentUrl = _loginPageInteractions.GetCurrentUrl();
        ClassicAssert.AreEqual(expectedUrl, currentUrl, "The user was not redirected to the expected URL after login.");
    }

    [When(@"the user submits '(.*)' username on login")]
    public void WhenTheSubmitsUsernameOnLogin(string username)
    {
        _loginPageInteractions.EnterEmail(username);
    }

    [When(@"the user submits '(.*)' password on login")]
    public void WhenTheSubmitsPasswordOnLogin(string password)
    {
        _loginPageInteractions.EnterPassword(password);
    }

    [Then(@"the user should see invalid email address error")]
    public void ThenTheUserShouldSeeInvalidEmailAddressError()
    {
        string expectedErrorMessage = "Please enter a valid email address.";
        string actualErrorMessage = _loginPageInteractions.ReturnEmailErrorMessageText();
        ClassicAssert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error message text is incorrect or not shown. " + expectedErrorMessage);
    }

    [Then(@"the user should see missing password error")]
    public void ThenTheUserShouldSeeMissingPasswordError()
    {
        string expectedErrorMessage = "Password required.";
        string actualErrorMessage = _loginPageInteractions.ReturnPasswordErrorMessageText();
        ClassicAssert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error message text is incorrect or not shown. " + expectedErrorMessage);
    }

    [Then(@"the user sees '(.*)' status message error")]
    public void ThenTheUserSeesStatusMessageError(string expectedErrorMessage)
    {
        string actualErrorMessage = _loginPageInteractions.ReturnSystemMessageErrorText();
        ClassicAssert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error message text is incorrect or not shown. " + expectedErrorMessage);
    }
}