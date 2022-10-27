using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EAutomation.Utilities
{
    class TestCases
    {
        public static List<string> testsName = new List<string>() { 
             "LoginWithValidCredentials",
             "LoginWithInvalidCredentials",
             "TransferMoney",
             "RecentTransactions",
             "ViewRecentTransactionPageTable",
             "CheckHeaderIsDisplayed"};

    }
}
