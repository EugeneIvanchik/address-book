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
            FirstGroupData group = new FirstGroupData("Group Name", "Group Header", "Group Footer");
            app.Navigator.OpenGroupsPage();
            app.Group.InitGroupCreation()
                .CreateNewGroup(group)
                .SubmitGroupCreation();
            app.LogInOut.Logout();
        }












    }
}
