using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages
{
    public class HomePage : CommonDriver
    {
        public void SignInAction()
        {
            //navigate to the Mars portal login page
            driver.Navigate().GoToUrl("http://localhost:5000/Home");

            Wait.WaitToBeVisible("XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 7);

            IWebElement SignInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            SignInButton.Click();

        }
    }
}
