# QA-Server

## Client App is [here](https://github.com/sarthakdixit/QA-Client/tree/main)


## Register Application

Register your web api application [here](https://portal.azure.com/#view/Microsoft_AAD_RegisteredApps/ApplicationsListBlade). [Click here](https://learn.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app) for help.


## Configure setting

After registering your application, input your application details in appsetting.json


## Expose API

1) Expose API by adding a scope. [Click here](https://learn.microsoft.com/en-us/azure/active-directory/develop/quickstart-configure-app-expose-web-apis) for help.
2) Enter scopes names in appsetting.json in Scopes and AppPermissions.


## Create Cosmos DB

Create Cosmos DB [here](https://portal.azure.com/#view/HubsExtension/BrowseResource/resourceType/Microsoft.DocumentDb%2FdatabaseAccounts). 
After creating DB and containers input config details in appsetting.json
