# CSharpDesktopFramework

This project contains automated test scripts for testing the quasar.dev website using Selenium and NUnit. The scripts are designed to perform various interactions and validations on the website's pages.

Prerequisites

.NET SDK
NUnit
NLog
Selenium WebDriver
Appium.WebDriver

Installation

Clone or download this repository to your local machine.
Open the project in your preferred IDE, such as Visual Studio.
Restore NuGet packages to ensure all dependencies are downloaded.

Configuration

Configure the testconfig.json file with appropriate URLs, binary locations, and driver paths for both Desktop and Mobile configurations.
json
Copy code
{
  "Desktop": {
    "Url": "https://quasar.dev/",
    "BinaryLocation": "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
    "DriverPath": "C:\\Coding\\Automation Learning\\QuasarAutomation\\"
  },
  "Mobile": {
    "Url": "https://quasar.dev/",
    "BinaryLocation": "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
    "DriverPath": "C:\\Coding\\Automation Learning\\QuasarAutomation\\"
  }
}
Adjust the configuration settings as per your environment.

Usage

Open a terminal and navigate to the project directory.
Run the tests using the following command:
dotnet test
The tests will be executed, and the test outcomes will be logged using NLog.

Project Structure

QuasarAutomation.Pages: Contains page classes for interacting with different pages of the website.
QuasarAutomation.DesktopResources: Contains static resources such as URLs and selectors for desktop automation.
QuasarAutomation.DesktopUtils: Contains utilities and driver setup for desktop automation.
QuasarAutomation.Tests: Contains test cases written using NUnit framework.

Logging

Test outcomes and error messages are logged using NLog. The log file is generated in the project directory with the name NLogLog.log.

Acknowledgments

The code in this repository were created with a little help from Chat GPT by Jonathan Howard, an aspiring software developer with expertise in Agile Software Development and proficiency in various programming languages.
