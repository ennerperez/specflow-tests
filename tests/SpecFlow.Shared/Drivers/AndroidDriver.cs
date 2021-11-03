#if APPIUM && (ANDROID || (!ANDROID && ! IOS))

using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shared.Drivers.Interfaces;

#if !ANDROID
using OpenQA.Selenium.Remote;
#endif

namespace Shared.Drivers
{
    public sealed class AndroidDriver : IDriverService
    {
#if ANDROID
        public AndroidDriver<AndroidElement> Driver { get; private set; }
#else
        public RemoteWebDriver Driver { get; private set; }
#endif

        private readonly IConfiguration _configuration;

        public AndroidDriver(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void StartApp()
        {
            var appPath = _configuration["Android:RemoteFilePath"];
            var apiumUrl = _configuration["Android:AppiumServer"];

            if (appPath.Contains(".."))
                appPath = Path.Combine(Directory.GetCurrentDirectory(), appPath);

            var driverOptions = new AppiumOptions();

            var capabilities = _configuration.GetSection("Android:Capabilities").Get<Dictionary<string, string>>();
            foreach (var item in capabilities)
            {
                object value = item.Value;
                if (new[] {"true", "false"}.Contains(item.Value.ToLower())) value = bool.Parse(item.Value);
                driverOptions.AddAdditionalCapability(item.Key, value);
            }

            driverOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, appPath);

            Driver = new AndroidDriver<AndroidElement>(new Uri(apiumUrl), driverOptions, TimeSpan.FromSeconds(60));
        }

        public void ShutdownApp()
        {
            Driver.Quit();
        }
    }
}
#endif
