using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Homework_22.Pages;
using Homework_22.Utils;

namespace Homework_22.Tests
{
    [AllureNUnit]
    public class TestForLogin:BaseTest
    {
        LoginPage loginPage = new LoginPage();
        ProductsPage productsPage = new ProductsPage();

        [TestCaseSource(typeof(CsvDataOfLogins), nameof(CsvDataOfLogins.GetTestCases))]
        [AllureTag("extended")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("TimKay")]
        [AllureSuite("Enter_in_system_with_different_login")]
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
