*** Settings ***
Resource     todo_resource.robot
Suite Setup    Create section

*** Test Cases ***
Test01 Post todo with success
    Create todo
    Insert todo     201
    Verify if todo was inserted with success

Test01 Post todo with error - Exceeding characters for name
    Create todo with error - exceeding characters name
    Insert todo     400
    Verify if todo was inserted with error
