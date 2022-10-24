using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using E2EAutomation.Utilities;
using E2EAutomation.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace E2EAutomation
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver webDriver;
        private string baseUrl;

        [SetUp]
        public void SetUpDriver()
        {
            webDriver = new ChromeDriver();
            baseUrl = Constants.baseUrl;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Constants.TIMEOUT);
        }

        [TearDown]
        public void TearDown()
        {
            // webDriver.Quit();
            webDriver.Close();
        }

     /*   [Test]
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

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(webDriver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login(baseUrl, Constants.admin, Constants.password);

            MainPage mainPage = new MainPage(webDriver);
            mainPage.ClickTransferFounds();

            TransferFunds transferFunds = new TransferFunds(webDriver);
            transferFunds.TransferMoney(Constants.validAmount);
            Assert.True(transferFunds.TransferConfirmationMessage.Displayed);
        }

        [Test]
        public void RecentTransactions()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login(baseUrl, Constants.admin, Constants.password);

            MainPage mainPage = new MainPage(webDriver);
            Assert.True(mainPage.GetAccountButton.Displayed);

            ViewRecentTransactionsPage vtp = new ViewRecentTransactionsPage(webDriver);
            Assert.True(vtp.RecentTransactionsH1.Displayed);
        }*/

        [Test]
        public void ViewRecentTransactionPageTable()
        {
            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login(baseUrl, Constants.admin, Constants.password);

            MainPage mainPage = new MainPage(webDriver);
            mainPage.ClickTransferFounds();
            
            TransferFunds transferFunds = new TransferFunds(webDriver);
            transferFunds.TransferMoney(Constants.validAmount);
            transferFunds.ClickTransferFunds();

            ViewRecentTransactionsPage viewRecentTransactionPage = new ViewRecentTransactionsPage(webDriver);
            TransactionModel transaction = viewRecentTransactionPage.GetTableData();
    
            //Assert.AreEqual("$1000.00" ,transaction.Amount);
            //Assert.AreEqual("Deposit"  ,transaction.Action);
            Assert.AreEqual("800001"   , transaction.AccountId);
 
        }
    }
}
