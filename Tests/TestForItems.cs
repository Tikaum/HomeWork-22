using Homework_22.Pages;
using Homework_22.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Tests
{
    public class TestForItems : BaseTest
    {
        LoginPage loginPage = new LoginPage();
        ProductsPage productsPage = new ProductsPage();
        CartPage cartPage = new CartPage();

        [TestCaseSource(typeof(CsvDataOfItems), nameof(CsvDataOfItems.GetTestCases))]
        public void TestFromCSV(string name, string price)
        {
            loginPage.LoginUser("standard_user", "secret_sauce");
            bool IsProductsPageOpen = productsPage.IsProductsPageLabelExist();
            Assert.That(IsProductsPageOpen, Is.True, "The products page did not open.");
            productsPage.GoToCart();
            cartPage.RemoveAllItemsFromCart();
            cartPage.BackToProductPage();
            productsPage.AddItemFromNameToCart(name);
            string ItemCount = productsPage.GetCountItemInCart();
            Assert.That(ItemCount, Is.EqualTo("1"), "There is an incorrect quantity of products in the basket.");
            productsPage.GoToCart();
            bool IsCartPageOpen = cartPage.IsCartLabelExist();
            string NameOfItem = cartPage.GetNameOfItem();
            string PriceOfItem = cartPage.GetPriceOfItem();
            cartPage.RemoveItemsFromCart();
            string CountOfItemsInCart = cartPage.GetCountOfItemsInCart();
            Assert.Multiple(() =>
            {
                Assert.That(IsCartPageOpen, Is.True, "The cart page did not open.");
                Assert.That(NameOfItem, Is.EqualTo(name), "The product name in the cart does not match the expected one.");
                Assert.That(PriceOfItem, Is.EqualTo(price), "The price of the product in the cart does not match the expected price.");
                Assert.That(CountOfItemsInCart, Is.EqualTo(""), "The item was not removed from the cart");
            });
            
        }
    }
}
