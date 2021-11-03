#if XAMARIN_UITEST
using System.Threading;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace Shared.Steps
{
    [Binding]
    public abstract class Generic
    {

        public Generic()
        {
  
        }

        public Generic(string prefix)
        {
            Prefix = prefix;
        }
        
        private IApp App => Initializer.App;

        public string Prefix { get; set; }

        private void IAmAtThePage(string name, string method)
        {
            App.WaitForElement($"{Prefix}.Views.{name}");
            Thread.Sleep(5000);
            App.Screenshot(method); // nameof(?)); TODO: Get method name from caller
        }

        private void ITapOnButton(string name, string method)
        {
            App.WaitForElement($"Button{name}");
            App.Tap($"Button{name}");
            App.Screenshot(method); // nameof(?)); TODO: Get method name from caller
        }

        private void ITapOnTab(string name, string method)
        {
            App.WaitForElement($"Tab{name}");
            App.Tap($"Tab{name}");
            App.Screenshot(method); // nameof(?)); TODO: Get method name from caller
        }

        private void IFillInTheFollowingForm(Table table, string method)
        {
            foreach (var row in table.Rows)
            {
                var field = row["field"];
                var value = row["value"];
                App.WaitForElement($"Entry{field}");
                App.EnterText($"Entry{field}", value);
                App.DismissKeyboard();
                Thread.Sleep(1000);
                App.Screenshot(method); // nameof(?)); TODO: Get method name from caller
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
