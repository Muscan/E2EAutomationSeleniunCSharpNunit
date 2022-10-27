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
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using OpenQA.Selenium.Chromium;

namespace E2EAutomation
{
    [TestFixture]

    public class Tests
    {
        private IWebDriver webDriver;
        private string baseUrl;

        public static ExtentReports report;
       
        public ExtentTest test;

        [OneTimeSetUp]
        public void StartReport()
        {
            //string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+ "\\Report.html";
            var reporterType = new ExtentHtmlReporter("C:\\Users\\Mihai\\source\\repos\\E2EAutomation\\Reports\\Report.html");
            
            report = new ExtentReports();
            report.AttachReporter(reporterType);
        }
    
        [SetUp]
        public void SetUpDriver()
        {
            //ChromiumDriver
            webDriver = new ChromeDriver();
            baseUrl = Constants.baseUrl;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Constants.TIMEOUT);
            test = report.CreateTest(TestCases.testsName[Utils.testCount]);
            Utils.testCount++;
        }

        [TearDown]
        public void TearDown()
        {
           
            report.Flush();
            webDriver.Close();
            webDriver.Quit();
        }

        [Test]
        public void LoginWithValidCredentials()
        {
       
            LoginPage loginPage = new LoginPage(webDriver);
            try
            {
                loginPage.Login(baseUrl, Constants.admin, Constants.password);
                if (loginPage.LoginFailedMessage.Displayed)
                {
                    Utils.MakeScreenshot(webDriver, "LoginWithValidCredentials");
                }
            
                else
                {

                    test.Log(Status.Info, "Check error");
                }
                MainPage mainPage = new MainPage(webDriver);
               
                if (mainPage.GetAccountButton.Displayed)
                {
                    test.Log(Status.Pass, "GetAccountButton Displayed");
                } 
                else
                {
                    //test.Log(Status.Fail, "GetAccountButton not displayed").AddScreenCaptureFromPath("C:\\Users\\Mihai\\source\\repos\\E2EAutomation\\Reports\\LoginWithValidCredentials.png");
                }
                Assert.True(mainPage.GetAccountButton.Displayed);
            }catch(WebDriverException )
            {
                Utils.MakeScreenshot(webDriver);

                test.Fail("PAGE NOT REACHED");
               // MediaEntityBuilder.CreateScreenCaptureFromPath("C:\\Users\\Mihai\\source\\repos\\E2EAutomation\\Reports\\sadas.png").Build());

               // test.Fail("PAGE NOT REACEHD").AddScreenCaptureFromPath("C:\\Users\\Mihai\\source\\repos\\E2EAutomation\\Reports\\sadas.png");
            }
            
        }
        /*
                [Test]
                public void LoginWithInvalidCredentials()
                {
                    LoginPage loginPage = new LoginPage(webDriver);
                    loginPage.Login(baseUrl, Constants.invalidAdmin, Constants.invalidPassword);
                    Assert.True(loginPage.InvalidLoginMessage.Displayed);
                    test.Log(Status.Pass, "User is logged in");
                }

                [Test]
                public void TransferMoney()
                {

                    DefaultWait<IWebDriver> fluentWait = Utils.GetFluentWait(webDriver, "Transfer confirmation message not displayed");
                    LoginPage loginPage = new LoginPage(webDriver);
                    loginPage.Login(baseUrl, Constants.admin, Constants.password);

                    MainPage mainPage = new MainPage(webDriver);
                    mainPage.ClickTransferFunds();

                    TransferFunds transferFunds = new TransferFunds(webDriver);
                    transferFunds.TransferMoney(Constants.validAmount);
                    if (transferFunds.TransferConfirmationMessage.Displayed)
                    {
                        test.Log(Status.Pass, "Transfer confirmation message is displayed");
                    }
                    else
                    {
                        test.Log(Status.Fail, "Elem not found!");
                    }
                    Assert.True(transferFunds.TransferConfirmationMessage.Displayed);
                }*/

        /* [Test]
         public void RecentTransactions()
         {
             LoginPage loginPage = new LoginPage(webDriver);
             loginPage.Login(baseUrl, Constants.admin, Constants.password);

             MainPage mainPage = new MainPage(webDriver);
             Assert.True(mainPage.GetAccountButton.Displayed);

             ViewRecentTransactionsPage vtp = new ViewRecentTransactionsPage(webDriver);
             Assert.True(vtp.RecentTransactionsH1.Displayed);
         }*/

        /*        [Test]
                public void ViewRecentTransactionPageTable()
                {
                    LoginPage loginPage = new LoginPage(webDriver);
                    loginPage.Login(baseUrl, Constants.admin, Constants.password);

                    MainPage mainPage = new MainPage(webDriver);
                    mainPage.ClickTransferFunds();


                    TransferFunds transferFunds = new TransferFunds(webDriver);
                    transferFunds.TransferMoney(Constants.validAmount);
                    transferFunds.ClickTransferFunds();

                    ViewRecentTransactionsPage viewRecentTransactionPage = new ViewRecentTransactionsPage(webDriver);
                    TransactionModel transaction = viewRecentTransactionPage.GetTableData();

                    Assert.AreEqual("$1000.00", transaction.Amount);
                    //Assert.AreEqual("Deposit"  ,transaction.Action);
                    //Assert.AreEqual("800001"   , transaction.AccountId);
                }*/
        /*  [Test]
          public void CheckHeaderIsDisplayed()
          {
              LoginPage loginPage = new LoginPage(webDriver);
              loginPage.Login(baseUrl, Constants.admin, Constants.password);

              MainPage mainPage = new MainPage(webDriver);
              //expected result
              string welcomeUser = "Hello Admin User";

              string actualResult = mainPage.CheckHeader();
              Console.WriteLine(actualResult);


              Assert.AreEqual(welcomeUser, actualResult);

          }*/
    }
}
