Feature: tfl_journey_plan

@tfltest1
Scenario: Plan a valid journey using tfl website
	Given I naviagte to tfl homepage
	And I clicked on the journey planner
	And I enter '<London>' as my from
	And I enter '<Kent>' as my to
	When I click plan my journey
	#Then the result should display the planned journey

@test2
Scenario: Plan an invalid journey using tfl website
	Given I naviagte to tfl homepage
	And I clicked on the journey planner
	And I enter '<London>' as my from
	And I enter '<Kent>' as my to
	When I click plan my journey
	Then the result should display the planned journey

@tfltest3
Scenario: Plan an empty journey using tfl website
	Given I naviagte to tfl homepage
	And I clicked on the journey planner
	And I enter '<>' as my from
	And I enter '<>' as my to
	When I click plan my journey
	Then the result should display the field is required

@tfltest4
Scenario: Plan a journey using the arrival time
	Given I naviagte to tfl homepage
	And I clicked on the journey planner
	And I enter '<london bridge>' as my from
	And I enter '<London Waterloo>' as my to
	And I click on arrival tab
	When I click plan my journey
	Then the result should display the journey information based on arrival time

@tfltest5
Scenario: Edit a plan journey 
	Given I naviagte to tfl homepage
	And I clicked on the journey planner
	And I enter '<london bridge>' as my from
	And I enter '<London Waterloo>' as my to
	When I click plan my journey
	Then the result should display the journey information
	And I click on edit journey hyperlink
	Then The original journey page is displayed
	And I change from location to  '<london charing cross>' 
	And I click update journey 
	Then the result should display the newly updated journey information

@tfltest6
Scenario: View the recent plan journey 
	Given I naviagte to tfl homepage
	And I clicked on the journey planner
	And I enter '<london bridge>' as my from
	And I enter '<London Waterloo>' as my to
	When I click plan my journey
	Then the result should display the journey information
	And I navigate to tfl homepage
	And I click on the recent tab
	And I enable the cookies if not enabled
	Then I can view the recent planned journey
