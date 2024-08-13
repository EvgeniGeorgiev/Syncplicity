using OpenQA.Selenium;

public class BusinessPageInteractions(BusinessPage businessPage)
{
    private readonly BusinessPage _businessPage = businessPage;

    internal void CreateUserAccountWithEmailAndRole(string email, string role)
    {
        _businessPage.ClickAddUserInUserAccounts();
        _businessPage.PopulateAddUserEmailInUserAccounts(email);
        _businessPage.PopulateAddUserRoleInUserAccounts(role);
        _businessPage.ClickNextButtonUserEmailsInUserAccounts();
        _businessPage.ClickNextButtonGroupMembershipInUserAccounts();
        _businessPage.ClickNextButtonUserFoldersInUserAccounts();
    }

    internal IReadOnlyCollection<IWebElement> GetNewlyCreatedUserInAccountsTable()
    {
        return _businessPage.GetAllMatchingUserSearch(_businessPage.GetStoredEmail());
    }

    internal string GetUserRoleInManageUser()
    {
        return _businessPage.GetUserRoleInManageUser();
    }

    internal bool IsOnPageUrl(string containsUrl)
    {
        return _businessPage.GetCurrentURL().Contains(containsUrl);
    }

    internal void NavigateInDropdownMenu(string section, string option)
    {
        _businessPage.SelectMainMenuSection(section);
        _businessPage.WaitForAjaxToComplete();
        _businessPage.SelectSubMenuSection(option);
        _businessPage.WaitForAjaxToComplete();
    }
}