using NUnit.Framework;

namespace AutoTests
{
    public class LoginTests : TestBase
    {
        [Test]
        public void correctEmailAndPassword_LoginSuccessful()
        {
            App.GetUserHelper().LoginAs("login", "password");
            Assert.IsEmpty(App.GetUserHelper().GetErrorMessage());
        }

        [Test]
        public void incorrectPassword_ErrorMessageIsDisplayed()
        {
            App.GetUserHelper().LoginAs("321", "123");
            Assert.AreEqual(App.GetUserHelper().GetErrorMessage(), "Error! Wrong login or password.");
        }
    }
}