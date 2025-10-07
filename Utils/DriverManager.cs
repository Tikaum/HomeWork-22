using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Utils
{
    public class DriverManager
    {
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = Init();
                }
                return driver;
            }
        }

        private static IWebDriver Init()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            return new FirefoxDriver(options);
        }

        public static void Quit()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
