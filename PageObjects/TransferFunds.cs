using E2EAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EAutomation.PageObjects
{
    class TransferFunds
    {
        private IWebDriver webDriver;

        public TransferFunds(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
     
        [FindsBy(How = How.Id, Using = "fromAccount")]
        public SelectElement FromAccountFirstOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fromAccount > option:nth-child(1)")]
        public IWebElement FromAccountDropDownOption1 { get; set; }

        [FindsBy(How = How.Id, Using = "toAccount")]
        public SelectElement ToAccountSecondOption { get; set; }

        [FindsBy(How = How.CssSelector, Using = "toAccount > option:nth-child(2)")]
        public IWebElement ToAccountDropDownOption2 { get; set; }

        [FindsBy(How = How.Id, Using = "transferAmount")]
        public IWebElement AmountInputField { get; set; }

        [FindsBy(How = How.Id, Using = "transfer")]
        public IWebElement TransferButton { get; set; }

        [FindsBy(How = How.Id, Using = "_ctl0__ctl0_Content_Main_postResp")]
        public IWebElement TransferConfirmationMessage { get; set; }

        [FindsBy(How = How.Id, Using = "MenuHyperLink3")]
        public IWebElement TransferFundsURL { get; set; }

        [FindsBy(How = How.TagName, Using = "h1")]
        public IWebElement TransferFundsHeader { get; set; }


        [FindsBy(How = How.Id, Using = "MenuHyperLink2")]
        public IWebElement ViewRecentTransactions { get; set; }

        public void ClickViewRecentTransactions()
        {
            ViewRecentTransactions.Click();
        }

        public void TransferMoney(string inputValue)
        {

            FromAccountFirstOption.SelectByValue("800000");
           // TransferFundsHeader.Click();
            
            ToAccountSecondOption.SelectByValue("800001");

            //FromAccountFirstOption.SelectedOption.Click();
            // FromAccountDropDownOption1.();
           
            ToAccountSecondOption.SelectByIndex(1);
            DefaultWait<IWebDriver> fluentWait = Utils.GetFluentWait(webDriver, "To or From Account not found.");
            fluentWait.Until(x => x.FindElement(By.Id("fromAccount")));

            ToAccountSecondOption.SelectedOption.Click();
           
            AmountInputField.Click();
            AmountInputField.Clear();
            AmountInputField.SendKeys(inputValue);
            TransferButton.Click();
            

            fluentWait.Until(x => x.FindElement(By.Id("_ctl0__ctl0_Content_Main_postResp")));

        }

        public void ClickTransferFunds()
        {
            TransferButton.Click();
        }

    }
}
