# _Evolent Health Project exercise_
This application is based on the .Net core entity framework code first approach.


## Application Details
- Target Framework : .Net Core 3.1
- Language use: c#, JQuery, HTML, CSS

## System Requirments
- Visual Studio 2019
- Language support: C#
- Microsoft SQL Server 2017 +

## Application Folder Structure
There is 3 project in this solution

**1. CoreApplication** - It's .Net Core Class library which contains the IRepository interface, these interfaces are the base type for all Repository types.

**2. Infrastructure** - It's .Net Core Class library which contains the Repository class, these are the generic Repository class.

**3. Evolent Health-Project exercise** - It's a .Net Core Web application that contains Web UI and backend API.


## How to run an application
Steps
1. Clone the Application on a local machine.
2. Run the `solution file`  **Path** - Evolent-Health-Project-exercise-main/Evolent Health - Project exercise.sln
3. Open `appsettings.json` file **Path** - Evolent-Health-Project-exercise-main/Evolent Health - Project exercise/appsettings.json
4. Change the 'LocalDbConnection' value under the ConnectionStrings section with your MS SQL Server connection string.
5. Run the Web application

**NOTE**
- This Repository also contains the video for How to run the application `Run_application.mp4` 
- Database will autometicaly create while project run AND Repository also contains database scrtpt file in case need Database.

Thanks!
