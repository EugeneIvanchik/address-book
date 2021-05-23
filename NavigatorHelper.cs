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
            driver.Navigate().GoToUrl(baseURL);
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void OpenGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
