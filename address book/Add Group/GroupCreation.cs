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
            navigator.OpenLoginPage();
            loginout.Login(new UserAccount("admin", "secret"));
            navigator.OpenGroupsPage();
            group.CreateNewGroup(new FirstGroupData("Group Name", "Group Header", "Group Footer"));
            navigator.ReturnToGroupsPage();
            loginout.Logout();
        }












    }
}
