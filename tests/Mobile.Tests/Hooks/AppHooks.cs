using BoDi;
using TechTalk.SpecFlow;

namespace Mobile.Tests.Hooks
{
    [Binding]
    public class AppHooks : Shared.Hooks.Generic
    {
        public AppHooks(IObjectContainer container) : base(container)
        {
        }
    }
}
