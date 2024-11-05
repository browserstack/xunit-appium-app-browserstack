using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace XUnit_Appium_BrowserStack
{
    public class SampleLocalTest : IClassFixture<BaseFixture>
    {

        private readonly BaseFixture baseFixture;

        public SampleLocalTest(BaseFixture baseFixture)
        {
            this.baseFixture = baseFixture;
        }

        [Fact]
        [Trait("Category", "sample-local-test")]
        public void BStackLocalTest()
        {
            AndroidDriver<AndroidElement> driver = baseFixture.GetDriver("chrome", "local");
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.Id("com.example.android.basicnetworking:id/test_action")));
            searchElement.Click();
            AndroidElement testElement = (AndroidElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(By.ClassName("android.widget.TextView")));

            ReadOnlyCollection<AndroidElement> allTextViewElements = driver.FindElements(By.ClassName("android.widget.TextView"));

            Thread.Sleep(5000);

            foreach (AndroidElement textElement in allTextViewElements)
            {
                if (textElement.Text.Contains("The active connection is"))
                {
                    Assert.True(textElement.Text.Contains("The active connection is wifi"),"Incorrect Text");        
                }
            }
        }
    }
}
