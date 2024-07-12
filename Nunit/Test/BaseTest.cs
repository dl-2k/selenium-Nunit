using final.Core;
using final.Helper;
using final.Test;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace final.Test
{
    [TestFixture]
    public class BaseTest
    {
    
 

        [SetUp]
        public void SetUp()
        {
            string browser = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "browser");
            string enviroment = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "enviroment");

            // Create report path dynamically
            string date = DateTime.Now.ToString("ddMMMMMyyyy_HHmm");
            string projectDirectory = Directory.GetCurrentDirectory();
            string testResultsDirectory = Path.Combine(projectDirectory, "TestResults");
            Directory.CreateDirectory(testResultsDirectory);

            string testClassName = TestContext.CurrentContext.Test.ClassName;
            string classNameWithoutNamespace = testClassName.Substring(testClassName.LastIndexOf('.') + 1);

            string functionTestDirectory = Path.Combine(testResultsDirectory, $"Result{classNameWithoutNamespace}_{date}");
            Directory.CreateDirectory(functionTestDirectory);

            string reportPath = Path.Combine(functionTestDirectory, "result.html");

            ExtentReportHelper.InitializeReport(reportPath, "Hostname", enviroment, browser);
            ExtentReportHelper.CreateTest(TestContext.CurrentContext.Test.ClassName);
            ExtentReportHelper.CreateNode(TestContext.CurrentContext.Test.Name);
            ExtentReportHelper.LogTestStep("Initialize webdriver");

            //string browser = "chrome";

            DriverManager.InitDriver(browser);
            DriverManager.driver.Manage().Window.Maximize();
            DriverManager.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            DriverManager.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            ExtentReportHelper.CreateTestResult(status, stacktrace, TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name, DriverManager.driver);
            ExtentReportHelper.Flush();
            DriverManager.driver.Quit();
        }


    }
}


  





