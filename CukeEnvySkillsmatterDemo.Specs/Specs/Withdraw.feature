Feature: Cash Withdrawal

 Scenario: Successfully withdrawal from an account in credit
    Given my account has a balance of $100
    When I withdraw $20
    Then $20 should be dispensed
    And the balance of my account should be $80

Scenario Outline: Many successfully withdrawals from an account in credit
    Given my account has a balance of $<balance>
    When I withdraw $<withdraw amount>
    Then $<dispensed amount> should be dispensed
    And the balance of my account should be $<new balance>

Examples: 
	| balance | withdraw amount | dispensed amount | new balance |
	| 100     | 20              | 20               | 80          |
	| 10      | 10              | 10               | 0           |