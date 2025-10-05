using Homework_22.Pages;
using Homework_22.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Tests
{
    public class TestForLogin
    {
        LoginPage loginPage = new LoginPage();

        [TestCaseSource(typeof(CsvData), nameof(CsvData.GetTestCases))]
        public void TestFromCSV(string login, string password, string expected)
        {
            loginPage.LoginUser(login, password);
        }
    }
}
