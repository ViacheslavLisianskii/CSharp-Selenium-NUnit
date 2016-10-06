using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestFramework.Driver
{
    public class WebDriverFactory
    {
        public static IWebDriver GetInstance(BrowserType browserName)
        {
            Logger.Info($"WebDriver initializing - {browserName}");

            switch (browserName)
            {
                case BrowserType.Chrome:
                {
                    var options = new ChromeOptions {BinaryLocation = "path to driver"};
                    return new ChromeDriver(options);
                }
                case BrowserType.Firefox:
                {
                    var firefoxProfile = new FirefoxProfile();
                    return new FirefoxDriver(firefoxProfile);
                }
                default:
                {
                    Logger.Error($"WebDriver service not found - {browserName}");
                    throw new DriverServiceNotFoundException();
                }
            }
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}
