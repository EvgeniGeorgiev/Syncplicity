using OpenQA.Selenium;

public class BusinessPage : GlobalPage
{
    private string _storedEmail = string.Empty;

    private readonly By MainMenuItems = By.CssSelector("#mainnav a");
    private readonly By SubMenuItems = By.CssSelector(".sub-menu a");
    private readonly By AddUserButton = By.CssSelector(".button.blue-button.floatright");
    private readonly By NewUser_NextButtonUserEmails = By.CssSelector("#nextButtonUserEmails");
    private readonly By NewUser_NextButtonGroupMembership = By.CssSelector("#nextButtonGroupMembership");
    private readonly By NewUser_NextButtonUserFolders = By.CssSelector("#nextButtonUserFolders");
    private readonly By NewUser_EmailAddressesInput = By.CssSelector("#txtUserEmails");
    private readonly By NewUser_RoleDropdown = By.CssSelector("#user-roles #roleselect");
    private readonly By NewUser_RolesOptions = By.CssSelector("#user-roles li");
    private readonly By UserAccounts_UserFilterInput = By.CssSelector(".jqfilter-input-email");
    private readonly By UserAccounts_UserFilterResults = By.CssSelector("#results .item .name a:first-child");
    private readonly By ManageUser_Role = By.CssSelector("li span[class='user-property']");

    internal void SelectMainMenuSection(string section)
    {
        ClickElementFromListByText(MainMenuItems, section);
    }

    internal void SelectSubMenuSection(string option)
    {
        ClickElementFromListByText(SubMenuItems, option);
    }

    internal void ClickAddUserInUserAccounts()
    {
        webDriver.FindElement(AddUserButton).Click();
    }

    internal void PopulateAddUserEmailInUserAccounts(string email)
    {
        if (email == "Random")
        {
            email = GenerateRandomString(8) + "@testemailsyncplicity.com";
        }

        _storedEmail = email;
        webDriver.FindElement(NewUser_EmailAddressesInput).SendKeys(email);
    }

    public string GetStoredEmail()
    {
        return _storedEmail;
    }

    internal void PopulateAddUserRoleInUserAccounts(string role)
    {
        webDriver.FindElement(NewUser_RoleDropdown).Click();
        ClickElementFromListByText(NewUser_RolesOptions, role);
    }

    internal void ClickNextButtonUserEmailsInUserAccounts()
    {
        webDriver.FindElement(NewUser_NextButtonUserEmails).Click();
        WaitForAjaxToComplete();
    }

    internal void ClickNextButtonGroupMembershipInUserAccounts()
    {
        webDriver.FindElement(NewUser_NextButtonGroupMembership).Click();
        WaitForAjaxToComplete();
    }

    internal void ClickNextButtonUserFoldersInUserAccounts()
    {
        webDriver.FindElement(NewUser_NextButtonUserFolders).Click();
        WaitForAjaxToComplete();
    }

    internal IReadOnlyCollection<IWebElement> GetAllMatchingUserSearch(string search)
    {
        var userFilterInput = webDriver.FindElement(UserAccounts_UserFilterInput);
        userFilterInput.Clear();
        userFilterInput.SendKeys(search);
        userFilterInput.SendKeys(Keys.Enter);
        WaitForAjaxToComplete();
        IReadOnlyCollection<IWebElement> userResultsList = new List<IWebElement>(webDriver.FindElements(UserAccounts_UserFilterResults));
        return userResultsList;
    }

    internal string GetUserRoleInManageUser()
    {
        return webDriver.FindElement(ManageUser_Role).Text;
    }
}