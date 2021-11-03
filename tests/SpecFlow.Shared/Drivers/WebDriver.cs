#if APPIUM
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Remote;
using Shared.Drivers.Interfaces;

namespace Shared.Drivers
{
    public sealed class WebDriver : IDriverService
    {
        public RemoteWebDriver Driver { get; private set; }

        private readonly IConfiguration _configuration;

        public WebDriver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void StartApp()
        {
            var appUrl = _configuration["Web:RemoteAddress"];
            var apiumUrl = _configuration["Web:AppiumServer"];

            var driverOptions = new AppiumOptions();

            var capabilities = _configuration.GetSection("Web:Capabilities").Get<Dictionary<string, string>>();
            foreach (var item in capabilities)
            {
                object value = item.Value;
                if (new[] {"true", "false"}.Contains(item.Value.ToLower())) value = bool.Parse(item.Value);
                driverOptions.AddAdditionalCapability(item.Key, value);
            }
            
            Driver = new RemoteWebDriver(new Uri(apiumUrl), driverOptions);
            
            Driver.Navigate().GoToUrl(new Uri(appUrl));
            
        }

        public void ShutdownApp()
        {
            Driver.Quit();
        }
    }
}
#endif
