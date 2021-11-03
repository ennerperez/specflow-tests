#if APPIUM
using Shared.Drivers.Interfaces;
#endif

using TechTalk.SpecFlow;

namespace Mobile.Xamarin.UITest.Steps
{
    [Binding]
    public sealed class StepDefinitions : Shared.Steps.Generic
    {
#if APPIUM
        public StepDefinitions(IDriverService appiumDriver) : base(appiumDriver)
        {
            Prefix = "App";
        }
#endif
#if XAMARIN_UITEST
        public StepDefinitions()
        {
            Prefix = "App";
        }
#endif

        [Given(@"I sign in with the following account")]
        public void GivenISignInWithTheFollowingAccount(Table account)
        {
            GivenIAmAtThePage("Start");
            WhenITapOnButton("Login");
            ThenIFillInTheFollowingForm(account);
            ThenITapOnButton("SignIn");
            ThenIShouldBeAtThePage("Home");
        }
    }
}
