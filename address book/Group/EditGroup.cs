using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class EditGroup : TestBase
    {

        [Test]
        public void EditGroupTest()
        {
            int order = 2;
            GroupData group = new GroupData("Group Name Updated", "Group Header Updated", "Group Footer Updated");
            app.Group.Edit(order, group);
        }
    }
}
