using FounderLightning.Pages;
using FounderLightning.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FounderLightning.Tests
{
    public class Test_ContactUs : BaseTest
    {
        [Test]
        public void VerifyContact_ValidData()
        {
            string fname = "Divjot";
            string lname = "Kaur";
            string email = "text@check.com";
            string num = "9987892121";
            string message = @"I am having the idea related to food industry. 
                            Please let me know how can I proceed on same in finding investors and 
                            implementation of same with Founder and Lightning.";
            string hearfrom = "Article";
            HomePage homePage = new HomePage();
            ContactUs contact = homePage.NavigateToContact();
            contact.FillContactUs(fname, lname, email, num, message, hearfrom);
            contact.SubmitForm();
            bool formStatus = contact.VerifyFormSubmitted();
            if (formStatus)
                Assert.Pass("Form submitted successfully");
            else
                Assert.Fail("Form is not submitted");
        }

        [Test]
        public void VerifyContact_RequiredData()
        {
            HomePage homePage = new HomePage();
            ContactUs contact = homePage.NavigateToContact();
            contact.SubmitForm();
            Assert.IsTrue(contact.VerifyRequiredFirstName());
            Assert.IsTrue(contact.VerifyRequiredLastName());
            Assert.IsTrue(contact.VerifyRequiredEmail());
            Assert.IsTrue(contact.VerifyRequiredPhone());
            Assert.IsTrue(contact.VerifyRequiredMessage());
        }

        [Test]
        public void VerifyCorrectEmailMessage()
        {
            string invalidemail = "Abc@text";
            HomePage homePage = new HomePage();
            ContactUs contact = homePage.NavigateToContact();
            contact.FillContactUs(email: invalidemail);
            contact.SubmitForm();
            bool emailStatus = contact.VerifyValidEmailAddress();
            if (!emailStatus)
                Assert.Pass("Test case is executed succesfully for invalid email address");
        }

        [Test]
        public void VerifyMobileNumberIsNumeric()
        {
            string num = "AXCD";
            HomePage homePage = new HomePage();
            ContactUs contact = homePage.NavigateToContact();
            contact.FillContactUs(phnum: num);
            contact.SubmitForm();
            bool mobileStatus = contact.VerifyMobileNumberIsNumeric();
            if (!mobileStatus)
                Assert.Pass("Test case is executed succesfully for invalid phone number");
        }
    }
}
