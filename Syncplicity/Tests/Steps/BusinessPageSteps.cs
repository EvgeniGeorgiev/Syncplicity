using NUnit.Framework.Legacy;
using TechTalk.SpecFlow;


[Binding]
public class BusinessPageSteps
{
    private readonly BusinessPageInteractions _businessPageInteractions;

    public BusinessPageSteps(BusinessPageInteractions businessPageInteractions)
    {
        _businessPageInteractions = businessPageInteractions;
    }


    [When(@"the user navigates to the '(.*)' under '(.*)' section")]
    public void WhenTheUserNavigatesToOptionUnderSection(string option, string section)
    {
        _businessPageInteractions.NavigateInDropdownMenu(section, option);
    }

    [When(@"the user creates a User Account with '(.*)' email and '(.*)' role")]
    public void WhenTheUserCreatesUserAccountWithEmailAndRole(string email, string role)
    {
        ClassicAssert.IsTrue(_businessPageInteractions.IsOnPageUrl("UserSearch"), "The User Accounts page is not loaded.");
        _businessPageInteractions.CreateUserAccountWithEmailAndRole(email, role);
        ClassicAssert.IsTrue(_businessPageInteractions.IsOnPageUrl("AddUser.aspx#congratulations"), "User creation confirmation page not loaded.");
    }

    [Then(@"the newly created user should exist in User Accounts table")]
    public void ThenTheNewlyCreatedUserShouldExistInUserAccountsTable()
    {
        var matchingUserResults = _businessPageInteractions.GetNewlyCreatedUserInAccountsTable();
        ClassicAssert.IsTrue(matchingUserResults.Count == 1, "No matching user or more than one user found in the User Accounts Table matching the newly created email address.");
    }

    [Then(@"the newly created user should have '(.*)' role")]
    public void ThenTheNewlyCreatedUserShouldHaveRole(string role)
    {
        var matchingUserResults = _businessPageInteractions.GetNewlyCreatedUserInAccountsTable();
        matchingUserResults.ToList()[0].Click();
        ClassicAssert.IsTrue(_businessPageInteractions.IsOnPageUrl("EditUser.aspx"), "User creation confirmation page not loaded.");
        var actualUserRole = _businessPageInteractions.GetUserRoleInManageUser();
        ClassicAssert.IsTrue(actualUserRole.Equals(role), "User did not have the expected role: " + role);
    }
}