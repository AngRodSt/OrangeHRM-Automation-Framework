Feature: User Management Table Operations (Admin Module)
  As an admin user
  I want to manage the user list
  So that I can efficiently handle user records
  
  Background:
	Given I am logged in as a valid user
	And I am on the Admin page


	@positive
  Scenario: Verify that the system only shows records related to the search criteria
	When I search for a specific "<username>"
	Then the results should only show users related to that "<username>"

	Examples: 
		| username    |
		| admin	      |

	@positive @selectall
  Scenario: Verify that I can select all listed users at once
	When I choose the option to select all users in the list
	Then all users displayed on the page should be marked as selected