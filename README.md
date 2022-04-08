# Restaurant Details
To find the available restaurant details


# Challenge Description:

1. You have the following API endpoint:
https://postman-echo.com/get?foo1=bar1&foo2=bar2
Please set up a quick page using any language. Call the API endpoint
and display results

2. Given the attached CSV data file - [rest_open_hours.csv](https://github.com/Lawrencesoft/RestaurantDetails/blob/main/rest_open_hours.csv) </br>
a. Write a function that parses the data into a table</br>
b. Write a function that receives a date object native to your
language of choice and uses a sql query to return a list of
restaurant names which are open on that date and time.

Assumptions:
* If a day of the week is not listed, the restaurant is closed on
that day
* All times are local — don’t worry about timezone-awareness
* The CSV file will be well-formed
Optimized solutions are nice, but correct
So, I have a friend called Frank. He owns a second hand car garage and needs your help!
He would like you to create a website for his shop. These days Frank only sells his second hand cars online and could use a website of his own. With that said I guess we should do this in phases, because you know...agile! So it would be best if you start with Phase1!

# Technologies and Details
- For the Front end framework - ASP.Net MVC
- For the Back end -C# Core Web API
- Test cases created separately - Need to add more - Added few
- Added Dependancy Injection

# Required version to build and execute the Repository
.NET 5.0 version(.Net Core 5.0) Visual Studio 2019 IDE
<br>

# Build and Run the Repository
Build any .NET Core project using the .NET Core CLI, which is installed with the [.NET Core SDK](https://dotnet.microsoft.com/download). Then run these commands from the CLI in the directory of this project:<br />

``dotnet build``<br />
``dotnet run``<br />

These will install any needed dependencies, build the project, and run the project respectively.  

**Other Options** - 
1) **Buid :** Open the Visual Studio(2019) IDE **Build**  Menu --> **Build solution**
2) **Run :** Open the [Restaurant.sln](https://github.com/Lawrencesoft/RestaurantDetails/blob/main/Restaurant.sln) in Visual Studio(2019) IDE and make the Restaurant as startup project and execute it or publish the API project in IIS and execute from there(Attached the screenshot below). 
3) Create a DB in SQL Server </br></br>

**Publish :** Open the Visual Studio(2022) IDE 
**Build**  Menu --> **Publish Restaurant** <br />
&nbsp;&nbsp;&nbsp;&nbsp;Select the path to publish it. Once it is publish to the path, This path can be link from IIS and run from there <br />

**Test Project Execution:** Open the Visual Studio(2022) IDE **Test**  Menu --> Run All Tests<br />
    Once it is executed, Test explorer will show the test results(Executed screenshot added below) 

# ScreenShots
****Login Page**** <br>
Username: ****admin****
<br>Password: ****password****
![image](https://user-images.githubusercontent.com/63959021/154868885-c07fddd4-e8ae-4e10-9bef-11d4b51c36ef.png)
****Phase 1:****![image](https://user-images.githubusercontent.com/63959021/154869192-62d83811-19f7-440c-b7ad-07561b8b52b7.png)
****Phase 2:**** ![image](https://user-images.githubusercontent.com/63959021/154869263-cd91213c-26d4-4611-b4a2-6ee9b5b50cc6.png)
****Phase 3:**** ![image](https://user-images.githubusercontent.com/63959021/154869290-c3132f17-538b-4df5-808b-51360e9796f6.png)

****Swagger API****<br>
![image](https://user-images.githubusercontent.com/63959021/154868738-9c84f642-9cae-48cb-9147-5efb62c3ce8e.png)
![image](https://user-images.githubusercontent.com/63959021/154869660-5d602d54-0bec-45f2-876d-5ef3e58d2f7e.png)


****Unit Test case Results****<br>
![image](https://user-images.githubusercontent.com/63959021/154869367-a0cfdbff-0043-4ad5-b4a4-4778247c1ea2.png)<br>
****UI Unit test cases****<br>
![image](https://user-images.githubusercontent.com/63959021/154869424-abf7f0ae-2e6c-42dd-b38f-3afcbeff7f77.png)


