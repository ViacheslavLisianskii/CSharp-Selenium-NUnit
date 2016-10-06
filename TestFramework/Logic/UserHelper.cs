namespace TestFramework.Logic
{
    public class UserHelper : DriverBasedHelper
    {
        public UserHelper(ApplicationManager manager)
            : base(manager.GetWebDriver())
        {
        }

        public void LoginAs(string email, string password)
        {
            Pages.LoginPage
                .SetEmail(email)
                .SetPassword(password)
                .ClickLogin();
        }

        public string GetErrorMessage()
        {
            return Pages.LoginPage
                .GetErrorMessage();
        }
    }
}
