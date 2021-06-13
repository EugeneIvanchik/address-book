using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace address_book
{
    public class NavigatorHelper : HelperBase
    {
        public NavigatorHelper(Application manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenLoginPage()
        {
            if (IsElementPresent(By.Name("LoginForm")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void OpenGroupsPage()
        {
            if(IsElementPresent(By.XPath("//*[@value='New group']")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        internal void OpenHomePage()
        {
            if (IsElementPresent(By.XPath("//*[@value='Add to']")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
