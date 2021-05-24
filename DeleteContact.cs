using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class DeleteContact : TestBase
    {

        [Test]
        public void DeleteContactTest()
        {
            int order = 1;
            app.Contact.Delete(order);
        }
    }
}
