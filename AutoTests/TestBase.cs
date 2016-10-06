using NUnit.Framework;
using TestFramework.Logic;

namespace AutoTests
{
    public class TestBase
    {
        protected ApplicationManager App;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            App = new ApplicationManager();
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            App.Quit();
        }
    }
}