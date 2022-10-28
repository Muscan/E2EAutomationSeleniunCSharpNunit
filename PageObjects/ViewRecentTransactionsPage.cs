using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EAutomation.PageObjects
{
    class ViewRecentTransactionsPage
    {
        private IWebDriver webDriver;

        public ViewRecentTransactionsPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "h1")]
        public IWebElement RecentTransactionsH1 { get; set; }


        [FindsBy(How = How.XPath, Using = "/html/body/table[2]/tbody/tr/td[2]/div/form/table[2]/tbody/tr[2]")]
        private IWebElement FirstRow { get; set; }

        [FindsBy(How = How.Id, Using = "MenuHyperLink2")]
        private IWebElement VRTP {get;set;}
    
        public TransactionModel GetTableData()
        {
            string[] data = FirstRow.Text.Split(' ');
            TransactionModel transaction = new TransactionModel()
            {
                 TransactionId = data[0]
                ,TimeStamp     = data[1] + " " + data[2]
                ,AccountId     = data[3]
                ,Action        = data[4]
                ,Amount        = data[5]
            };

            return transaction;
        }

        public void ViewRecentTransactionPageClick()
        {
            VRTP.Click();
        }






















        /* List<WebElement> listOfWebElements = driver.findElements(By.xpath("/html/body/table/tbody[1]/tr"));

        for(WebElement element : listOfWebElements){
            System.out.println(element.getText());
        }*/


        /*  public List<TransactionModel> GetAvailableTransaction()
          {
              List<TransactionModel> transactions = new List<TransactionModel>();

              for (int i = 1; i < TableElements.Count(); i++)
              {
                  TransactionModel trasaction = new TransactionModel();

                  transactions.Add(trasaction);
              }

              return transactions;
              //td sau tr


          }*/

    }
}
