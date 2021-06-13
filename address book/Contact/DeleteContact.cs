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
        List<ContactData> oldGroups = new List<ContactData>();
        List<ContactData> newGroups = new List<ContactData>();

        [Test]
        public void DeleteContactTest()
        {
            app.Contact.CheckContactExists();

            oldGroups = app.Contact.GetContactsList();

            int order = 0;
            app.Contact.Delete(order);

            newGroups = app.Contact.GetContactsList();

            oldGroups.RemoveAt(order);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
