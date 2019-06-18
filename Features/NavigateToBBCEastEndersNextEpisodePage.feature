Feature: Navigate To BBC EastEnders Next Episode Page
	In order to avoid missing EastEnders
	As a user on the BBC websites
	I want to find out when the next episode occurs

	Background: 
	Given I'm on the "https://www.bbc.co.uk" homepage


@InputfieldTesting StateTransitioningTesting
Scenario: Search for EastEnders next episode
	When I search for EastEnders Episode Next on schedule: 
	| criteria   |
	| EastEnders |
	Then I am redirected to the Next Episodes screen



@EquivalencePartitionTesting
Scenario Outline: Navigate to EastEnders schedule page on BBC website by entering url manually. 
	When I request to navigate to "<EpisodesPage>"
	Then I am redirected to the Next Episodes screen
Examples: 
	| EpisodesPage                                                  |
	| https://www.bbc.co.uk/programmes/b006m86d/broadcasts/upcoming |


