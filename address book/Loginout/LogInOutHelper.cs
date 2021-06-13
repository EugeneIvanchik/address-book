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
    public class LogInOutHelper : HelperBase
    {
        public LogInOutHelper(Application manager) : base(manager)
        {
        }

        public void Login(UserAccount userAccount)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(userAccount))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), userAccount.Username);
            Type(By.Name("pass"), userAccount.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(UserAccount account)
        {
            return 
            IsLoggedIn() 
            && 
            driver.FindElement(By.TagName("b")).Text == "(" + account.Username + ")";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void Logout()
        {
            if (IsElementPresent(By.Name("logout")))
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}
