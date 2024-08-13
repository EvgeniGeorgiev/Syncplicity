Feature: BusinessPageFeature

Background:
	Given the user is logged in with 'syncplicity-technical-interview@dispostable.com' username and 's7ncplicit@Y' password

Scenario: Successfully create a user with 'Global Administrator' role
	When the user navigates to the 'User Accounts' under 'Admin' section
	And the user creates a User Account with 'Random' email and 'Global Administrator' role
	And the user navigates to the 'User Accounts' under 'Admin' section
	Then the newly created user should exist in User Accounts table
	And the newly created user should have 'Global Administrator' role