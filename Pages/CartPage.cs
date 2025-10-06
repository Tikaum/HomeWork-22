using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Pages
{
    public class CartPage : BasePage
    {
        private readonly By CartLabel = By.XPath("//span[@class='title' and text() = 'Your Cart']");
        private readonly By ItemName = By.CssSelector("div.inventory_item_name");
        private readonly By PriceElement = By.CssSelector(".inventory_item_price");       
        private readonly By ButtonForRemoveAnyItem = By.XPath("//button[contains(@data-test,'remove-sauce-labs-') and (text() = 'Remove')]");
        private readonly By BadgeOfBasket = By.XPath("//div[@id='shopping_cart_container']/a[@data-test='shopping-cart-link']");
        private readonly By ButtonForBackToProductPage = By.XPath("//button[@data-test = 'continue-shopping']");

        public bool IsCartLabelExist()
        {
            bool state = driver.FindElement(CartLabel).Displayed;
            return state;
        }

        public string GetNameOfItem()
        {
            string NameOfItem = driver.FindElement(ItemName).Text;
            return NameOfItem;
        }

        public string GetPriceOfItem()
        {
            string PriceOfItem = driver.FindElement(PriceElement).Text.Replace("$", "");            
            return PriceOfItem;
        }

        public void RemoveItemsFromCart()
        {
            driver.FindElement(ButtonForRemoveAnyItem).Click();
        }

        public void RemoveAllItemsFromCart()
        {
            string GetCountOfItemsInCart = driver.FindElement(BadgeOfBasket).Text;
            if (GetCountOfItemsInCart != "")
            {
                int CountOfItemsInCart = int.Parse(GetCountOfItemsInCart);
                while (CountOfItemsInCart > 0)
                {
                    driver.FindElement(ButtonForRemoveAnyItem).Click();
                    CountOfItemsInCart--;
                }
            }             
        }

        public string GetCountOfItemsInCart()
        {
            string GetCountOfItemsInCart = driver.FindElement(BadgeOfBasket).Text;
            return GetCountOfItemsInCart;
        }

        public void BackToProductPage()
        {
            driver.FindElement(ButtonForBackToProductPage).Click();
        }
    }
}
