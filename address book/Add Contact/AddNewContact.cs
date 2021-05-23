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
            app.Navigator.OpenLoginPage();
            app.LogInOut.Login(new UserAccount("admin", "secret"));
            app.Navigator.OpenNewContactPage();
            app.Contact.AddNewContact(new ContactData("John", "Andrew", "Barrows"));
            app.Navigator.ReturnToHomePage();
            app.LogInOut.Logout();
        }
    }
}
