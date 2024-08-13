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

    [When(@"the user logs in with valid credentials")]
    public void WhenTheUserLogsInWithValidCredentials()
    {
        //ToDo: Remove hardcoded values
        _loginPageInteractions.EnterEmail("syncplicity-technical-interview@dispostable.com");
        _loginPageInteractions.EnterPassword("s7ncplicit@Y");
    }

    [Given(@"the user is logged in with the provided account")]
    public void GivenTheUserIsLoggedInWithTheProvidedAccount()
    {
        GivenTheUserNavigatesToTheLoginPage();
        WhenTheUserLogsInWithValidCredentials();
    }

    [Then(@"the user should be logged in")]
    public void ThenTheUserShouldBeLoggedIn()
    {
        //ToDo: Remove hardcoded values
        string expectedUrl = "https://eu.syncplicity.com/Business/";
        string currentUrl = _loginPageInteractions.GetCurrentUrl();
        ClassicAssert.AreEqual(expectedUrl, currentUrl, "The user was not redirected to the expected URL after login.");
    }

    [When(@"the user attempts to log in with invalid credentials")]
    public void WhenTheUserAttemptsLogInWithInvalidCredentials()
    {
        //ToDo: Remove hardcoded values
        _loginPageInteractions.EnterEmail("NotValidEmail");
    }

    [Then(@"the user should see invalid email address error")]
    public void ThenTheUserShouldSeeInvalidEmailAddressError()
    {
        //ToDo: Remove hardcoded values
        string expectedErrorMessage = "Please enter a valid email address.";
        string actualErrorMessage = _loginPageInteractions.ReturnEmailErrorMessageText();
        ClassicAssert.AreEqual(expectedErrorMessage, actualErrorMessage, "The error message text is incorrect.");
    }
}