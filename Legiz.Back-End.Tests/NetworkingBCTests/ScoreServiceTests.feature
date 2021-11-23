Feature: ScoreServiceTests
	As a Developer
	I want to add new Score through API
	So that It can be available for applications
	
	Background: 
		Given the Endpoint https://localhost:5001/api/v1/scores is available

@score-adding
Scenario: Add Score
	When A Post Request is sent
	| start | comment              |
	| 3     | Hizo un buen trabajo |
	Then A Response with Status 200 is received
	And A Score Resource is included in Response Body
	| start | comment              |
	| 3     | Hizo un buen trabajo |