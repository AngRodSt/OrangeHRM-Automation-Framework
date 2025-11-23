Feature: Leave Assigment Validation
  As an HR manager
  I want to ensure that leave assignments are properly validated
  
  Background:
	Given I am logged in as a valid user
	And I am on the Leave page
	
	@negative 
  Scenario: Verify that the system warns me when trying to submit an incomplete form
	Given I am on assign leave page
	When I attempt to assign leave without filling mandatory fields
	Then I should see a required field error