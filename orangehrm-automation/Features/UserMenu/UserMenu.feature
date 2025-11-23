Feature: User session Management via User Menu
  As a system user
  I want to manage my session through the user menu
  So that I can log out securely when needed

  Background:
	Given I am logged in as a valid user
	And I am on the dashboard page

	@positive @logout
	Scenario: Verify system behavior when ending the session
	When I choose to end my session
	Then I should be logged out and redirected to the login page
	