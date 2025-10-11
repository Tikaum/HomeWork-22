using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Pages
{
    public class LoginPage:BasePage
    {
        private readonly By UserNameField = By.Id("user-name");
        private readonly By PasswordField = By.Id("password");
        private readonly By LoginButtonField = By.Id("login-button");        

        public void OpenStartPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        [AllureStep("Ввод логина {0} и пароля {1}")]
        public void LoginUser(string username, string password)
        {
            driver.FindElement(UserNameField).Click();
            driver.FindElement(UserNameField).SendKeys(username);
            driver.FindElement(PasswordField).Click();
            driver.FindElement(PasswordField).SendKeys(password);
            driver.FindElement(LoginButtonField).Click();
        }       
    }
}
