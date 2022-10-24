using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EAutomation.PageObjects
{
    public class MainPage
    {
        private IWebDriver webDriver;
        
        public MainPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Id, Using = "btnGetAccount")]
        public IWebElement GetAccountButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuHyperLink3")]
        public IWebElement TransferFundsButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuHyperLink2")]
        public IWebElement ViewRecentTransactions { get; set; }

        public void ClickTransferFounds ()
        {
            TransferFundsButton.Click();
           
        }

        public void ClickViewRecentTransactions()
        {
            ViewRecentTransactions.Click();
        }

    }
}
