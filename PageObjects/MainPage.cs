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

        [FindsBy(How = How.XPath, Using = "//*[@id=\"_ctl0__ctl0_Content_Main_promo\"]/table/tbody/tr[3]/td/a")]
        public IWebElement TransferFundsButton { get; set; }

  /*      public RequestGoldVisaPage NavigateToTransferFunds()
        {
            TransferFundsButton.Click();
            return new RequestGoldVisaPage(_driver);
        }*/

    }
}
