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
    //[SetUpFixture]
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
            //ChromiumDriver
            webDriver = new ChromeDriver();
            baseUrl = Constants.baseUrl;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(Constants.TIMEOUT);
        }

        //SetUp runns before each test
        [SetUp]
        public void SetUpDriver()
        {
            //counts the nr. of test in order to arrange the tests one after another
            test = report.CreateTest(TestCases.testsName[Utils.testCount]);
            Utils.testCount++;
        }

        //this is executed one at the final
        [OneTimeTearDown]
        public void TearDown()
        {

            report.Flush();
            webDriver.Close();
            webDriver.Quit();
        }




        [Test, Order(1)]
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
        [Test, Order(2)]
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

        [Test, Order(3)]
        public void TransferMoney()
        {

            try
            {
                MainPage mainPage = new MainPage(webDriver);
                //MakeScreenshot does screen shot in the place where it is called
                //string img = Utils.MakeScreenshot(webDriver);
                //test.Log(Status.Pass, "Hello Admin User is displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());

                mainPage.ClickTransferFunds();
                TransferFunds transferFunds = new TransferFunds(webDriver);
                string img = Utils.MakeScreenshot(webDriver);
                test.Log(Status.Pass, "Transfer Funds is displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());


                transferFunds.TransferMoney(Constants.validAmount);

                string img2 = Utils.MakeScreenshot(webDriver);

                if (transferFunds.TransferConfirmationMessage.Displayed)
                {
                    test.Log(Status.Pass, "Transfer confirmation message is displayed", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img2).Build());
                }
                else
                {
                    test.Log(Status.Fail, "Elem not found!", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img2).Build());
                }
                Assert.IsTrue(transferFunds.TransferConfirmationMessage.Displayed);

            }
            //NoSuchElementException is a child of WebDriverException
            catch (NoSuchElementException e)
            {
                string img = Utils.MakeScreenshot(webDriver);
                test.Fail(e, MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
            }
            //page cannot be accesed. This error is thrown when the page server cannot be accessed
            catch (WebDriverException e)
            {
                string img = Utils.MakeScreenshot(webDriver);
                test.Fail(e, MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
            }


        }


        [Test, Order(4)]
        public void RecentTransactions()
        {
            try
            {

                TransferFunds tf = new TransferFunds(webDriver);
                tf.ClickViewRecentTransactions();


                ViewRecentTransactionsPage vtp = new ViewRecentTransactionsPage(webDriver);
                TransactionModel tm = vtp.FirstRowData();
                string img = Utils.MakeScreenshot(webDriver);
                bool isOk;
                if (tm.AccountId.Equals("800001") && tm.Amount.Equals("$" + Constants.validAmount + ".00"))
                {
                    test.Log(Status.Pass, "To account and amount was transfered", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                    isOk = true;
                }
                else
                {

                    test.Log(Status.Fail, "To account and amount was transfered", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                    isOk = false;
                }
                Assert.IsTrue(isOk);
            }
            catch (WebDriverException e)
            {
                string img = Utils.MakeScreenshot(webDriver);
                test.Fail(e, MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
            }
        }
        [Test, Order(5)]

        public void RecentTransactionsWithdraw()
        {
            try
            {

                ViewRecentTransactionsPage vrtp = new ViewRecentTransactionsPage(webDriver);
                TransactionModel tm = vrtp.SecondRowData();

                bool valuesInTableSecondRowOk;
                string img = Utils.MakeScreenshot(webDriver);
                if (tm.AccountId.Equals(Constants.fromAccount)
                    && tm.Amount.Equals("-$" + Constants.validAmount + ".00")
                    && tm.Action.Equals("Withdrawal"))
                {
                    test.Log(Status.Pass, "Money was withdrawed from account", MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                    valuesInTableSecondRowOk = true;
                }
                else
                {
                    test.Log(Status.Fail, "Money were not withdrawed from the " + Constants.fromAccount, MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
                    valuesInTableSecondRowOk = false;
                }
                Assert.IsTrue(valuesInTableSecondRowOk);
            }
            catch (WebDriverException e)
            {
                string img = Utils.MakeScreenshot(webDriver);
                test.Fail(e, MediaEntityBuilder.CreateScreenCaptureFromBase64String(img).Build());
            }

        }

    }
}
