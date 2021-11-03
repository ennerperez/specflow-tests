#if XAMARIN_UITEST
using System.IO;
using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace Shared.Hooks
{
    public abstract class Generic
    {
        protected readonly IObjectContainer Container;
        protected readonly IConfiguration Configuration;

        public Generic(IObjectContainer container)
        {
            Container = container;
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine("appsettings.json"), false, true)
#if DEBUG
                .AddJsonFile(Path.Combine("appsettings.Development.json"), false, true)
#endif
                .Build();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}
#endif
