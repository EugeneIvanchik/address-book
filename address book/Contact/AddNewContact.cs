using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class AddContact : AuthTestBase
    {
        List<ContactData> oldGroups = new List<ContactData>();
        List<ContactData> newGroups = new List<ContactData>();

        [Test]
        public void AddContactTest()
        {
            ContactData contact = new ContactData("John", "Swanson");
            contact.MiddleName = "Middlesboroughov";

            oldGroups =  app.Contact.GetContactsList();

            app.Contact.Create(contact);

            newGroups = app.Contact.GetContactsList();

            oldGroups.Add(contact);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(newGroups, oldGroups);
        }
    }
}
