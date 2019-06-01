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

namespace MarsFramework.Pages
{
    public class ShareSkill
    {

        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);


        }

        #region Initialize Elements

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Share Skill')]")]
        public IWebElement ShareSkills { get; set; }


        // Title
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        public IWebElement Title { get; set; }


        // Description

        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement Description { get; set; }

        // Select Category

        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId']")]
        public IWebElement Category { get; set; }

        // Select Programming & Tech

        [FindsBy(How = How.XPath, Using = "//option[@value='6']")]
        public IWebElement ProgrammingandTech { get; set; }


        //Click on  SubCategory button
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId' and @class='ui fluid dropdown']")]
        public IWebElement SubCategory { get; set; }

        //Select SubCategory  QA
        [FindsBy(How = How.XPath, Using = "//option[@value='4']")]
        public IWebElement QA { get; set; }


        //Select Tag Names
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]

        public IWebElement Tags { get; set; }

        //Select Service Type -Hourly Basis
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='0']")]
        public IWebElement ServiceTypeHourly { get; set; }

        //Select Service Type -One-off
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='1']")]
        public IWebElement ServiceTypeOneOff { get; set; }

        //Select Location Type - Onsite
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='0']")]
        public IWebElement LocationTypeOnsite { get; set; }

        //Select Location Type - Online
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='1']")]
        public IWebElement LocationTypeOnline { get; set; }

        //Avilable Days -Start Date
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")]
        public IWebElement StartDate { get; set; }

        //Avilable Days -End Date
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")]
        public IWebElement EndDate { get; set; }

        //Select the day
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(7) > div.twelve.wide.column > div > div:nth-child(2) > div.two.wide.field > div > input[type=checkbox]")]
        public IWebElement selectDays { get; set; }

        //Start Time
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime']")]
        public IWebElement StartTime { get; set; }

        //End Time
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime']")]
        public IWebElement EndTime { get; set; }

        //Skill Trade - Skill Exchange
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @tabindex='0' and @value='true']")]
        public IWebElement SkillExchange { get; set; }

        // Skill Exchange - Required Skills for trading
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(8) > div:nth-child(4) > div.field.error > div > div > div > div")]
        public IWebElement RequiredSkills { get; set; }

        //Skill Trade - Credit
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(8) > div.twelve.wide.column > div > div:nth-child(2) > div > input[type=radio]")]
        public IWebElement Credit { get; set; }


        //Credit - Enter Amount
        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        public IWebElement CreditAmount { get; set; }

        // Status Active 
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(10) > div.twelve.wide.column > div > div:nth-child(1) > div > input[type=radio]")]
        public IWebElement StatusActive { get; set; }

        // Status Hidden 
        [FindsBy(How = How.XPath, Using = "//div[@class='inline fields']//input[@name='isActive' and @tabindex='0' and @value='false']")]
        public IWebElement StatusHidden { get; set; }


        // Save Share Skills
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement SaveShareSkills { get; set; }

        // Cancel Share Skills
        [FindsBy(How = How.XPath, Using = "//input[@value='Cancel']")]
        public IWebElement CancelShareSkills { get; set; }

        #endregion

        #region Add new Skill
        public void AddNewShareSkill()
        {

            #region Navigate to Share Skills Page

            // Click on Share Skills Page
            ShareSkills.Click();
            Thread.Sleep(1000);

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            // Enter Title
            Title.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Base.test.Log(LogStatus.Info, "Title has been successfully entered");

            //Enter description
            Description.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Base.test.Log(LogStatus.Info, "Description has been successfully entered");

            //click on category dropdown menu
            Thread.Sleep(500);
            Category.Click();
            Thread.Sleep(1000);


            //Select the category
            ProgrammingandTech.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            Thread.Sleep(1000);


            //Click on subcatogory drop down option 
            Thread.Sleep(1000);
            SubCategory.Click();

            //Select the Sub-Category option
            SubCategory.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"));
            SubCategory.SendKeys(Keys.Enter);
            Base.test.Log(LogStatus.Info, "SubCategory has been successfully entered");
            QA.Click();


            //Enter Tags
            Tags.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Base.test.Log(LogStatus.Info, "TagName has been successfully entered");

            //Select service type
            //ServiceTypeHourly.Click();

            if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "Hourly basis service")
            {
                ServiceTypeHourly.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "One-off service")
            {
                ServiceTypeOneOff.Click();
            }

            //Select Location Type
            //LocationTypeOnline.Click();
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "Online")
            {
                LocationTypeOnline.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "On-site")
            {
                LocationTypeOnsite.Click();
            }



            //Click the start date
            StartDate.Click();
            Thread.Sleep(500);

            //Select the date
            Thread.Sleep(500);
            StartDate.SendKeys(Keys.Backspace);
            StartDate.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Start Date"));

            //Select the end Date
            Thread.Sleep(1000);
            EndDate.SendKeys(Keys.Backspace);
            EndDate.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "End Date"));

            //Select the Days available
            selectDays.Click();
            Thread.Sleep(500);

            //Select starttime
            Thread.Sleep(1000);
            StartTime.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Start Time"));

            //Select EndTime
            Thread.Sleep(1000);
            EndTime.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "End Time"));

            //Select Skill Trade
            Credit.Click();
            Thread.Sleep(500);
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade") == "Skill-exchange")
            {

                RequiredSkills.Click();
                RequiredSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade"));
                RequiredSkills.SendKeys(Keys.Enter);

            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade") == "Credit")
            {

                CreditAmount.Click();
                CreditAmount.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Credit Amount"));
                CreditAmount.SendKeys(Keys.Enter);

                //Enter credit amount
                // CreditAmount.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Credit Amount"));

                //Select the stats
                // StatusActive.Click();
                //Thread.Sleep(500);
                if (GlobalDefinitions.ExcelLib.ReadData(2, "Status") == "Active")
                {
                    StatusActive.Click();
                }
                else if (GlobalDefinitions.ExcelLib.ReadData(2, "Status") == "Hidden")
                {
                    StatusHidden.Click();
                }

                //Save the Share Skill
                Thread.Sleep(500);
                SaveShareSkills.Click();
                Thread.Sleep(500);


                //Verify if newShared skill is saved
                Thread.Sleep(3000);
                string ShareSkillSucess = Global.GlobalDefinitions.driver.FindElement(By.CssSelector("#listing-management-section > div:nth-child(3) > div:nth-child(2) > table > thead > tr > th:nth-child(1)")).Text;

                if (ShareSkillSucess == "Image")
                {
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Saved Skill Successful");
                }
                else
                    Global.Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Saving Skill Unsuccessful");
            }





        }
        #endregion
    }
}
#endregion


























































