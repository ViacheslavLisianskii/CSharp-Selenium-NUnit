using OpenQA.Selenium;

namespace TestFramework.WebElements
{
    public class JavaScriptAlert
    {
        public JavaScriptAlert(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        
        public string JavaScriptText => _webDriver.SwitchTo().Alert().Text;

        public void ConfirmJavaScriptAlert()
        {
            _webDriver.SwitchTo().Alert().Accept();
            _webDriver.SwitchTo().DefaultContent();
        }
        
        public void DismissJavaScriptAlert()
        {
            _webDriver.SwitchTo().Alert().Dismiss();
            _webDriver.SwitchTo().DefaultContent();
        }
        
        public void SendTextToJavaScript(string text)
        {
            _webDriver.SwitchTo().Alert().SendKeys(text);
        }

        private readonly IWebDriver _webDriver;
    }
}
