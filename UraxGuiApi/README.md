Manual Deployment Details (GUI API)
Deployment Url
•   Dev: https://urax-main-dev.azurewebsites.net
    Resource Group: subWLTP_uraxdev
    App Service Name: urax-main-dev
•   Test: https://urax-main-test.azurewebsites.net
    Resource Group: subWLTP_uraxdev
    App Service Name: urax-main-test
•   QA : https://urax-main-qa2.azurewebsites.net
    Resource Group: subWLTP_uraxqa
    App Service Name: urax-main-qa2
---------------------------------------------------------------------
Need to change database connectionStrings in webconfig file for each Environment (Web.config file in root folder)
•   DEV
    Comment Test and QA connectionStrings in webconfig file
    •   TEST
    Comment DEV and QA connectionStrings in webconfig file
•   QA
    Comment Test and DEV connectionStrings in webconfig file
Need to change Tax Engine URL  in webconfig file for each Environment (Web.config file in root folder)
dev :<add key="TaxEngineUrl" value="http://uraxsfdev.northeurope.cloudapp.azure.com:8086/" />
test:<add key="TaxEngineUrl" value="http://uraxsftest.northeurope.cloudapp.azure.com:8086/" />
qa:<add key="TaxEngineUrl" value="http://uraxsfqa.northeurope.cloudapp.azure.com:8086/" />
-------------------------------------------------------------------
Step to Deploy:
Right Click on Project Solutions
Select Publish
Select create new profile
Select Microsoft Azure App Service
Select Select Existing, click on Publish
Subscription: WLTP
View: Resource Group
Select Resource group folder (for Dev/Test/Qa)
Select AppService(for Dev/Test/Qa)
Click on OK
------------------------------------------------------------------
