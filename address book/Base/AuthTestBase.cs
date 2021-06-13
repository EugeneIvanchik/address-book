using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void AuthSetupTest()
        {
            app.LogInOut.Login(new UserAccount("admin", "secret"));
        }
    }
}
