Feature: Blood Pressure Category Calculation

  Scenario: Low Blood Pressure
    Given systolic is 90
    And diastolic is 60
    When blood pressure is calculated
    Then the category should be Low

  Scenario: Ideal Blood Pressure
    Given systolic is 120
    And diastolic is 80
    When blood pressure is calculated
    Then the category should be Ideal

  Scenario: Pre-High Blood Pressure
    Given systolic is 140
    And diastolic is 90
    When blood pressure is calculated
    Then the category should be PreHigh

  Scenario: High Blood Pressure
    Given systolic is 150
    And diastolic is 95
    When blood pressure is calculated
    Then the category should be High