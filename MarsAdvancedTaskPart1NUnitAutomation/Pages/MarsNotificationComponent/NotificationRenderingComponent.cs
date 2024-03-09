using MarsAdvancedTaskPart1NUnitAutomation.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.Pages.MarsNotificationComponent
{
    public class NotificationRenderingComponent : CommonDriver
    {
        IWebElement? showLessButton;
        IWebElement? loadMoreButton;
        IWebElement? selectAllButton;
        IWebElement? unselectAllButton;
        IWebElement? markAsReadButton;
        IWebElement? firstNotificationCheckBox;
        IWebElement? deleteButton;
        public void RenderLoadMoreButton()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@class='ui button'][contains(text(),'Load More...')]", 20);
                loadMoreButton = driver.FindElement(By.XPath("//a[@class='ui button'][contains(text(),'Load More...')]"));
                loadMoreButton?.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RenderShowLessButton()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//a[@class='ui button'][contains(text(),'...Show Less')]", 20);
                showLessButton = driver.FindElement(By.XPath("//a[@class='ui button'][contains(text(),'...Show Less')]"));
                showLessButton?.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RenderSelectAllButton()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@class='ui items segment']//div[@class='content']/a/div[@class='content']", 20);
                selectAllButton = driver.FindElement(By.XPath(" //i[@class='mouse pointer icon']"));
                selectAllButton?.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RenderUnSelectAllButton()
        {
            RenderSelectAllButton();
            Thread.Sleep(2000);
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@class='ui items segment']//div[@class='content']/a/div[@class='content']", 20);
                unselectAllButton = driver.FindElement(By.XPath("//i[@class='ban icon']"));
                unselectAllButton?.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RenderMarkAsReadComponent()
        {
            RenderSelectAllButton();
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@class='ui items segment']//div[@class='content']/a/div[@class='content']", 20);
                markAsReadButton = driver.FindElement(By.XPath("//i[@class='check square icon']"));
                markAsReadButton?.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RenderSelectFirstComponent()
        {
            try
            {
                Wait.WaitToBeVisible("XPath", "//div[@class='ui items segment']//div[@class='content']/a/div[@class='content']", 20);
                firstNotificationCheckBox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
                firstNotificationCheckBox?.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RenderDeleteComponent()
        {
            try
            {

                Wait.WaitToBeVisible("XPath", "//div[@data-tooltip='Delete selection']", 20);
                deleteButton = driver.FindElement(By.XPath("//div[@data-tooltip='Delete selection']"));
                deleteButton?.Click();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
