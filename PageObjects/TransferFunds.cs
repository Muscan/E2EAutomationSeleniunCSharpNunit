using OpenQA.Selenium;
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
     

        [FindsBy(How = How.CssSelector, Using = "fromAccount > option:nth-child(1)")]
        public IWebElement FromAccountDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "toAccount > option:nth-child(2)")]
        public IWebElement ToAccountDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "transferAmount")]
        public IWebElement AmountInputField { get; set; }

        [FindsBy(How = How.Id, Using = "transferAmount")]
        public IWebElement TransferButton { get; set; }

        [FindsBy(How = How.Id, Using = "_ctl0__ctl0_Content_Main_postResp > span:nth-child(1)")]
        public IWebElement TransferConfirmationMessage { get; set; }
        public void TransferMoney(string inputValue)
        {
           // FromAccountDropDown.Click();
           // ToAccountDropDown.Click();
            AmountInputField.Clear();
            AmountInputField.SendKeys(inputValue);
            TransferButton.Click();

        }

   
    }
}
