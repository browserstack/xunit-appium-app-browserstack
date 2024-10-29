using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace XUnit_BrowserStack
{
    public class SampleTest : IClassFixture<BaseFixture>
    {

        private readonly BaseFixture baseFixture;

        public SampleTest(BaseFixture baseFixture)
        {
            this.baseFixture = baseFixture;
        }

        [Fact]
        [Trait("Category", "sample-test")]
        public void BStackSampleTest()
        {
            IOSDriver<IOSElement> driver = baseFixture.GetDriver("chrome", "single");
            IOSElement textButton = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Button")));
            textButton.Click();

            IOSElement textInput = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Input")));
            textInput.SendKeys("hello@browserstack.com" + "\n");

            IOSElement textOutput = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Text Output")));
            Assert.Equal("hello@browserstack.com", textOutput.Text);
        }
    }
}
