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
    public class Application
    {
        protected ContactsHelper contact;
        protected GroupsHelper group;
        protected LogInOutHelper loginout;
        protected NavigatorHelper navigator;
        protected IWebDriver driver;
        protected string baseURL;
        public Application()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";
            group = new GroupsHelper(this);
            contact = new ContactsHelper(this);
            loginout = new LogInOutHelper(this);
            navigator = new NavigatorHelper(this, baseURL);
        }

        public IWebDriver Driver {
            get
            {
                return driver;
            }
        }

        public ContactsHelper Contact
        {
            get
            {
                return contact;
            }
        }
        public GroupsHelper Group
        {
            get
            {
                return group;
            }
        }

        public LogInOutHelper LogInOut
        {
            get
            {
                return loginout;
            }
        }
        public NavigatorHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public void Stop()
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
