using FounderLightning.Utilities;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FounderLightning.Pages
{
    public class ContactUs : BaseTest
    {
        //Fields in Contact Us Page
        By txtFirstName = By.Name("firstname");       
        By txtLastName = By.Name("lastname");
        By txtEmail = By.Name("email");
        By txtPhone = By.Name("mobilephone");
        By ddHearAbout = By.Name("how_did_you_hear_about_us_");
        By txtMessage = By.Name("message");
        By btnSubmit = By.XPath("//input[@type ='submit']");
        By msgSuccessful = By.XPath("//div[@class='hbspt-form']/div/p");


        //Required Error message elements
        By lblReqFn = By.XPath("//input[@name='firstname']/parent::div/following-sibling::ul//label[contains(text(),'Please complete this required field.')]");
        By lblReqLn = By.XPath("//input[@name='lastname']/parent::div/following-sibling::ul//label[contains(text(),'Please complete this required field.')]");
        By lblReqEmail = By.XPath("//input[@name='email']/parent::div/following-sibling::ul//label[contains(text(),'Please complete this required field.')]");
        By lblReqMobileNo = By.XPath("//input[@name='mobilephone']/parent::div/following-sibling::ul//label[contains(text(),'Please complete this required field.')]");
        By lblReqMessage = By.XPath("//textarea[@name='message']/parent::div/following-sibling::ul//label[contains(text(),'Please complete this required field.')]");

        //InValid Error message
        By lblInvalidEmail = By.XPath("//input[@name='email']//parent::div/following-sibling::ul//label[contains(text(),'Email must be formatted correctly.')]");

        public void FillContactUs(string fn=null, string ln=null, string email=null, string phnum=null,
            string msg=null, string ddhearUs_value = null)
        {
            wait.Until(condition => driver.FindElement(txtFirstName).Displayed == true);
            if(fn!=null)
                driver.FindElement(txtFirstName).SendKeys(fn);
            if (ln != null)
                driver.FindElement(txtLastName).SendKeys(ln);
            if (email != null)
                driver.FindElement(txtEmail).SendKeys(email);
            if (phnum != null)
                driver.FindElement(txtPhone).SendKeys(phnum);
            if (msg != null)
                driver.FindElement(txtMessage).SendKeys(msg);
            if (ddhearUs_value != null)
            {
                SelectElement select = new SelectElement(driver.FindElement(ddHearAbout));
                select.SelectByValue(ddhearUs_value);
            }
        }

        public void SubmitForm()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement submit = driver.FindElement(btnSubmit);
            js.ExecuteScript("arguments[0].click();", submit);
        }

        public bool VerifyFormSubmitted()
        {
            bool status = false; 
            wait.Until(condition =>
            {
                try
                {
                    string msg = driver.FindElement(msgSuccessful).Text.ToString();
                    if (msg.Equals("Thank you for your message. We'll get back to you as soon as possible."))
                        status = true;                        
                    else
                        status = false;
                    return status;
                }
                catch(Exception ex)
                {
                    return false;
                }
            });
            return status;
        }

        public bool VerifyRequiredFirstName()
        {
            return driver.FindElement(lblReqFn).Displayed;
        }
        public bool VerifyRequiredLastName()
        {
            return driver.FindElement(lblReqLn).Displayed;
        }
        public bool VerifyRequiredEmail()
        {
            return driver.FindElement(lblReqEmail).Displayed;
        }
        public bool VerifyRequiredPhone()
        {
            return driver.FindElement(lblReqMobileNo).Displayed;
        }
        public bool VerifyRequiredMessage()
        {
            return driver.FindElement(lblReqMessage).Displayed;
        }

        public bool VerifyValidEmailAddress()
        {
            string email = driver.FindElement(txtEmail).Text.ToString();
            Regex regex = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$",
                RegexOptions.IgnoreCase);
            bool isValidEmail = regex.IsMatch(email);
            if (isValidEmail)
                return true;
            else
                return false;
           
        }

    }
}
