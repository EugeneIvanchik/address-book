using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class DeleteGroup : TestBase
    {

        [Test]
        public void DeleteGroupTest()
        {
            int order = 1;
            app.Group.Delete(order);
        }
    }
}
