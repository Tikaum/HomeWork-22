using Allure.Net.Commons;
using Homework_22.Pages;
using Homework_22.Utils;
using NUnit.Framework.Interfaces;

namespace Homework_22.Tests
{
    public class BaseTest
    {
        LoginPage loginPage = new LoginPage();
        ScreenshotUtils screenshotUtils = new ScreenshotUtils();

        [SetUp]
        public void Setup()
        {
            loginPage.OpenStartPage();
        }

        [TearDown]
        public void Teardown()
        {
            var context = TestContext.CurrentContext;
            if (context.Result.Outcome.Status == TestStatus.Failed)
            {
                AllureLifecycle.Instance.UpdateTestCase(x =>
                {
                    x.attachments.Add(new Attachment
                    {
                        name = "Failure Screenshot",
                        type = "image/png",
                        source = screenshotUtils.SaveScreenshotAndReturnFileName()
                    });
                });
            }
            DriverManager.Quit();
        }
    }
}
