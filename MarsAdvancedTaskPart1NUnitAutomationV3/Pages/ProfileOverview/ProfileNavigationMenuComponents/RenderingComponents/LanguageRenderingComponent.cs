using OpenQA.Selenium;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents
{

    public class LanguageRenderingComponent : CommonDriver
    {
        IWebElement? languageTextBox;
        IWebElement? chooseLevelDD;

        IWebElement? addButton;
        IWebElement? updateButton;
        IWebElement? cancelButton;
        public void RenderAddComponents()
        {
            try
            {
                languageTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public IWebElement LanguageTBLocator()
        {
            
            return languageTextBox!;
        }
        public IWebElement LanguageLevelLocator()
        {

            return chooseLevelDD!;
        }
        public IWebElement AddButtonLocator()
        {

            return addButton!;
        }
        public IWebElement CancelButtonLocator()
        {

            return cancelButton!;
        }
        public IWebElement UpdateButtonLocator()
        {

            return updateButton!;
        }

        public void RenderUpdateComponents()
        {
            try
            {
                languageTextBox = driver.FindElement(By.Name("name"));
                chooseLevelDD = driver.FindElement(By.Name("level"));

                updateButton = driver.FindElement(By.XPath("//div[@data-tab='first']//input[@value='Update']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        
    }
}