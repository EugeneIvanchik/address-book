using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class EditContact : AuthTestBase
    {
        List<ContactData> oldContacts = new List<ContactData>();
        List<ContactData> newContacts = new List<ContactData>();
        [Test]
        public void EditContactTest()
        {
            //check if at least one contact exists. create one if there are no contacts
            app.Contact.CheckContactExists();

            //get the list of contacts before Edit
            oldContacts = app.Contact.GetContactsList();

            //create test data
            ContactData newContactData = new ContactData("Frank", "Richardson");

            //define order of contact that will be edited
            int order = 0;

            //remember contact that will be changed
            ContactData contactToBeChanged = oldContacts[order];

            //make edit test
            app.Contact.Edit(newContactData, order);

            //before lists comparison be sure that their counts are equal
            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactsCount());

            //get the list of contacts after Edit
            newContacts = app.Contact.GetContactsList();

            //edit contact in old list using List method instead of browser
            oldContacts[order].FirstName = newContactData.FirstName;
            oldContacts[order].LastName = newContactData.LastName;

            //check both lists are equal
            Assert.AreEqual(oldContacts, newContacts);

            //check that exactly needed contact was changed
            foreach(ContactData contact in newContacts)
            {
                if(contact.Id == contactToBeChanged.Id)
                {
                    Assert.AreEqual(contact.FirstName + contact.LastName, contactToBeChanged.FirstName + contactToBeChanged.LastName);
                }
            }
        }
    }
}
