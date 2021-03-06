using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace address_book
{
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper (Application manager) : base(manager)
        {
        }
        private List<ContactData> contactsListCache = null;
        public void Create(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.OpenHomePage();
        }

        public void Edit(ContactData contact, int order)
        {
            manager.Navigator.OpenHomePage();
            OpenContact(order);
            FillContactForm(contact);
            SubmitContactUpdate();
            manager.Navigator.OpenHomePage();
        }

        public void Delete(int order)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(order);
            InitContactRemoval();
            AcceptAlert();
            manager.Navigator.OpenHomePage();
        }

        public ContactsHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactsHelper InitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactsListCache = null;
            return this;
        }
        public ContactsHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }
        public ContactsHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactsListCache = null;
            return this;
        }
        public ContactsHelper OpenContact(int order)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (order + 1) + "]")).Click();
            return this;
        }
        public ContactsHelper SubmitContactUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            contactsListCache = null;
            return this;
        }
        public ContactsHelper AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactsHelper SelectContact(int order)
        {
            driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + (order + 1) + "]")).Click();
            return this;
        }
        public void CheckContactExists()
        {
            manager.Navigator.OpenHomePage();
            if (IsElementPresent(By.XPath("//tr[2]")))
            {
                return;
            }
            ContactData contact = new ContactData("1name", "3name");
            contact.MiddleName = "2name";
            Create(contact);
        }
        public List<ContactData> GetContactsList()
        {
            if (contactsListCache == null)
            {
                contactsListCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    contactsListCache.Add(new ContactData(element.FindElement(By.XPath("td[3]")).Text, element.FindElement(By.XPath("td[2]")).Text)
                    {
                        Id = element.FindElement(By.XPath("td[1]/input")).GetAttribute("id")
                    }
                    );
                }
            }
            return new List<ContactData>(contactsListCache);
        }
        public int GetContactsCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }
    }
}
