using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class DeleteContact : AuthTestBase
    {
        List<ContactData> oldContacts = new List<ContactData>();
        List<ContactData> newContacts = new List<ContactData>();

        [Test]
        public void DeleteContactTest()
        {
            app.Contact.CheckContactExists();

            oldContacts = app.Contact.GetContactsList();

            int order = 0;
            ContactData contactToBeDeleted = oldContacts[order];
            app.Contact.Delete(order);

            newContacts = app.Contact.GetContactsList();

            oldContacts.RemoveAt(order);

            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, contactToBeDeleted.Id);
            }
        }
    }
}
