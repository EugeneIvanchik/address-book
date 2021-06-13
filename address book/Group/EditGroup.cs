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
            GroupData group = new GroupData("thor");
            group.Header = "Group Header Updated";
            group.Footer = "Group Footer Updated";

            //define order and value of group that will be edited
            int orderBeforeEdit = 3;
            int groupValue = app.Group.GetValueByOrder(orderBeforeEdit);

            //make edit test
            app.Group.Edit(group, orderBeforeEdit);

            //get the list of groups after Edit
            newGroups = app.Group.GetGroupsList();

            //define order of group after edit using its value (that is unchangeble for every group)
            int orderAfterEdit = app.Group.FindOrderAfterEdit(groupValue);

            //remove edited group from the both lists to check that other groups remained unchanged
            oldGroups.RemoveAt(orderBeforeEdit);
            newGroups.RemoveAt(orderAfterEdit);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
