using Homework_22.Pages;
using Homework_22.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Tests
{
    public class TestForLogin:BaseTest
    {
        LoginPage loginPage = new LoginPage();
        ProductsPage productsPage = new ProductsPage();

        [TestCaseSource(typeof(CsvData), nameof(CsvData.GetTestCases))]
        public void TestFromCSV(string login, string password, string expected)
        {
            bool expectedResult = Convert.ToBoolean(expected);            
            loginPage.LoginUser(login, password);            
            bool IsProductsPageOpen = productsPage.IsProductLabelExist();
            Assert.That(IsProductsPageOpen, Is.EqualTo(expectedResult),
                "The result obtained does not match the expected one.");                
        }
    }
}
