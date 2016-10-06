using System;
using System.Configuration;
using System.Globalization;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework.WebElements;

namespace TestFramework.PageObjects
{
    public abstract class Page
    {
        protected IWebDriver Driver;
        protected PageManager Pages;
        protected WebDriverWait Wait;

        protected Page(PageManager pages)
        {
            Pages = pages;
            Driver = pages.GetWebDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.Parse(ConfigurationManager.AppSettings["ElementTimeout"]));
        }

        protected JavaScriptAlert JavaScriptAlert()
        {
            return new JavaScriptAlert(Driver);
        }

        protected void NavigateTo(Uri url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        protected void WaitForAjax()
        {
            Wait.Until(
                driver =>
                {
                    var javaScriptExecutor = driver as IJavaScriptExecutor;
                    return javaScriptExecutor != null
                        && (bool)javaScriptExecutor.ExecuteScript("return jQuery.active == 0");
                });
        }

        protected void WaitForAngular()
        {
            Wait.Until(
                driver =>
                {
                    var javaScriptExecutor = driver as IJavaScriptExecutor;
                    return javaScriptExecutor != null
                        && (bool)javaScriptExecutor.ExecuteScript("return window.angular != undefined && window.angular.element(document.body).injector().get('$http').pendingRequests.length == 0");
                });
        }

        protected bool IsPageTitle(string pageTitle, double timeout)
        {
            try
            {
                Wait.Until(d => d.Title.ToLower(CultureInfo.CurrentCulture) == pageTitle.ToLower(CultureInfo.CurrentCulture));
            }
            catch (WebDriverTimeoutException)
            {
                _logger.Error(CultureInfo.CurrentCulture, "Actual page title is {0};", Driver.Title);
                return false;
            }

            return true;
        }

        protected void WaitUntilElementIsNoLongerFound(By locator)
        {
            Wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            Wait.Until(driver => Driver.FindElements(locator).Count == 0);
        }

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
