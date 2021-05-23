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
        public Application app;

        [SetUp]
        public void SetupTest()
        {
            app = new Application();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}