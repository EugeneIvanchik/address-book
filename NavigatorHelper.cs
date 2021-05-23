using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace address_book
{
    public class NavigatorHelper : HelperBase
    {
        public NavigatorHelper(IWebDriver driver, string baseURL)
            : base(driver)
        {
            this.baseURL = baseURL;
        }
        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void OpenNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void OpenGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}
