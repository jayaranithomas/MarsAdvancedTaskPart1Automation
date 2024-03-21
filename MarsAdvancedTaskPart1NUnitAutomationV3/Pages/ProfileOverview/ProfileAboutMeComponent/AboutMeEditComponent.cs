using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.ProfileOverview.ProfileAboutMeComponent
{
    public class AboutMeEditComponent : CommonDriver
    {
        AboutMeRenderingComponent aboutMeRendering = new AboutMeRenderingComponent();

        public void EditAvailabilityProfile(string option, int flag)
        {
            aboutMeRendering.RenderAvailabilityComponents();

            if (flag == 0)
            {
                Thread.Sleep(1000);

                aboutMeRendering.OptionLocator()?.SendKeys(option);
            }
            else
            {
                Thread.Sleep(2000);
                aboutMeRendering.RemoveIconLocator()?.Click();
            }
        }
        public void EditHoursProfile(string option, int flag)
        {
            aboutMeRendering.RenderHourComponents();

            if (flag == 0)
            {
                Thread.Sleep(1000);

                aboutMeRendering.OptionLocator()?.SendKeys(option);
            }
            else
            {
                Thread.Sleep(2000);
                aboutMeRendering.RemoveIconLocator()?.Click();
            }

        }
        public void EditTargetProfile(string option, int flag)
        {
            aboutMeRendering.RenderTargetComponents();

            if (flag == 0)
            {
                Thread.Sleep(1000);

                aboutMeRendering.OptionLocator()?.SendKeys(option);
            }
            else
            {
                Thread.Sleep(2000);
                aboutMeRendering.RemoveIconLocator()?.Click();
            }

        }
    }
}
