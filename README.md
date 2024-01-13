# SeleniumAutomationWithCSharp
This Repository contains project for Selenium with C#

In Order to open this project in visual studio after cloning
1. Create a solution and project in visual studio
2. Right click on solution to add the C# project file
3. This should import the project

If above does not work
Then,

1. Create a new solution and project in visual studio
2. Copy all the files from cloned project in the newly created project
------------------------------------------------------------------------------------------------------

To create a nUnit project in VS code:

run command: dotnet new nunit
To run from command line:

cd <ProjectDirectory>  [Move to project directory if you are in solution directory)
dotnet test <csharp Project file name>

e.g: dotnet test SeleniumAutomationWithCSharp.csproj

     dotnet test SeleniumAutomationWithCSharp.csproj --filter TestCategory=Smoke 

      dotnet test --filter "USOpenTest.getUSOpenChampionPic"  [Here ClassName.TestMethodName]

  //To send global variables to framework from command line
     dotnet test SeleniumAutomationWithCSharp.csproj --filter TestCategory=Smoke -- TestRunParameters.Parameter\(name=\"myParam\",\ value=\"value\"\)
-------------------------------------------------------------------------------------------------------
