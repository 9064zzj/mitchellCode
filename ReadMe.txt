This project is implemented by C#, WCF & .NetFramework 4.5. on Visual Studio 2015
A working service are deployed on Windows Azure Web App on:
http://codechallengestevez.azurewebsites.net/vehicleservice.svc/vehicles/

All the API's operation should works. Besides that, it can accept parameters to filter GET result
The parameter should be format like this:
http://codechallengestevez.azurewebsites.net/vehicleservice.svc/vehicles/?make=*&model=*&year=*
The "*" should substituted to your interesting key words. However, if you don't want one of keywords filtering, you need keep this format and delete "*".
KNOWN ISSUE:
I try to congifure WCF CORS service. However it didn't works. So you need other clients to test this service. I use Postman from Chrome App store. It works fine.


The source file have 3 project.
\CodeChallenge is the vehicle RESTful service itself. VehicleService.svc bear the RESTful service. The core classes/interfaces are in \DataAccessLayer, \BusinessLogic, \ServiceLayer. The complied .dll are in \bin
\CodeChallenge.Azure is Azure project generate by Visual Studio.
\CodeChallengeUnitTest is the Unit Test for some important public functions.