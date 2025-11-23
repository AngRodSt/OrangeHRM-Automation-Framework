Feature: Employee List Management
  As an HR manager
  I want to manage the employee list
  So that I can efficiently handle employee records

  Background:
	Given I am logged in as a valid user
	And I am on the PIM page

	@positive @sort
	Scenario: Verify that the employee list can be sorted by name
	When I sort employees by first name in ascending order
	Then the employees should be sorted by first name in ascending order
  
	@positive @search
	Scenario: Verify that I can navigate between pages of the employee list
	When I navigate to the next page of employees
	Then the next page of employees should be displayed

	@positive @select
	Scenario: Verify that I can select an employee from the list
	When I select an employee from the list
	Then the system should consider that employee as selected

	@positive @remove
	Scenario: Verify that the system asks for confirmation before removing an employee
	When I attempt to delete the selected employee
	Then a confirmation dialog should appear