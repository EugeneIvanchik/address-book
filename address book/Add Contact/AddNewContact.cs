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
            ContactData contact = new ContactData("John", "Andrew", "Barrows");
            app.Contact.InitContactCreation()
                .FillContactForm(contact)
                .SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
            app.LogInOut.Logout();
        }
    }
}
