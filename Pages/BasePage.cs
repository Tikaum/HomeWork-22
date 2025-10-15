using Homework_22.Utils;
using OpenQA.Selenium;

namespace Homework_22.Pages
{
    public class BasePage
    {
        protected IWebDriver driver => DriverManager.Driver;
    }
}
