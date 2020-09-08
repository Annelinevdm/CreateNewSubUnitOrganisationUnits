using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateNewSubUnitOrganisationUnits
{
    [TestClass]
    public class CreateNewSubUnit
    {
        IWebDriver driver = new ChromeDriver(@"C:\\Users\\Anneline\\source\\repos\\");

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://cams.azurewebsites.net/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [TestCase]
        public void Test1()
        {
            //Enter the Login details
            IWebElement UserName = driver.FindElement(By.Id("LoginInput_UserNameOrEmailAddress"));
            UserName.SendKeys("admin");
            IWebElement PassWord = driver.FindElement(By.Id("LoginInput_Password"));
            PassWord.SendKeys("1q2w3E*");
            IWebElement LoginButton2 = driver.FindElement(By.CssSelector("body > div.d-flex.align-items-center > div > div > div > div.card > div.card-body > div > form > button"));
            LoginButton2.Click();

            //Click on Administration
            IWebElement AdminiStration = driver.FindElement(By.XPath("//*[@id='mCSB_1_container']/nav/ul/li[3]/a/span[2]"));
            AdminiStration.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Click on Identity Managment Link
            IWebElement IdManageLink = driver.FindElement(By.XPath("/html/body/header/div/div[2]/div[1]/div/nav/ul/li[3]/ul/li[2]/a/span[2]"));
            IdManageLink.Click();

            //Click on Organisation Unit
            IWebElement OrgUnit = driver.FindElement(By.XPath("/html/body/header/div/div[2]/div[1]/div/nav/ul/li[3]/ul/li[2]/ul/li[1]/a/span[2]"));
            OrgUnit.Click();

            //Click on the Organisation Unit added
            Actions action2 = new Actions(driver);
            action2.MoveToElement(driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[1]/div/div/div/div/div/div[1]/ul/li[1]/a/span"))).Build().Perform();
            IWebElement ClickOnOrganisation = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[1]/div/div/div/div/div/div[1]/ul/li[1]/a/span"));
            ClickOnOrganisation.Click();

            //Click on the Arrow next to Organisation Unit added
            IWebElement OrgUnitArrow = driver.FindElement(By.XPath("/ html / body / div[2] / div[2] / div / div[1] / div / div / div / div / div / div[1] / ul / li[1] / a / span / i"));
            OrgUnitArrow.Click();

            //Add New Sub-Unit to Organisation Unit
            IWebElement OrgUnitAddSubUnit = driver.FindElement(By.XPath("/html/body/ul/li[2]/a"));
            OrgUnitAddSubUnit.Click();

            //Enter new Sub-Unit to Organisation Unit
            IWebElement EnterNewSubUnit = driver.FindElement(By.Id("OrganizationUnit_DisplayName"));
            EnterNewSubUnit.SendKeys("Sub-Unit");

            //Click on the Save button
            Actions actionUserSave = new Actions(driver);
            actionUserSave.MoveToElement(driver.FindElement(By.XPath("/html/body/div[3]/form/div/div/div/div[3]/button[2]/span"))).Build().Perform();
            IWebElement SaveUsersButton = driver.FindElement(By.XPath("/html/body/div[3]/form/div/div/div/div[3]/button[2]/span"));
            SaveUsersButton.Click();

        }
        [TearDown]
        public void Logout()
        {
            //Logout
            Actions action1 = new Actions(driver);
            action1.MoveToElement(driver.FindElement(By.Id("dropdownMenuUser"))).Build().Perform();
            IWebElement manageProfile = driver.FindElement(By.Id("MenuItem_Account.Logout"));
            manageProfile.Click();
            driver.Quit();
        }
    }
}
