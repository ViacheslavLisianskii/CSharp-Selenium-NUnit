using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.PageObjects
{
    public class LoginPage : Page
    {
        private const string EmailInputXpath = "//*[contains(@class, 'auth-form')]/input[@name='email']";
        private const string PasswordInputXpath = "//*[contains(@class, 'auth-form')]/input[@name='password']";
        private const string LoginButtonXpath = "//*[contains(@class, 'auth-form')]/button[@type='submit']";
        private const string ErrorTextXpath = "//*[contains(@class, 'auth-form')]/div[contains(@class, 'auth-form__alert')]";

        public LoginPage(PageManager pages)
            : base(pages)
        {
        }

        public LoginPage SetEmail(string email)
        {
            WaitForAjax();

            emailInput.Clear();
            emailInput.SendKeys(email);

            return this;
        }

        public LoginPage SetPassword(string password)
        {
            WaitForAjax();

            passwordInput.Clear();
            passwordInput.SendKeys(password);

            return this;
        }

        public void ClickLogin()
        {
            loginButton.Click();
        }

        public string GetErrorMessage()
        {
            WaitForAjax();

            return errorMessageText.Text;
        }

        [FindsBy(How = How.XPath, Using = EmailInputXpath)]
        private IWebElement emailInput;
        [FindsBy(How = How.XPath, Using = PasswordInputXpath)]
        private IWebElement passwordInput;
        [FindsBy(How = How.XPath, Using = LoginButtonXpath)]
        private IWebElement loginButton;
        [FindsBy(How = How.XPath, Using = ErrorTextXpath)]
        private IWebElement errorMessageText;
    }
}