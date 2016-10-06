using OpenQA.Selenium;
using TestFramework.PageObjects;

namespace TestFramework.Logic
{
    public class DriverBasedHelper
    {
        protected PageManager Pages;

        public DriverBasedHelper(IWebDriver driver)
        {
            Pages = new PageManager(driver);
        }
    }
}
