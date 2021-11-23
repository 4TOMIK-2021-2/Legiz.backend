Feature: CustomLegalCaseServiceTests
As a Developer
I want to add new Custom Legal Case through API
So that It can be available for applications
	
    Background: 
        Given the Endpoint https://localhost:5001/api/v1/customlegalcases is available

    @CustomLegalCase-adding
    Scenario: Add CustomLegalCase
        When A Post Request is sent
          | EStatusLawService | Title          | LawyerId | CustomerId | LegalDocumentId | TypeMeet | LinkZoom                                                                                 |
          | 2                 | Problema legal | 1        | 1          | 1               | 1        | https://success.zoom.us/j/13483482/201362183 |
        Then A Response with Status 200 is received
        And A CustomLegalCase Resource is included in Response Body
          | EStatusLawService | Title          | LawyerId | CustomerId | LegalDocumentId | TypeMeet | LinkZoom                                     |
          | 2                 | Problema legal | 1        | 1          | 1               | 1        | https://success.zoom.us/j/13483482/201362183 |