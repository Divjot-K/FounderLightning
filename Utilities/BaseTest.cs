using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace FounderLightning.Utilities
{
    public class BaseTest
        {
            public static IWebDriver driver; // marked as public and static so it can be used by other classes
            public static WebDriverWait wait;

           [SetUp]
            public void Setup()
            {

                driver = new ChromeDriver();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                driver.Navigate().GoToUrl("https://www.founderandlightning.com/");
                driver.Manage().Window.Maximize();

            }

            [TearDown]
            public void Dispose()
            {
                driver.Quit();
                driver.Dispose();
            }


        }
    }

