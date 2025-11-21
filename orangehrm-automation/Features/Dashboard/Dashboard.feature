Feature: Dashboard Functionality
  As an authenticated user
  I want to access and interact with the dashboard
  So that I can view key information and navigate to other sections

  Background:
    Given I am logged in as a valid user
    And I am on the dashboard page
    
  @positive @smoke
  Scenario Outline: Verify dashboard elements are displayed
    Then the dashboard should display the "<element>"

    Examples:
      | element                           |
      | Time at Work                      |
      | Quick Launch                      |
      | Employee Distribution by Sub Unit |
      | Employee Distribution by Location |
      | My Actions                        |

  @positive @smoke
  Scenario Outline: Verify charts are rendered correctly
    Then the dashboard chart "<chart>" should be visible

    Examples:
      | chart                             |
      | Employee Distribution by Sub Unit |
      | Employee Distribution by Location |

#######################################################################
 #   @positive
 #   Scenario Outline: Verify navigation from dashboard to other modules
  #    When I click on the "<module>" link on the dashboard
   #   Then I should be redirected to the "<module>" page

   #   Examples:
    #    | module       |
     #   | Admin        |
      #  | PIM          |
       # | Leave        |
        #| Time         |
      #  | Recruitment  |
      #  | My Info      |
      #  | Performance  |
       # | Dashboard    |
      #  | Directory    |
      #  | Maintenance  |
      #  | Claim        |
       # | Buzz         |
###########################################################################