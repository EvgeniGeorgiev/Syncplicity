Feature: LoginPageFeature

Scenario Outline: Successful login with valid credentials
	Given the user navigates to the login page
	When the user logs in with '<Username>' username and '<Password>' password
	Then the user should be logged in

Examples:
	| Username                                        | Password     |
	| syncplicity-technical-interview@dispostable.com | s7ncplicit@Y |

Scenario: Unsuccessful login with invalid email
	Given the user navigates to the login page
	When the user submits 'NotValidEmail' username on login
	Then the user should see invalid email address error
	
Scenario: Unsuccessful login with empty password
	Given the user navigates to the login page
	When the user submits 'valid@email.com' username on login
	When the user submits '' password on login
	Then the user should see missing password error
	
Scenario: Unsuccessful login with invalid credentials
	Given the user navigates to the login page
	When the user submits 'valid@email.com' username on login
	When the user submits 'password' password on login
	Then the user sees 'Invalid email or password. Please try again.' status message error