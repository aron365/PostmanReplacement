# Convert Postman backups to VS Code REST Client HTTP files
With Postman removing its Scrachpad (self-hosted) functionality, I have stopped using it.
To prepare for the transition I backed up my Postman collections and researched alternatives.

When I opened Postman yesterday, the app had auto-updated and the Scratchpad was gone. 
I deleted my Postman account and uninstalled the app.

As far as a replacement goes, for now I'm going with the [VS Code](https://code.visualstudio.com/) extension [REST Client](https://github.com/Huachao/vscode-restclient).

This .NET 8.0 console app converts Postman backup JSON files or Postman collection export JSON files to .http files for use with REST Client.

Please note that this app converts only core information such as a request's method, URL, headers, and body. However, the solution includes the complete Postman object models, upon which more advanced processing can be built.

The command line arguments are:  
1. source file or folder - the path to either a Postman backup JSON file or a folder containing Postman collection export JSON files.
2. target folder - where the app will output the .http files

When outputting the .http files, the app creates a subfolder for each collection and a file in that folder for each request.
The app skips requests that lack a url.

If you have lost access to Scratchpad before you had a chance to export your collections, backup JSON files should be available here:
C:\Users\username\AppData\Roaming\Postman.
