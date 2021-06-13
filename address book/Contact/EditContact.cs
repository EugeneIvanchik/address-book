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
        ContactData contactAfterEdit;
        int orderBeforeEdit;
        int orderAfterEdit;
        int contactId;
        [Test]
        public void EditContactTest()
        {
            //check if at least one contact exists. create one if there are no contacts
            app.Contact.CheckContactExists();

            //get the list of contacts before Edit
            oldContacts = app.Contact.GetContactsList();

            //create test data
            contactAfterEdit = new ContactData("Pete", "Peterson");

            //define order and id of contact that will be edited
            orderBeforeEdit = 0;
            contactId = app.Contact.GetIdByOrder(orderBeforeEdit);

            //make edit test
            app.Contact.Edit(contactAfterEdit, orderBeforeEdit);

            //get the list of contacts after Edit
            newContacts = app.Contact.GetContactsList();

            //define order of contact after edit using its id (that is unchangeble for every contact)
            orderAfterEdit = app.Contact.FindOrderAfterEdit(contactId);

            //remove edited contact from the both lists to check that other contacts remained unchanged
            oldContacts.RemoveAt(orderBeforeEdit);
            newContacts.RemoveAt(orderAfterEdit);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
