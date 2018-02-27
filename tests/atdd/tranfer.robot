*** Settings ***
Library    RequestsLibrary
Library    Collections


*** Variables ***
${URL_POST}    http://localhost:5001

*** Test cases ***
Tranfer money from Chitpong to Chonnikan , Success
  Post API Tranfer
  Transfer Money Success    7581233661    6302445476    500.00    KBANK


*** Keywords ***
Post API Tranfer 
   Create Session    Tranfer    ${URL_POST}

Transfer Money Success
    [Arguments]    ${origin_account_id}    ${destination_account_id}    ${transfer_amount}    ${destination_bank}
    &{data}=   Create Dictionary    origin_account_id=${origin_account_id}    destination_account_id=${destination_account_id}    transfer_amount=${transfer_amount}    destination_bank=${destination_bank}
    &{headers}    Create Dictionary    Content-Type=from-data
    ${resp}=  Post Request  Tranfer    /transactions		data=${data}    headers=${headers}
    ${ID}=    Get From Dictionary    ${resp.json()}    transaction_id
    Should Be Equal As Strings  ${resp.status_code}  200



