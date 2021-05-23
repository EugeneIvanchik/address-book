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
            app.Navigator.OpenLoginPage();
            app.LogInOut.Login(new UserAccount("admin", "secret"));
            app.Navigator.OpenGroupsPage();
            app.Group.CreateNewGroup(new FirstGroupData("Group Name", "Group Header", "Group Footer"));
            app.Navigator.ReturnToGroupsPage();
            app.LogInOut.Logout();
        }












    }
}
