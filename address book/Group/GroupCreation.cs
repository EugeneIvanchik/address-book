using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class GroupCreation : AuthTestBase
    {
        List<GroupData> oldGroups = new List<GroupData>();
        List<GroupData> newGroups = new List<GroupData>();
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Group Name");
            group.Header = "Group Header";
            group.Footer = "Group Footer";

            oldGroups = app.Group.GetGroupsList();

            app.Group.Create(group);
            newGroups = app.Group.GetGroupsList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            oldGroups = app.Group.GetGroupsList();

            app.Group.Create(group);
            newGroups = app.Group.GetGroupsList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
