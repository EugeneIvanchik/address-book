using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace address_book
{
    public class TestBase
    {
        public Application app;

        [SetUp]
        public void SetupTest()
        {
            app = new Application();
            app.Navigator.OpenLoginPage();
            app.LogInOut.Login(new UserAccount("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}