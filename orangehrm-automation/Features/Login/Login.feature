Feature: Login Functionality
  As an authenticated user
  I want to log into the system
  So that I can access the dashboard

  Background:
    Given I am on the login page

  @smoke @positive
  Scenario Outline: Successful login with valid credentials
    When I log in with username "<username>" and password "<password>"
    Then I should be redirected to the dashboard page

    Examples:
      | username | password |
      | Admin    | admin123 |

  @negative
  Scenario: Unsuccessful login with invalid credentials
    When I log in with username "<username>" and password "<password>"
    Then I should see an error message "Invalid credentials"

    Examples:
      | username | password |
      | user1    | password |

  @negative
  Scenario: Unsuccessful login with empty username
    When I attempt to log in without entering credentials
    Then I should see a required field error
     