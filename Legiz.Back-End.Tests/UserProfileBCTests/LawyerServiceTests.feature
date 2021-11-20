Feature: LawyerServiceTests
	As a Developer
	I want to add new Lawyer through API
	So that It can be available for applications
	
	Background: 
		Given the Endpoint https://localhost:5001/api/v1/lawyers is available

@lawyer-adding
@mytag
Scenario: Add Lawyer
	When A Post Request is sent
	  | Id | Username | Password | Email         | LawyerName | LawyerLastName | District | Phone     | University | Specialization | PriceLegalAdvice | PriceCustomContract |
	  | 1  | m123     | s1       | m@hotmail.com | Mauricio   | Carmen         | Callao   | 937598438 | UPC        | 1              | 40               | 50                  |
	Then A Response with Status 200 is received
	And A Lawyer Resource is included in Response Body
	  | Id | Username | Password | Email         | LawyerName | LawyerLastName | District | Phone     | University | Specialization | PriceLegalAdvice | PriceCustomContract |
	  | 1  | m123     | s1       | m@hotmail.com | Mauricio   | Carmen         | Callao   | 937598438 | UPC        | BusinessLaw              | 40               | 50        |
  


