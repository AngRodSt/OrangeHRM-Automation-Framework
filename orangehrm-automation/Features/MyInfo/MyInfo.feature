Feature: Personal Information Updates
  As an employee
  I want to update my personal information
  So that my records are accurate and up-to-date

  Background:
	Given I am logged in as a valid user
	And I am on the My Info page

	  
	@positive @update
  Scenario: Verify that the system shows a confirmation when changes are saved
	When I update my personal details with First Name "<FirstName>", Middle Name "<MiddleName>", and Last Name "<LastName>"
	Then I should see a success message "<SuccessMessage>"

	Examples: 
	| FirstName | MiddleName | LastName | SuccessMessage       |
	| John      | A.         | Doe      | Successfully Updated |
	

		  
	