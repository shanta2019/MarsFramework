using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;
using static NUnit.Core.NUnitFramework;

namespace MarsFramework.Pages
{
    public class ManageListing
    {
        public ManageListing()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialise web element
        //Click on the Manage Listings Button
        [FindsBy(How = How.XPath, Using = "//a[@href='/Home/ListingManagement']")]
        private IWebElement ManageListingbtn { get; set; }

        //Click on Eye Icon
        [FindsBy(How = How.XPath, Using = "//i[@class='eye icon']")]
        private IWebElement EyeIconbtn { get; set; }

        //Verify listing viewing
        [FindsBy(How = How.XPath, Using = "//div[text()='Category']")]
        private IWebElement CategoryListing { get; set; }

        //Remove listing or deactivate listing
        [FindsBy(How = How.XPath, Using = "//i[@class='remove icon']")]
        private IWebElement RemoveIcon { get; set; }

        //Title
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        private IWebElement ListingTitle { get; set; }


        #endregion

        internal void ViewListing()
        {
            //extent Reports
            Base.test = Base.extent.StartTest("View Manage Listings");

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "ManageListings");

            //Click on ManageListing tab
            ManageListingbtn.Click();
            Thread.Sleep(500);

            //Click on Eye icon
            EyeIconbtn.Click();
            Thread.Sleep(1000);

            //delete  Action 
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(RemoveIcon).Build().Perform();
            IList<IWebElement> listings = RemoveIcon.FindElements(By.XPath("//tr/td[8]/i[3]"));
            int listingCount = listings.Count;
            Console.WriteLine("Number of Listings : " + listingCount);
            for (int i = 0; i < listingCount; i++)
            {
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]/td[3]")).Text;
                Console.WriteLine("Name is : " + Name);
                if (Name.Equals(ExcelLib.ReadData(2, "Title")))
                {
                    listings.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Clicking on delete icon has been successfully performed");
                    break;
                }

            }


            ////Deactivate listings
            //Thread.Sleep(1000);
            //RemoveIcon.Click();

            //Click on Yes button
            Thread.Sleep(1000);
            Global.GlobalDefinitions.driver.SwitchTo().Alert().Accept();

            //Verify listings is deactivated
            string text1 = Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='title']")).Text;
            Assert.AreEqual(" ", ListingTitle);































        }
    }
}

