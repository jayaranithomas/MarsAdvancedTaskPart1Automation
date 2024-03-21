using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents.RenderingComponents;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileNavigationMenuComponents
{

    public class LanguageAddAndUpdateComponent : CommonDriver
    {
        int cancelFlag = 0;

        LanguageRenderingComponent languageRenderingComponent = new LanguageRenderingComponent();
        public void SetCancelFlag(int flag)
        {
            cancelFlag = flag;
        }


        public void AddLanguage(LanguageDM languageDM)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//div[@data-tab='first']//div[contains(text(),'Add New')]"));
            addNewButton.Click();

            languageRenderingComponent.RenderAddComponents();

            if (!string.IsNullOrEmpty(languageDM.language))
            {
                languageRenderingComponent.LanguageTBLocator()?.Click();
                languageRenderingComponent.LanguageTBLocator()?.SendKeys(languageDM.language);
            }
            if (!string.IsNullOrEmpty(languageDM.level))
            {
                languageRenderingComponent.LanguageLevelLocator()?.Click();
                languageRenderingComponent.LanguageLevelLocator()?.SendKeys(languageDM.level);
            }

            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {
                languageRenderingComponent.AddButtonLocator()?.Click();
            }
            else
            { cancelFlag = 0; languageRenderingComponent.CancelButtonLocator()?.Click(); }
        }

        public void EditLanguageRecord(LanguageDM languageDM)
        {
            Wait.WaitToBeClickable("XPath", "//div[@data-tab='first']//tbody[1]//i[@class='outline write icon']", 3);

            IWebElement editButton = driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[1]//i[@class='outline write icon']"));
            editButton.Click();

            languageRenderingComponent.RenderUpdateComponents();

            if (!languageDM.language.Equals("No Change"))
            {
                if (string.IsNullOrEmpty(languageDM.language))
                {
                    var actions = new OpenQA.Selenium.Interactions.Actions(driver);
                    actions.Click(languageRenderingComponent.LanguageTBLocator());
                    actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete);
                    actions.Perform();
                }
                else
                {
                    languageRenderingComponent.LanguageTBLocator()?.Clear();
                    languageRenderingComponent.LanguageTBLocator()?.SendKeys(languageDM.language);
                }
            }
            if (!languageDM.level.Equals("No Change"))
            {
                languageRenderingComponent.LanguageLevelLocator()?.Click();
                if (!string.IsNullOrEmpty(languageDM.level))
                    languageRenderingComponent.LanguageLevelLocator()?.SendKeys(languageDM.level);

                else
                    languageRenderingComponent.LanguageLevelLocator()?.SendKeys("Language Level");
                languageRenderingComponent.LanguageLevelLocator()?.Click();
            }


            Thread.Sleep(2000);

            if (cancelFlag != 1)
            {

                languageRenderingComponent.UpdateButtonLocator()?.Click();
            }
            else
            { cancelFlag = 0; languageRenderingComponent.CancelButtonLocator()?.Click(); }

        }
    }
}
