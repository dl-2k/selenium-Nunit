# Automation Test Project Selenium for DemoQA

## Overview
An automation test project for https://demoqa.com web, built on .NET 8 (C# is the main programming language), NUnit 3.

## Dependency Packages

| Package         | Description                               |       Link                                     |
|-----------------|-------------------------------------------|------------------------------------------|
| ExtentReports   |                   | [https://extentreports.com/]


## Development Tools

The project is set up using Visual Studio 2022, which is recommended as the main IDE. Alternatively, you can use Visual Studio Code, but you'll need to install the .NET 5 SDK and relevant C# extensions for effective project management and execution.


## Configuration Files

- The `appsetting.json` file is the main config file of this project, it allows you to configure the application URL.

## How to Run Tests

1. **Visual Studio 2022**:
   - Use Test Explorer to select tests to run.
2. **Visual Code**:
   - Install the .NET Core Test Explorer extension and then select tests to run.
3. **Command Lines**:
   - Restore all dependency packages: `dotnet restore`
   - Build project: `dotnet build`
   - Run tests: `dotnet test`