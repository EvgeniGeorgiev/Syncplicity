Feature: LoginPageFeature

Scenario Outline: Successful login with valid credentials
    Given the user navigates to the login page
    When the user logs in with valid credentials
    Then the user should be logged in

Scenario Outline: Unsuccessful login with invalid credentials
    Given the user navigates to the login page
    When the user attempts to log in with invalid credentials
    Then the user should see invalid email address error