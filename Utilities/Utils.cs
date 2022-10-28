using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EAutomation.Utilities
{
    class Utils
    {
        public static int testCount = 0;

        public static DefaultWait<IWebDriver> GetFluentWait(IWebDriver webDriver, string message)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(webDriver);

            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = message;

            return fluentWait;

        }

        public static string MakeScreenshot(IWebDriver webDriver)
        {
            string img = ((ITakesScreenshot)webDriver).GetScreenshot().AsBase64EncodedString;
            return img;

        }
    }
}
