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

            int order = 1;
            GroupData groupToBeDeleted = oldGroups[order];

            app.Group.Delete(order);

            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupsCount());

            newGroups = app.Group.GetGroupsList();

            oldGroups.RemoveAt(order);

            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, groupToBeDeleted.Id);
            }
        }
    }
}
