using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace Homework_22.Pages
{
    public class ProductsPage : BasePage
    {
        private readonly By ProductLabel = By.XPath("//span[@class='title' and text() = 'Products']");
        private readonly By CartButtom = By.XPath("//div[@id='shopping_cart_container']/a[@data-test='shopping-cart-link']");
        private readonly By BadgeCartButtomBase = By.XPath("//div[@id='shopping_cart_container']/a[@data-test='shopping-cart-link']");                
        private readonly string ButtonAddToCartLocatorFormat = "//div[contains(text(),'{0}')]/ancestor::div[@class='inventory_item_description']//button[contains(@data-test,'add-to-cart')]";        

        public bool IsProductLabelExist()
        {
            int ElementsFind = driver.FindElements(ProductLabel).Count();
            if (ElementsFind > 0)
            {
                bool IsElementFind = driver.FindElement(ProductLabel).Displayed;
                return IsElementFind;
            }
            else { return false; }
        }

        public void AddItemFromNameToCart(string ItemName)
        {
            driver.FindElement(By.XPath(Format(ButtonAddToCartLocatorFormat, ItemName))).Click();
        }

        public string GetCountItemInCart()
        {
            string CountItemInCart = driver.FindElement(BadgeCartButtomBase).Text;
            return CountItemInCart;
        }

        public void GoToCart()
        {
            driver.FindElement(CartButtom).Click();
        }
    }
}
