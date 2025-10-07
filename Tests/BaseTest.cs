using Homework_22.Pages;
using Homework_22.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22.Tests
{
    public class BaseTest
    {
        LoginPage loginPage = new LoginPage();

        [SetUp]
        public void Setup()
        {
            loginPage.OpenStartPage();
        }

        [TearDown]
        public void Teardown()
        {
            DriverManager.Quit();
        }
    }
}
