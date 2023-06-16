*** Settings ***
Library    RequestsLibrary
Library    String
Library    .venv/Lib/site-packages/robot/libraries/DateTime.py

*** Keywords ***
Create section
    Create Session    alias=API    url=https://localhost:7063/api/
Create todo
    ${name}    Generate Random String    10    chars=[LETTERS]
    ${dateConclusion}    Get Current Date    result_format=%Y-%m-%dT%H:%M:%S    exclude_millis=true

    Set Test Variable    ${name}
    Set Test Variable    ${dateConclusion}
    
Insert todo
    [Arguments]    ${status}
    ${body}    Create Dictionary
    ...    name= ${name}
    ...    dateConclusion=${dateConclusion}
    ${response}    POST On Session
    ...    alias=API
    ...    url=/Todos
    ...    json=${body}
    ...    expected_status=${status}
    Set Test Variable    ${status_response_post_correct}    ${response.status_code}
    
Verify if todo was inserted with success
    IF    ${status_response_post_correct} == 201
        Pass Execution    Post with success
    ELSE
        Fail
    END

Create todo with error - exceeding characters name
    ${name}    Generate Random String    301    chars=[LETTERS]
    ${dateConclusion}    Get Current Date    result_format=%Y-%m-%dT%H:%M:%S    exclude_millis=true

    Set Test Variable    ${name}
    Set Test Variable    ${dateConclusion}

Verify if todo was inserted with error
    IF    ${status_response_post_correct} == 400
        Pass Execution    Post with error
    ELSE
        Fail
    END
