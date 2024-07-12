using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final.Core
{

    public class DriverManager

    {

        [ThreadStatic]
        public static IWebDriver driver;
        public static WebDriverWait wait;

        public static void InitDriver(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("test-type");
                    //chromeOptions.AddArguments("headless");
                    chromeOptions.AddArguments("--no-sandbox");
                    driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments("headless");
                    edgeOptions.AddArguments("--no-sandbox");
                    driver = new EdgeDriver(edgeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("headless");
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(browserName, "Browser not supported: " + browserName);
            }

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public static void CloseDriver()
        {
            driver.Quit();
        }

       
    }
}

//driver.Manage().Window.Maximize();
//driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
//driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);