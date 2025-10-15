using OpenQA.Selenium;

namespace Homework_22.Utils
{
    public class ScreenshotUtils
    {
        protected IWebDriver driver => DriverManager.Driver;

        public string SaveScreenshotAndReturnFileName()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = $"screenshot_{Guid.NewGuid()}.png";
            var filePath = Path.Combine("allure-results", fileName);
            screenshot.SaveAsFile(filePath);
            return fileName;
        }
    }
}
