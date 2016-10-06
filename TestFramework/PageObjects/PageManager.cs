using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.PageObjects
{
    public class PageManager
    {
        public LoginPage LoginPage;

        public PageManager(IWebDriver driver)
        {
            _driver = driver;
            LoginPage = InitElements(new LoginPage(this));
        }

        private T InitElements<T>(T page)
        {
            PageFactory.InitElements(_driver, page);
            return page;
        }

        public IWebDriver GetWebDriver()
        {
            return _driver;
        }

        private readonly IWebDriver _driver;
    }
}