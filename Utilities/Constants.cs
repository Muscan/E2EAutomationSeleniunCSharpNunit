using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EAutomation.Utilities
{
    class Constants
    {
        public static string baseUrl = "https://demo.testfire.net/index.jsp";
        public static string admin = "admin'--";
        public static string password = "blah";
        public static string invalidAdmin = "invalid";
        public static string invalidPassword = "123";
        public static string validAmount = "1000";
     //   public static string validAmountDynamic = (new Random().NextDouble()* (100000000000000 - 0.0000000000001) + 0.0000000000001).ToString();
        public static string invalidAmount = "test";
        public const int TIMEOUT = 5000;
        public static string fromAccount = "800000";
        public static string toAccount = "800001";
        public static readonly string DocumentPath = Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, @"Assests\FilesSignature.jpg"));
       
    }
}
