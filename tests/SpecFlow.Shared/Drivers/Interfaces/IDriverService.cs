#if APPIUM
#if ANDROID
using OpenQA.Selenium.Appium.Android;
#elif IOS
using OpenQA.Selenium.Appium.iOS;
#endif
using OpenQA.Selenium.Remote;

namespace Shared.Drivers.Interfaces
{
    public interface IDriverService
    {
        void StartApp();
        void ShutdownApp();

#if ANDROID
        AndroidDriver<AndroidElement> Driver { get; }
#elif IOS
        IOSDriver<IOSElement> Driver { get; }
#else 
        RemoteWebDriver Driver { get; }
#endif
    }
}
#endif