Manual Deployment Details (GUI Angular)
Deployment Url
•   Dev: https://dev-app-urax4.azurewebsites.net
    Resource Group: subWLTP_uraxdev
    App Service Name: dev-app-urax4
•   Test: https://urax-test-volvocars.azurewebsites.net/
    Resource Group: subWLTP_uraxdev
    App Service Name: urax-test
•   QA : http://qa2-app-urax4.azurewebsites.net
    Resource Group: subWLTP_uraxqa
    App Service Name: qa2-app-urax4
-------------------------------------------------------
step 1:
 map api url in api-url.model.ts

 step 2:
 map clientid to its apporpriate app envernoment
 ex
 for dev  clientid:this.dev
 file name SecretService.ts
 