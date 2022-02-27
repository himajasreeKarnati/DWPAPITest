About the project:

This project is about building an API which calls the API at https://bpdts-test-app.herokuapp.com/, and returns people who are listed as either living in London, 
or whose current coordinates are within 50 miles of London.


Installation:
- Visual Studio Community 2019 
- IIS Express

Build with:

- Application built in .Net Core 3.1 framework
- Application Link https://localhost:5001/index.html

This API is built with: 

Nuget Package for DWPAPIDemoProject: 
-Swashbuckle.AspNetCore(6.2.3)
-RestSharp(107.3.0)
-Newtonsoft.Json(12.0.2)

For unit testing of Dwp_tetsApi.Test:
- Moq(4.16.1)

Getting started:

Steps to run the WebApi:
- Download the project via Github link provided. 
- Open the Solution 'DWPTest' in Visual Studio.
- Download all the Nuget packages by going to the project DwpApiDemoProject --> Dependencies
  --> and right click on each nuget package --> click update.
- Once the above step is successful, Clean the solution and rebuild the application. Application should run 
  without any errors.
- In the menu select Debug in the dropdown and select Profile as DwpApiDemoProject from the dropdown.
- Right click on the DwpApiDemoProject and set the Startup project to DwpApiDemoProject and Profile should be set to DwpApiDemoProject.
- On setting the profile to DwpApiDemoProject,  when the application runs, it will open the api link https://localhost:5001/index.html
  in default set browser.
- The Link contains Swagger homepage listing all the Api actions. 

Steps To run the Unit Test:
- In the Solution, set Dwp_testApi.Test as startup project as mentioned in the above steps.
- Download the Nuget package by going to the project Dwp_testApi.Test --> Dependencies --> right click on package and click update.
- Build the project without any errors.
- Right click on the project and click Run test. 
- To view the result, from the Menu bar click on Test and then Test Explorer.