Feature: Jobs API
As a developer
I want to manage Job Offers through an API
In order to make it available for client applications.


  Scenario: Get all Offers
    Given I am a client
    And the repository has data
      | Id | Title                                     | Image                                                                                                         | description               | salaryRange | status |
      | 1  | Remote Software Engineer                  | https://images.pexels.com/photos/574071/pexels-photo-574071.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1 | This is a unique role ... | $115k-$117k | TRUE   |
      | 2  | Remote Senior Embedded Android Specialist | https://miro.medium.com/max/875/1*8si943UlaDsBo8i7xm-bGg.png                                                  | Hinge Health is buildi .. | $145k-$157k | FALSE  |
    When a GET request is sent
    Then a response with status 200 is received
    And a list of Offer resources is included in the body
      | Id | Title                                     | Image                                                                                                         | description               | salaryRange | status |
      | 1  | Remote Software Engineer                  | https://images.pexels.com/photos/574071/pexels-photo-574071.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1 | This is a unique role ... | $115k-$117k | TRUE   |
      | 2  | Remote Senior Embedded Android Specialist | https://miro.medium.com/max/875/1*8si943UlaDsBo8i7xm-bGg.png                                                  | Hinge Health is buildi .. | $145k-$157k | FALSE  |