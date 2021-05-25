using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace address_book
{
    public class GroupsHelper : HelperBase
    {
        public GroupsHelper (Application manager) : base (manager)
        {
        }

        public void Create(GroupData group)
        {
            manager.Navigator.OpenGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.LogInOut.Logout();
        }

        public void Edit(int order, GroupData group)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(order);
            InitGroupEdit();
            FillGroupForm(group);
            SubmitGroupUpdate();
            manager.Navigator.OpenHomePage();
            manager.LogInOut.Logout();
        }
        public void Delete(int order)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(order);
            InitGroupRemoval();
            manager.Navigator.OpenHomePage();
            manager.LogInOut.Logout();
        }

        public GroupsHelper InitGroupEdit()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupsHelper SelectGroup(int order)
        {
            driver.FindElement(By.XPath("(//input[@name = 'selected[]'])['" + order + "']")).Click();
            return this;
        }

        public GroupsHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupsHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }
        public GroupsHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupsHelper SubmitGroupUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public GroupsHelper InitGroupRemoval()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
    }
}
