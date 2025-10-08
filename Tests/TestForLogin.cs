using Homework_22.Pages;
using Homework_22.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Allure.NUnit.Attributes;
using Allure.NUnit;

namespace Homework_22.Tests
{
    public class TestForLogin:BaseTest
    {
        LoginPage loginPage = new LoginPage();
        ProductsPage productsPage = new ProductsPage();

        [TestCaseSource(typeof(CsvDataOfLogins), nameof(CsvDataOfLogins.GetTestCases))]
        public void TestFromCSV(string login, string password, string expected)
        {
            bool expectedResult = Convert.ToBoolean(expected);            
            loginPage.LoginUser(login, password);            
            bool IsProductsPageOpen = productsPage.IsProductsPageLabelExist();
            Assert.That(IsProductsPageOpen, Is.EqualTo(expectedResult),
                "The result obtained does not match the expected one.");                
        }
    }
}
