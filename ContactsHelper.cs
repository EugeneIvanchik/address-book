using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        public void Create(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.OpenHomePage();
            manager.LogInOut.Logout();
        }

        public void Edit(int order, ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            OpenContact(order);
            FillContactForm(contact);
            SubmitContactUpdate();
            manager.Navigator.OpenHomePage();
            manager.LogInOut.Logout();
        }
        public void Delete(int order)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(order);
            InitContactRemoval();
            AcceptAlert();
            manager.Navigator.OpenHomePage();
            manager.LogInOut.Logout();
        }

        public ContactsHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactsHelper InitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactsHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }
        public ContactsHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactsHelper OpenContact(int order)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])['" + order + "']")).Click();
            return this;
        }
        public ContactsHelper SubmitContactUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public ContactsHelper AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactsHelper SelectContact(int order)
        {
            driver.FindElement(By.XPath("(//input[@name = 'selected[]'])['" + order + "']")).Click();
            return this;
        }
    }
}
