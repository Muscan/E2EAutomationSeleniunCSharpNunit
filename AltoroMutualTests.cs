using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using E2EAutomation.Utilities;
using E2EAutomation.PageObjects;
using System;

namespace E2EAutomation
{
    [TestFixture]
    public class AltoroTests
    {
        private IWebDriver webDriver;
        private string baseUrl;

        [SetUp]
        public void SetUpDriver()
        {
            webDriver = new ChromeDriver();
            baseUrl = Constants.baseUrl;
        }
        [TearDown]
        public void TearDown()
        {
            // webDriver.Quit();
            webDriver.Close();

        }

        [Test]
        public void LoginWithValidCredentials()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login(baseUrl, Constants.admin, Constants.password);

            MainPage mainPage = new MainPage(webDriver);
            Assert.True(mainPage.GetAccountButton.Displayed);
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login(baseUrl, Constants.invalidAdmin, Constants.invalidPassword);


            Assert.True(loginPage.InvalidLoginMessage.Displayed);

        }

        [Test]
        public void TransferMoney()

        {
            LoginWithValidCredentials();
            TransferFunds transferFunds = new TransferFunds(webDriver);
            transferFunds.TransferMoney(Constants.validAmount);
            Assert.True(transferFunds.TransferConfirmationMessage.Displayed);


        }
    }
    
}
