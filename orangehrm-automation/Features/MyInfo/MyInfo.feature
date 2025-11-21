Feature: MyInfo module Functionality
	As an authenticated user
	I want to access and update my personal information
	So that I can keep my profile up to date

	Background:
		Given I am logged in as a valid user
		And I am on the MyInfo page

	@positive
	Scenario: Update personal details successfully
		When I update my personal details with valid information
		Then I should see a success message "Successfully Updated"

	@negative
	Scenario: Attempt to update personal details with invalid data
		When I update my personal details with invalid information
		Then I should see an error message "Invalid data provided"

	@positive
	Scenario: View personal details
		When I navigate to the Personal Details section
		Then I should see my current personal information displayed correctly