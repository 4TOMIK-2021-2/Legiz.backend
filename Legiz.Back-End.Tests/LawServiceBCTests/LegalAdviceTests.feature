Feature: LegalAdviceServiceTests
As a Developer
I want to add new Legal Advice through API
So that It can be available for applications
	
    Background: 
        Given the Endpoint https://localhost:5001/api/v1/legaladvices is available

    @LegalAdvice-adding
    Scenario: Add LegalAdvice
        When A Post Request is sent
          | EStatusLawService | Title          | LawyerId | CustomerId | LegalDocumentId | Description              | LegalResponse                              |
          | 2                 | Problema legal | 1        | 1          | 1               | Existe un problema legal | Esto se resuelve de la siguiente manera... |
        Then A Response with Status 200 is received
        And A LegalAdvice Resource is included in Response Body
          | EStatusLawService | Title          | LawyerId | CustomerId | LegalDocumentId | Description              | LegalResponse                              |
          | 2                 | Problema legal | 1        | 1          | 1               | Existe un problema legal | Esto se resuelve de la siguiente manera... |