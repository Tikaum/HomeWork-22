using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Pages
{
    public class ProductsPage : BasePage
    {
        private readonly By ProductLabel = By.XPath("//span[@class='title' and text() = 'Products']");

        public bool IsProductLabelExist()
        {
            bool state = driver.FindElement(ProductLabel).Displayed;
            return state;
        }
    }
}
