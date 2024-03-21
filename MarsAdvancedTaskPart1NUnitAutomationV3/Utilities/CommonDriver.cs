using MarsAdvancedTaskPart1NUnitAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1NUnitAutomation.ReportClass;
using MarsAdvancedTaskPart1NUnitAutomation.Test;


namespace MarsAdvancedTaskPart1NUnitAutomation.Utilities
{
    public class CommonDriver
    {

        public static IWebDriver driver;

        public static HomePage? homePageObj;
        public static LoginWindow? loginWindowObj;
        public static JSONReader jsonObj = new JSONReader();

        [SetUp]
        public static void BeforeTest()
        {

            homePageObj = new HomePage();
            loginWindowObj = new LoginWindow();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            homePageObj?.SignInAction();
            loginWindowObj?.LoginActions();
            Thread.Sleep(1000);
            BaseClass.generateReport?.CreateTest();

        }


        [TearDown]
        public static void AfterTest()
        {
            BaseClass.generateReport?.UpdateTest();
            driver?.Quit();

        }
        

    }

}
