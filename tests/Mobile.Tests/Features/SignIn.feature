Feature: SignIn
The sign in process/feature

    Background:
        Given I am at the "Start" page
        When I tap on "Login" button

    @validcredentials
    Scenario: SignIn with valid credentials
        Then I fill in the following form
          | field    | value            |
          | Email    | valid@domain.com |
          | Password | Admin123**       |
        Then I tap on "SignIn" button
        Then I should be at the "Home" page

    @invalidcredentials
    Scenario: SignIn with invalid credentials
        Then I fill in the following form
          | field    | value              |
          | Email    | invalid@domain.com |
          | Password | Admin123**         |
        And I tap on "SignIn" button
        Then I should be at the "LoginError" page

    @forgotpassword
    Scenario: Forgot password with valid email
        When I tap on "ForgotPassword" button
        Then I should be at the "ResetPassword" page