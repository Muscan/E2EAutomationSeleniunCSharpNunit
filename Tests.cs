using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using E2EAutomation.PageObjects;
using E2EAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace E2EAutomation
{
    [TestFixture]

    public class Tests
    {
        private IWebDriver webDriver;
        private string baseUrl;

        public static ExtentReports report;

        public ExtentTest test;
        //OneTimeSetUp runs at the beginning of all tests
        [OneTimeSetUp]
        public void StartReport()
        {

            var reporterType = new ExtentHtmlReporter("C:\\Users\\Mihai\\source\\repos\\E2EAutomation\\Reports\\Report.html");

            report = new ExtentReports();
            report.AttachReporter(reporterType);
        }
        
        //SetUp runns before each test
        [SetUp]
        public void SetUpDriver()
        {
            //ChromiumDriver
            webDriver = new ChromeDriver();
            baseUrl = Constants.baseUrl;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Constants.TIMEOUT);
            //counts the nr. of test in order to arrange the tests one after another
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
      
        [Test,Order(1)]
        public void LoginWithValidCredentials()
        {

            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login(baseUrl, Constants.admin, Constants.password);

            try
            {
                MainPage mainPage = new MainPage(webDriver);
                if (mainPage.HelloUser.Displayed)
                {
                    //MakeScreenshot does screen shot in the place where it is called
                    string img = Utils.MakeScreenshot(webDriver);
                    test.Log(Status.Pass, "Hello Admin User is displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                }
                else
                {
                    string img = Utils.MakeScreenshot(webDriver);
                    test.Log(Status.Fail, "Hello Admin User is not displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                }
                Assert.IsTrue(mainPage.HelloUser.Displayed);
            }
            //page cannot be accesed. This error is thrown when the page server cannot be accessed
            catch (WebDriverException e)
            {
                string img = Utils.MakeScreenshot(webDriver);
                test.Fail(e, MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
            }

        }


        [Test, Order(2)]
        public void LoginWithInvalidCredentials()
        {
            LoginPage loginPage = new LoginPage(webDriver);


            try
            {
                loginPage.Login(baseUrl, Constants.invalidAdmin, Constants.invalidPassword);
                if (loginPage.InvalidLoginMessage.Displayed)
                {
                    string img = Utils.MakeScreenshot(webDriver);
                    test.Log(Status.Pass, "Login With InvalidCredentials", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                }
                else
                {
                    string img = Utils.MakeScreenshot(webDriver);
                    test.Log(Status.Fail, "Invalid Login not displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                }
                Assert.True(loginPage.InvalidLoginMessage.Displayed);
            }
            catch (WebDriverException e)
            {
                string img = Utils.MakeScreenshot(webDriver);
                test.Log(Status.Fail, "LoginWithInvalidCredentials Exception", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
            }

        }

        [Test, Order(3)]
        public void TransferMoney()
        {

            LoginPage loginPage = new LoginPage(webDriver);
            loginPage.Login(baseUrl, Constants.admin, Constants.password);

            try
            {
                MainPage mainPage = new MainPage(webDriver);
                TransferFunds transferFunds = new TransferFunds(webDriver);
                if (mainPage.HelloUser.Displayed)
                {
                    //MakeScreenshot does screen shot in the place where it is called
                    string img = Utils.MakeScreenshot(webDriver);
                    test.Log(Status.Pass, "Hello Admin User is displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                    string img2 = Utils.MakeScreenshot(webDriver);
                    mainPage.ClickTransferFunds();
                    test.Log(Status.Pass, "Transfer Funds is displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img2).Build());


                    transferFunds.TransferMoney(Constants.validAmount);

                    string img3 = Utils.MakeScreenshot(webDriver);
                    test.Log(Status.Pass, "Money was transfered is displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                    //transferFunds.TransferConfirmationMessage.Displayed;
                }
                else
                {
                    string img = Utils.MakeScreenshot(webDriver);
                    test.Log(Status.Fail, "Hello Admin User is not displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                }
                Assert.IsTrue(mainPage.HelloUser.Displayed);
                Assert.IsTrue(mainPage.ViewRecentTransactions.Displayed);
                Assert.IsTrue(transferFunds.TransferConfirmationMessage.Displayed);
            }

            //page cannot be accesed. This error is thrown when the page server cannot be accessed
            catch (NoSuchElementException e)
            {
                string img = Utils.MakeScreenshot(webDriver);
                test.Fail(e, MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                
                

            }

            DefaultWait<IWebDriver> fluentWait = Utils.GetFluentWait(webDriver, "Transfer confirmation message not displayed");


        }  
           /* 
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

                    MainPage m
        ainPage = new MainPage(webDriver);
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
