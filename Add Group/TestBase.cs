using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace address_book
{
    public class TestBase
    {
        public IWebDriver driver;
        public string baseURL;
        public ContactsHelper contact;
        public GroupsHelper group;
        public LogInOutHelper loginout;
        public NavigatorHelper navigator;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";

            group = new GroupsHelper(driver);
            contact = new ContactsHelper(driver);
            loginout = new LogInOutHelper(driver);
            navigator = new NavigatorHelper(driver, baseURL);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}