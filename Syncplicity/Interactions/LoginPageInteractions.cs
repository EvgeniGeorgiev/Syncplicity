

public class LoginPageInteractions(LoginPage loginPage)
{
    private readonly LoginPage _loginPage = loginPage;

    internal void NavigateToPage(string pageUrl)
    {
        _loginPage.NavigateToPage(pageUrl);
    }
    internal string GetCurrentUrl()
    {
        return _loginPage.GetCurrentURL();
    }

    public void EnterEmail(string email)
    {
        _loginPage.PopulateEmail(email);
        _loginPage.ClickNextButton();
        _loginPage.WaitForAjaxToComplete();
    }

    public void EnterPassword(string password)
    {
        _loginPage.PopulatePassword(password);
        _loginPage.ClickLoginButton();
        _loginPage.WaitForAjaxToComplete();
    }

    public string ReturnEmailErrorMessageText()
    {
        return _loginPage.ReturnEmailErrorMessageText();
    }
}