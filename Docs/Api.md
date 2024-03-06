# Rest API Documentation

- [Rest API](#rest-api)
    - [Get Stations](#get-stations)

## Get Stations

### Get Stations Request

```js
GET /stations
```
Returns a List of the ff:

```json
{
    "label":"Rainfall station",
    "lat":"53.983799",
    "stationReference":"040752"
}
```

### Get Stations Response

```js
200 Ok
```

###Follow me -> Steps for Creating Web API .net Core 6.0

Step 1: Install Extensions
* Markdown Preview Enhanced - For Documentation
* REST Client - For unit testing api
* ```dotnet add .\RestApi\ package ErrorOr```

Step 2: Create the API
* ```dotnet new console --framework net6.0 --use-program-main```
* ```dotnet new sln -o RestApi```

Step 3: Create the Classlib
* dotnet new classlib -o RestApi.Contracts
* Check .csproj and Change to 
```<TargetFramework>net6.0</TargetFramework>```

Step 4: Create the Web API
* dotnet new webapi -o RestApi
* Check .csproj and Change to ```<TargetFramework>net6.0</TargetFramework>```

Step 5: Create association because .sln is empty
* ```dotnet sln add .\RestApi\ .\RestApi.Contracts\```
		or
* ```dotnet sln add (ls -r **/*.csproj)```

Step 6: Open the Folder in Vs Code
* code .

Step 7: Code the Web Serice API
	
Step 8: Create a package reference for json
* ```dotnet add .\RestApi\ package Newtonsoft.Json```


###Running and Testing the Project

Step 1: Go to the powershell terminal and cd to the root directory of the project.

Step 2: Build the Project
* ```dotnet build```

Step 3:	Run the Project
* ```dotnet run --project .\RestApi\```

Step 4: Use Rest Client to trigger the API. Running port will change on other machine.
```
		GET http://localhost:5229/stations
		Content-Type: application/json
```

or 

Step 5: Send message to the web server using 
* UnitTest\GetStations\GetStation.http