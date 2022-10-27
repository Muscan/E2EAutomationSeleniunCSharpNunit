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

        public static void MakeScreenshot(IWebDriver webDriver, string name)
        {
            string path = "C:\\Users\\Mihai\\source\\repos\\E2EAutomation\\Reports\\" + name + ".png";

            Screenshot screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }

        /*    public static string MakeScreenshot(IWebDriver webDriver)
            {
                string randomName = Guid.NewGuid().ToString();

                string path = "C:\\Users\\Mihai\\source\\repos\\E2EAutomation\\Reports\\"+randomName+".png";

                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                return path;
            }*/

        public static void MakeScreenshot(IWebDriver webDriver)
        {
       


            string randomName = Guid.NewGuid().ToString();

            string path = "C:\\Users\\Mihai\\source\\repos\\E2EAutomation\\Reports\\"+randomName + ".";
            Screenshot screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
           
        }
    }
}
