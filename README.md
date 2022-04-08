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
4) Change the DB connection strig in [this config file](https://github.com/Lawrencesoft/RestaurantDetails/blob/main/Restaurant/appsettings.json)

**Publish :** Open the Visual Studio(2019) IDE 
**Build**  Menu --> **Publish Restaurant** <br />
&nbsp;&nbsp;&nbsp;&nbsp;Select the path to publish it. Once it is publish to the path, This path can be link from IIS and run from there <br />

**Test Project Execution:** Open the Visual Studio(2019) IDE **Test**  Menu --> Run All Tests<br />
    Once it is executed, Test explorer will show the test results(Executed screenshot added below) 

# ScreenShots
****Welcome Page**** <br>
![image](https://user-images.githubusercontent.com/63959021/162424721-7308e58e-394a-42ac-af70-efbb028b4766.png)
****Available Restaurant Page**** <br>
![image](https://user-images.githubusercontent.com/63959021/162424858-b9cee669-cf75-4dcf-a8be-919cab898da6.png)
![image](https://user-images.githubusercontent.com/63959021/162424944-9787436c-56db-46c6-a76a-b826663dc5fc.png)
![image](https://user-images.githubusercontent.com/63959021/162425037-5a1dc0a2-3752-439b-8055-4e4004774a4b.png)
****API Result Page**** <br>
![image](https://user-images.githubusercontent.com/63959021/162425116-ee859cfb-a5d2-42db-94c1-d80d10438ea3.png)




