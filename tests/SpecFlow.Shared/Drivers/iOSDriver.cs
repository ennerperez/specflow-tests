#if APPIUM && (IOS || (!ANDROID && ! IOS))

using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shared.Drivers.Interfaces;

#if !OS
using OpenQA.Selenium.Remote;
#endif

namespace Shared.Drivers
{
    // ReSharper disable once InconsistentNaming
    public sealed class iOSDriver : IDriverService
    {
#if IOS
        public IOSDriver<IOSElement> Driver { get; private set; }
#else
        public RemoteWebDriver Driver { get; private set; }
#endif
        private readonly IConfiguration _configuration;

        public iOSDriver(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void StartApp()
        {
            var appPath = _configuration["iOS:RemoteFilePath"];
            var apiumUrl = _configuration["iOS:AppiumServer"];

            if (appPath.Contains(".."))
                appPath = Path.Combine(Directory.GetCurrentDirectory(), appPath);

            var driverOptions = new AppiumOptions();

            var capabilities = _configuration.GetSection("iOS:Capabilities").Get<Dictionary<string, string>>();
            foreach (var item in capabilities)
            {
                object value = item.Value;
                if (new[] {"true", "false"}.Contains(item.Value.ToLower())) value = bool.Parse(item.Value);
                driverOptions.AddAdditionalCapability(item.Key, value);
            }

            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, appPath);
            driverOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
            driverOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");

            Driver = new IOSDriver<IOSElement>(new Uri(apiumUrl), driverOptions, TimeSpan.FromSeconds(60));
        }

        public void ShutdownApp()
        {
            Driver.Quit();
        }
    }
}
#endif
