using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace address_book
{
    [TestFixture]
    public class EditGroup : AuthTestBase
    {
        List<GroupData> oldGroups = new List<GroupData>();
        List<GroupData> newGroups = new List<GroupData>();


        [Test]
        public void EditGroupTest()
        {
            //check if at least one group exists. create one if there are no groups
            app.Group.CheckGroupExists();

            //get the list of groups before Edit
            oldGroups = app.Group.GetGroupsList();

            //create test data
            GroupData newGroupData = new GroupData("tree");
            newGroupData.Header = "Group Header Updated";
            newGroupData.Footer = "Group Footer Updated";

            //define order of group that will be edited
            int order = 0;

            //remember group that will be changed
            GroupData groupToBeChanged = oldGroups[order];

            //make edit test
            app.Group.Edit(newGroupData, order);

            //before lists comparison be sure that their counts are equal
            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupsCount());

            //get the list of groups after Edit
            newGroups = app.Group.GetGroupsList();

            //edit group using List methods but not browser and compare then
            oldGroups[order].Name = newGroupData.Name;
            oldGroups[order].Header = newGroupData.Header;
            oldGroups[order].Footer = newGroupData.Footer;

            //sort both lists and check they are equal
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            //be sure that exactly needed group was changed
            foreach (GroupData group in newGroups)
            {
                if(group.Id == groupToBeChanged.Id)
                {
                    Assert.AreEqual(newGroupData.Name, group.Name);
                }
            }
        }
    }
}
