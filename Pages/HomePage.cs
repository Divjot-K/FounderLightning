using FounderLightning.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FounderLightning.Pages
{
    public class HomePage : BaseTest
    {
        By lnk_contact = By.XPath("//a[contains(text(),'Say Hello')]");

        public ContactUs NavigateToContact()
        {
            driver.FindElement(lnk_contact).Click();
            return new ContactUs();
        }
    }
}
