using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EAutomation.PageObjects
{
    class LoginPage
    {
        private IWebDriver webDriver;

        public LoginPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "AccountLink")]
        public IWebElement SignInLink { get; set; }
        //private IWebElement signInLink;
        //public IWebElement getSignInLink(){ return signInLink;}
        //public void setSignInLink(IWebElement element) { signInLink = element; }

        [FindsBy(How = How.Id, Using = "uid")]
        public IWebElement UserIdField { get; set; }

        [FindsBy(How = How.Id, Using = "passw")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Name, Using = "btnSubmit")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "_ctl0__ctl0_Content_Main_message")]
        public IWebElement InvalidLoginMessage { get; set; }

        [FindsBy(How = How.Id, Using = "_ctl0__ctl0_Content_Main_message")]
        public IWebElement LoginFailedMessage { get; set; }

        public void Login(string baseUrl, string userId, string password)
        {
            webDriver.Navigate().GoToUrl(baseUrl);
            SignInLink.Click();
            UserIdField.Clear();
            UserIdField.SendKeys(userId);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }
    }

}
