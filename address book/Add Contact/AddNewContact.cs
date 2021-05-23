using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class AddContact : TestBase
    {

        [Test]
        public void AddContactTest()
        {
            navigator.OpenLoginPage();
            loginout.Login(new UserAccount("admin", "secret"));
            navigator.OpenNewContactPage();
            contact.AddNewContact(new ContactData("John", "Andrew", "Barrows"));
            navigator.ReturnToHomePage();
            loginout.Logout();
        }
    }
}
