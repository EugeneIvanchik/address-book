using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCreds()
        {
            app.LogInOut.Logout();

            UserAccount account = new UserAccount("admin", "secret");
            app.LogInOut.Login(account);

            Assert.IsTrue(app.LogInOut.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInValidCreds()
        {
            app.LogInOut.Logout();

            UserAccount account = new UserAccount("admin", "secret1");
            app.LogInOut.Login(account);

            Assert.IsFalse(app.LogInOut.IsLoggedIn());
        }
    }
}
