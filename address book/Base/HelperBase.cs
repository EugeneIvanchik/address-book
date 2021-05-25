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
    public class HelperBase
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected Application manager;

        public HelperBase(Application manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
    }
}