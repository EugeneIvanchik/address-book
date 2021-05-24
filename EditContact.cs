using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class EditContact : TestBase
    {

        [Test]
        public void EditContactTest()
        {
            int order = 2;
            ContactData contact = new ContactData("Pete", "John", "Sparrow");
            app.Contact.Edit(order, contact);
        }
    }
}
