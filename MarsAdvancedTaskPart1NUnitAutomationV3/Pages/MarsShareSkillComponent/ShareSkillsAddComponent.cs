using AventStack.ExtentReports.Model;
using MarsAdvancedTaskPart1NUnitAutomation.DataModel;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsShareSkillComponent
{
    public class ShareSkillsAddComponent : CommonDriver
    {
        string titleText = string.Empty;
        string descriptionText = string.Empty;
        int cancelFlag = 0;
        ShareSkillRenderingComponent shareSkillRenderingComponent = new ShareSkillRenderingComponent();
        public string GetTitle()
        {
            return titleText;
        }
        public string GetDescription()
        {
            return descriptionText;
        }
        public void SetCancelFlag(int flag)
        {
            this.cancelFlag = flag;
        }
        public void AddShareSkills(ShareSkillsDM shareSkillsDM)
        {
            shareSkillRenderingComponent.RenderShareSkillComponents();

            if (!string.IsNullOrEmpty(shareSkillsDM.title))
                shareSkillRenderingComponent.TitleLocator()?.SendKeys(shareSkillsDM.title);

            if (!string.IsNullOrEmpty(shareSkillsDM.description))
                shareSkillRenderingComponent.DescriptionLocator()?.SendKeys(shareSkillsDM.description);

            if (!string.IsNullOrEmpty(shareSkillsDM.category))
            {
                shareSkillRenderingComponent.CategoryLocator()?.SendKeys(shareSkillsDM.category);
                shareSkillRenderingComponent.RenderSubcategoryComponent();
                if (!string.IsNullOrEmpty(shareSkillsDM.subcategory))
                    shareSkillRenderingComponent.SubCategoryLocator()?.SendKeys(shareSkillsDM.subcategory);
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.tag))
            {
                shareSkillRenderingComponent.TagLocator(0).SendKeys(shareSkillsDM.tag);
                shareSkillRenderingComponent.TagLocator(0).SendKeys(Keys.Enter);
            }

            if (shareSkillsDM.servicetype.Equals("1"))
            {
                shareSkillRenderingComponent.ServiceType1Locator()?.Click();
            }
            else if (shareSkillsDM.servicetype.Equals("0"))
            {
                shareSkillRenderingComponent.ServiceType0Locator()?.Click();
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.locationtype))
            {
                shareSkillRenderingComponent.LocationTypeLocator()?.SendKeys(shareSkillsDM.locationtype);
                shareSkillRenderingComponent.LocationTypeLocator()?.Click();
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.startdate))
            {
                shareSkillRenderingComponent.StartDateLocator()?.SendKeys(shareSkillsDM.startdate);
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.enddate))
                shareSkillRenderingComponent.EndDateLocator()?.SendKeys(shareSkillsDM.enddate);

            if (shareSkillsDM.skilltrade.Equals("true"))
            {
                shareSkillRenderingComponent.SkillTradeTLocator()?.Click();
                shareSkillRenderingComponent.TagLocator(1).SendKeys(shareSkillsDM.skillexchange);
                shareSkillRenderingComponent.TagLocator(1).SendKeys(Keys.Enter);
            }
            else
            {
                shareSkillRenderingComponent.SkillTradeFLocator()?.Click();
                shareSkillRenderingComponent.RenderCreditComponent();
                shareSkillRenderingComponent.CreditLocator()?.SendKeys(shareSkillsDM.credit);
            }

            if (!string.IsNullOrEmpty(shareSkillsDM.worksamples))
            {
                string filePath = @"F:\sample1.txt";
                shareSkillRenderingComponent.WorkSamplesLocator()?.Click();
                shareSkillRenderingComponent.WorkSamplesLocator()?.SendKeys(filePath);
            }

            if (shareSkillsDM.active.Equals("true"))
            {
                shareSkillRenderingComponent.ActiveTLocator()?.Click();
            }
            else if (shareSkillsDM.active.Equals("false"))
            {
                shareSkillRenderingComponent.ActiveFLocator()?.Click();
            }

            if (!string.IsNullOrEmpty(shareSkillRenderingComponent.TitleLocator()?.GetAttribute("value")))
                titleText = shareSkillRenderingComponent.TitleLocator().GetAttribute("value");

            if (!string.IsNullOrEmpty(shareSkillRenderingComponent.DescriptionLocator()?.Text))
                descriptionText = shareSkillRenderingComponent.DescriptionLocator().Text;

            if (cancelFlag == 0)
                shareSkillRenderingComponent.SaveButtonLocator()?.Click();
            else
            {
                cancelFlag = 0;
                shareSkillRenderingComponent.CancelButtonLocator()?.Click();
            }
        }
    }
}
