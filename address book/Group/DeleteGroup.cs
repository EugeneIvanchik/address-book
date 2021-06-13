using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace address_book
{
    [TestFixture]
    public class DeleteGroup : AuthTestBase
    {
        List<GroupData> oldGroups = new List<GroupData>();
        List<GroupData> newGroups = new List<GroupData>();

        [Test]
        public void DeleteGroupTest()
        {
            app.Group.CheckGroupExists();

            oldGroups = app.Group.GetGroupsList();

            int order = 3;
            app.Group.Delete(order);

            newGroups = app.Group.GetGroupsList();
            oldGroups.RemoveAt(order);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
