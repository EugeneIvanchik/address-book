using System;
using System.Collections.Generic;
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
            manager.Navigator.OpenGroupsPage();
        }
        public void Edit(GroupData group, int order)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(order);
            InitGroupEdit();
            FillGroupForm(group);
            SubmitGroupUpdate();
            manager.Navigator.OpenGroupsPage();
        }
        public void Delete(int order)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(order);
            InitGroupRemoval();
            manager.Navigator.OpenGroupsPage();
        }

        public GroupsHelper InitGroupEdit()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupsHelper SelectGroup(int order)
        {
            driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + (order + 1) + "]")).Click();
            return this;
        }

        public GroupsHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupsHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
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
        public void CheckGroupExists()
        {
            manager.Navigator.OpenGroupsPage();
            if (IsElementPresent(By.XPath("//span[@class='group']")))
            {
                return;
            }
            GroupData updatedGroup = new GroupData("basic name");
            updatedGroup.Header = "basic header";
            updatedGroup.Footer = "basic footer";
            Create(new GroupData("basic name")); ;
        }
        public List<GroupData> GetGroupsList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.OpenGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text)
                {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }
            return groups;
        }
    }
}
