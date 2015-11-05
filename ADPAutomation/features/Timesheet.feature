Feature: Timesheet
	As an employee
	I need to enter my hours into my time card
	So that I can get paid
Background: 
	Given I am logged in to ADP with user " " and password ""
	
Scenario: Enter time for the week
	Given I navigate to my timecard page
	And I enter time for the week
	When I submit my timecard
	Then I should get a success message