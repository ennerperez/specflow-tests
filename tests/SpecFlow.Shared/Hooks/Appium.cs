#if APPIUM
using System.IO;
using BoDi;
using Microsoft.Extensions.Configuration;
using Shared.Drivers.Interfaces;
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

            Container.RegisterInstanceAs(Configuration);
#if ANDROID
            Container.RegisterInstanceAs<IDriverService>(new Drivers.AndroidDriver(Configuration));
#elif IOS
            Container.RegisterInstanceAs<IDriverService>(new Drivers.iOSDriver(Configuration));
#elif WEB
            Container.RegisterInstanceAs<IDriverService>(new Drivers.WebDriver(Configuration));
#else
            var platform = Configuration["AppSettings:Platform"];
            if (platform == "Android")
            {
                Container.RegisterInstanceAs<IDriverService>(new Drivers.AndroidDriver(Configuration));
            }
            else if (platform == "iOS")
            {
                Container.RegisterInstanceAs<IDriverService>(new Drivers.iOSDriver(Configuration));
            }
            else if (platform == "Web")
            {
                Container.RegisterInstanceAs<IDriverService>(new Drivers.WebDriver(Configuration));
            }
#endif
            Container.Resolve<IDriverService>().StartApp();


        }
        [AfterScenario]
        public void AfterScenario()
        {
            Container.Resolve<IDriverService>().ShutdownApp();
        }

    }
}
#endif
