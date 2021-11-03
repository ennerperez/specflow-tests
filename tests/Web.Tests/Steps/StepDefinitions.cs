using Shared.Drivers.Interfaces;
using TechTalk.SpecFlow;

namespace Web.Steps
{
    [Binding]
    public sealed class StepDefinitions : Shared.Steps.Generic
    {
        public StepDefinitions(IDriverService appiumDriver) : base(appiumDriver)
        {
            Prefix = "App";
        }

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
