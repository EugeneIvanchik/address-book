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
        List<ContactData> oldContacts = new List<ContactData>();
        List<ContactData> newContacts = new List<ContactData>();

        [Test]
        public void AddContactTest()
        {
            ContactData contact = new ContactData("John", "Swanson");
            contact.MiddleName = "Middlesboroughov";

            oldContacts =  app.Contact.GetContactsList();

            app.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactsCount());

            newContacts = app.Contact.GetContactsList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(newContacts, oldContacts);
        }
    }
}
