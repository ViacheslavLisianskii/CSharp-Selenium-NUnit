using System;
using System.Configuration;
using NLog;
using OpenQA.Selenium;
using TestFramework.Driver;

namespace TestFramework.Logic
{
    public class ApplicationManager
    {
        public ApplicationManager()
        {
            _driver = WebDriverFactory.GetInstance(BrowserType.Chrome);
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Parse(ConfigurationManager.AppSettings["ElementTimeout"]));

            _userHelper = new UserHelper(this);
        }

        public UserHelper GetUserHelper()
        {
            return _userHelper;
        }

        public IWebDriver GetWebDriver()
        {
            return _driver;
        }

        public void Quit()
        {
            _logger.Info("Stop WebDriver");
            _driver?.Quit();
        }

        private readonly UserHelper _userHelper;
        private readonly IWebDriver _driver;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
