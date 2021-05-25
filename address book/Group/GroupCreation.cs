using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class GroupCreation : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Group Name", "Group Header", "Group Footer");
            app.Group.Create(group);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");
            app.Group.Create(group);
        }












    }
}
