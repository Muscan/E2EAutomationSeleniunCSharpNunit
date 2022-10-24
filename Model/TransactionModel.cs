using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EAutomation.PageObjects
{
    class TransactionModel
    {
        public string TransactionId { get; set; }
        public string TimeStamp     { get; set; }
        public string AccountId     { get; set; }
        public string Action        { get; set; }
        public string Amount        { get; set; }

        public TransactionModel()
        { 
        }
    }   
}
