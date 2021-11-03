#if APPIUM

#if ANDROID
using OpenQA.Selenium.Appium.Android;
#elif IOS
using OpenQA.Selenium.Appium.iOS;
#else
using OpenQA.Selenium.Remote;
#endif

using Shared.Drivers;

using System.Threading;
using Shared.Drivers.Interfaces;
using TechTalk.SpecFlow;

namespace Shared.Steps
{
    [Binding]
    public abstract class Generic
    {
        internal readonly IDriverService AppiumDriver;

        public Generic(IDriverService appiumDriver)
        {
            this.AppiumDriver = appiumDriver;
        }
        
        public Generic(IDriverService appiumDriver, string prefix)
        {
            Prefix = prefix;
        }


#if ANDROID
        internal AndroidDriver<AndroidElement> Driver => ((AndroidDriver) AppiumDriver).Driver;
#elif IOS
        internal IOSDriver<IOSElement> Driver => ((iOSDriver) AppiumDriver).Driver;
#else
        internal RemoteWebDriver Driver => AppiumDriver.Driver;
#endif
        
        public string Prefix { get; set; }

        private void IAmAtThePage(string name, string method)
        {
            Driver.FindElementByAccessibilityId($"{Prefix}.Views.{name}");
            Thread.Sleep(5000);
            //Driver.Screenshot(method); // nameof(?)); TODO: Get method name from caller
        }

        private void ITapOnButton(string name, string method)
        {
            var button = Driver.FindElementByAccessibilityId($"Button{name}");
            button.Click();
            //Driver.Screenshot(method); // nameof(?)); TODO: Get method name from caller
        }

        private void ITapOnTab(string name, string method)
        {
            var button = Driver.FindElementByAccessibilityId($"Tab{name}");
            button.Click();
            //Driver.Screenshot(method); // nameof(?)); TODO: Get method name from caller
        }

        private void IFillInTheFollowingForm(Table table, string method)
        {
            foreach (var row in table.Rows)
            {
                var field = row["field"];
                var value = row["value"];
                var entry = Driver.FindElementByAccessibilityId($"Entry{field}");
                entry.SendKeys(value);
                //Driver.DismissKeyboard();
                Thread.Sleep(1000);
                //Driver.Screenshot(method); // nameof(?)); TODO: Get method name from caller
            }
        }

        [When(@"I tap on ""(.*)"" button")]
        public void WhenITapOnButton(string name)
        {
            ITapOnButton(name, nameof(WhenITapOnButton));
        }

        [Then(@"I tap on ""(.*)"" button")]
        public void ThenITapOnButton(string name)
        {
            ITapOnButton(name, nameof(ThenITapOnButton));
        }

        [Then(@"I tap on ""(.*)"" tab")]
        public void ThenITapOnTab(string name)
        {
            ITapOnTab(name, nameof(ThenITapOnTab));
        }

        [When("I fill in the following form")]
        public void WhenIFillInTheFollowingForm(Table table)
        {
            IFillInTheFollowingForm(table, nameof(WhenIFillInTheFollowingForm));
        }

        [Then("I fill in the following form")]
        public void ThenIFillInTheFollowingForm(Table table)
        {
            IFillInTheFollowingForm(table, nameof(ThenIFillInTheFollowingForm));
        }

        [Given(@"I am at the ""(.*)"" page")]
        public void GivenIAmAtThePage(string name)
        {
            IAmAtThePage(name, nameof(GivenIAmAtThePage));
        }

        [Then(@"I should be at the ""(.*)"" page")]
        public void ThenIShouldBeAtThePage(string name)
        {
            IAmAtThePage(name, nameof(ThenIShouldBeAtThePage));
        }
        
    }
}
#endif
