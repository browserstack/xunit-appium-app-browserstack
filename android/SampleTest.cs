using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Appium;

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
            AndroidDriver<AndroidElement> driver = baseFixture.GetDriver("chrome", "single");
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId("Search Wikipedia")));
            searchElement.Click();
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("org.wikipedia.alpha:id/search_src_text")));
            insertTextElement.SendKeys("BrowserStack");
            Thread.Sleep(5000);

            ReadOnlyCollection<AndroidElement> allProductsName = driver.FindElements(By.ClassName("android.widget.TextView"));
            Assert.True(allProductsName.Count > 0);
        }
    }
}
