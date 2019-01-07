# Salesforce OAuth2 Web Server Flow Example

This example is to complement a blog post available at (post link coming soon) which outlines how to use the Web Server Flow method of OAuth authentication with Salesforce, .NET Core, and ngrok.

## Prerequisites

* [.NET Core 2.1+](https://dotnet.microsoft.com/download)
* [VS Code](https://code.visualstudio.com/)
* [Salesforce Developer Account](https://developer.salesforce.com)
* [Salesforce Connect App Client Id and Secret](https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/intro_defining_remote_access_applications.htm)
* Supporting Blog Post (coming soon)

## Installation

Once you have setup your Salesforce Developer account, and defined the 'Connected App', update appsettings.json file with your client-id and client-secret.  Note: You should convert this to use user-secrets in development, and environment variables and/or azure key vault in production to ensure security.

Once settings are updated, crun the following commands from your favorite command console.   Mine is [ConEmu](https://conemu.github.io/).

```bash
dotnet build
dotnet run
```

## Usage

Below is an example diagram [from Salesforce](https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/intro_understanding_web_server_oauth_flow.htm) that outlines how the flow works.   In our demo application, this follow happens inside the SalesforceController.cs and you can start your code navigation from there.

![alt text](https://developer.salesforce.com/docs/resources/img/en-us/216.0?doc_id=dev_guides%2Fchatter_connect%2Fimages%2Foauth_web_flow.png&folder=api_rest "Salesforce OAuth2 Web Server Flow")

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
