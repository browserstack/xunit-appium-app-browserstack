using OpenQA.Selenium.Remote;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using BrowserStack;

namespace XUnit_BrowserStack
{
    public class BaseFixture : IDisposable
    {

        private AndroidDriver<AndroidElement> driver;

        public AndroidDriver<AndroidElement> GetDriver(string platform, string profile)
        {

            // Create Desired Cappabilities for WebDriver
            AppiumOptions appiumOptions = new AppiumOptions();

            // Create RemoteWebDriver instance
            driver = new AndroidDriver<AndroidElement>(
                new Uri($"http://127.0.0.1:4723/wd/hub"), appiumOptions);

            return driver;
        }

        public void Dispose()
        {
            if (driver is not null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
