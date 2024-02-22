using MarsAdvancedTaskPart1NUnitAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Utilities
{
    [SetUpFixture]
    public class CommonDriver
    {

        public static IWebDriver driver;

        HomePage homeObj;
        LoginWindow loginObj;


        [SetUp]
        public void BeforeTest()
        {

            homeObj = new HomePage();
            loginObj = new LoginWindow();
            Initialize();
            homeObj.SignInAction();
            loginObj.LoginActions();

            Thread.Sleep(1000);
        }

        public void Initialize()
        {
            //Opening the Chrome driver
            driver = new ChromeDriver();

            //Maximizing the Window
            driver.Manage().Window.Maximize();
        }
        public void Close()
        {
            driver.Quit();
        }


    }

}
