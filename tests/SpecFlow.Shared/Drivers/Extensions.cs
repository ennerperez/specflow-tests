#if APPIUM && !ANDROID && !IOS

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Shared.Drivers
{

    [DebuggerStepThrough]
    public static class Extensions
    {
        public static IWebElement FindElement(this RemoteWebDriver @this, string by, string value) => FindElementBy(@this, values: new[] {by, value});
        public static IWebElement FindElementByAccessibilityId(this RemoteWebDriver @this, string selector) => FindElementBy(@this, values: new[] {selector});
        public static IWebElement FindElementByClassName(this RemoteWebDriver @this, string className) => FindElementBy(@this, values: new[] {className});
        public static IWebElement FindElementByCssSelector(this RemoteWebDriver @this, string cssSelector) => FindElementBy(@this, values: new[] {cssSelector});
        public static IWebElement FindElementById(this RemoteWebDriver @this, string id) => FindElementBy(@this, values: new[] {id});
        public static IWebElement FindElementByImage(this RemoteWebDriver @this, string base64Template) => FindElementBy(@this, values: new[] {base64Template});
        public static IWebElement FindElementByLinkText(this RemoteWebDriver @this, string linkText) => FindElementBy(@this, values: new[] {linkText});
        public static IWebElement FindElementByName(this RemoteWebDriver @this, string name) => FindElementBy(@this, values: new[] {name});
        public static IWebElement FindElementByPartialLinkText(this RemoteWebDriver @this, string partialLinkText) => FindElementBy(@this, values: new[] {partialLinkText});
        public static IWebElement FindElementByTagName(this RemoteWebDriver @this, string tagName) => FindElementBy(@this, values: new[] {tagName});
        public static IWebElement FindElementByXPath(this RemoteWebDriver @this, string xpath) => FindElementBy(@this, values: new[] {xpath});
        public static IReadOnlyCollection<IWebElement> FindElements(this RemoteWebDriver @this, By by) => FindElementsBy(@this, values: new[] {by});
        public static IReadOnlyCollection<IWebElement> FindElements(this RemoteWebDriver @this, string selector, string value) => FindElementsBy(@this, values: new[] {selector, value});
        public static IReadOnlyCollection<IWebElement> FindElementsByAccessibilityId(this RemoteWebDriver @this, string selector) => FindElementsBy(@this, values: new[] {selector});
        public static IReadOnlyCollection<IWebElement> FindElementsByClassName(this RemoteWebDriver @this, string className) => FindElementsBy(@this, values: new[] {className});
        public static IReadOnlyCollection<IWebElement> FindElementsByCssSelector(this RemoteWebDriver @this, string cssSelector) => FindElementsBy(@this, values: new[] {cssSelector});
        public static IReadOnlyCollection<IWebElement> FindElementsById(this RemoteWebDriver @this, string id) => FindElementsBy(@this, values: new[] {id});
        public static IReadOnlyCollection<IWebElement> FindElementsByImage(this RemoteWebDriver @this, string base64Template) => FindElementsBy(@this, values: new[] {base64Template});
        public static IReadOnlyCollection<IWebElement> FindElementsByLinkText(this RemoteWebDriver @this, string linkText) => FindElementsBy(@this, values: new[] {linkText});
        public static IReadOnlyCollection<IWebElement> FindElementsByName(this RemoteWebDriver @this, string name) => FindElementsBy(@this, values: new[] {name});
        public static IReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(this RemoteWebDriver @this, string partialLinkText) => FindElementsBy(@this, values: new[] {partialLinkText});
        public static IReadOnlyCollection<IWebElement> FindElementsByTagName(this RemoteWebDriver @this, string tagName) => FindElementsBy(@this, values: new[] {tagName});
        public static IReadOnlyCollection<IWebElement> FindElementsByXPath(this RemoteWebDriver @this, string xpath) => FindElementsBy(@this, values: new[] {xpath});

        public static string GetClipboard(this RemoteWebDriver @this, ClipboardContentType contentType) => InvokeMethod<string>(@this, values: new[] {contentType});
        public static Image GetClipboardImage(this RemoteWebDriver @this) => InvokeMethod<Image>(@this);
        public static string GetClipboardText(this RemoteWebDriver @this) => InvokeMethod<string>(@this);
        public static string GetClipboardUrl(this RemoteWebDriver @this) => InvokeMethod<string>(@this);
        public static bool IsLocked(this RemoteWebDriver @this) => InvokeMethod<bool>(@this);
        public static void Lock(this RemoteWebDriver @this) => InvokeMethod(@this);
        public static void SetClipboard(this RemoteWebDriver @this, ClipboardContentType contentType, string base64Content) => InvokeMethod(@this, values: new object[] {contentType, base64Content});
        public static void SetClipboardImage(this RemoteWebDriver @this, Image image) => InvokeMethod(@this, values: new[] {image});
        public static void SetClipboardText(this RemoteWebDriver @this, string textContent, string label = null) => InvokeMethod(@this, values: new[] {textContent, label});
        public static void SetClipboardUrl(this RemoteWebDriver @this, string url) => InvokeMethod(@this, values: new[] {url});
        public static void Unlock(this RemoteWebDriver @this) => InvokeMethod(@this);

        #region AndroidDriver

        public static IWebElement FindElementByAndroidDataMatcher(this RemoteWebDriver @this, string selector) => FindElementBy(@this, values: new[] {selector});
        public static IWebElement FindElementByAndroidUIAutomator(this RemoteWebDriver @this, IUiAutomatorStatementBuilder selector) => FindElementBy(@this, values: new[] {selector});
        public static IWebElement FindElementByAndroidUIAutomator(this RemoteWebDriver @this, string selector) => FindElementBy(@this, values: new[] {selector});
        public static IWebElement FindElementByAndroidViewMatcher(this RemoteWebDriver @this, string selector) => FindElementBy(@this, values: new[] {selector});
        public static IReadOnlyCollection<IWebElement> FindElementsByAndroidDataMatcher(this RemoteWebDriver @this, string selector) => FindElementsBy(@this, values: new[] {selector});
        public static IReadOnlyCollection<IWebElement> FindElementsByAndroidUIAutomator(this RemoteWebDriver @this, IUiAutomatorStatementBuilder selector) => FindElementsBy(@this, values: new[] {selector});
        public static IReadOnlyCollection<IWebElement> FindElementsByAndroidUIAutomator(this RemoteWebDriver @this, string selector) => FindElementsBy(@this, values: new[] {selector});
        public static IReadOnlyCollection<IWebElement> FindElementsByAndroidViewMatcher(this RemoteWebDriver @this, string selector) => FindElementsBy(@this, values: new[] {selector});

        public static void ConfiguratorSetActionAcknowledgmentTimeout(this RemoteWebDriver @this, int timeout) => InvokeMethod(@this, values: new[] {timeout});
        public static void ConfiguratorSetKeyInjectionDelay(this RemoteWebDriver @this, int delay) => InvokeMethod(@this, values: new[] {delay});
        public static void ConfiguratorSetScrollAcknowledgmentTimeout(this RemoteWebDriver @this, int timeout) => InvokeMethod(@this, values: new[] {timeout});
        public static void ConfiguratorSetWaitForIdleTimeout(this RemoteWebDriver @this, int timeout) => InvokeMethod(@this, values: new[] {timeout});
        public static void ConfiguratorSetWaitForSelectorTimeout(this RemoteWebDriver @this, int timeout) => InvokeMethod(@this, values: new[] {timeout});

        public static float GetDisplayDensity(this RemoteWebDriver @this) => InvokeMethod<float>(@this);
        public static void LongPressKeyCode(this RemoteWebDriver @this, int keyCode, int metastate = -1) => InvokeMethod(@this, values: new[] {keyCode, metastate});
        public static void LongPressKeyCode(this RemoteWebDriver @this, KeyEvent keyEvent) => InvokeMethod(@this, values: new[] {keyEvent});
        public static void OpenNotifications(this RemoteWebDriver @this) => InvokeMethod(@this);
        public static void PressKeyCode(this RemoteWebDriver @this, int keyCode, int metastate = -1) => InvokeMethod(@this, values: new[] {keyCode, metastate});
        public static void PressKeyCode(this RemoteWebDriver @this, KeyEvent keyEvent) => InvokeMethod(@this, values: new[] {keyEvent});

        public static void SetSetting(this RemoteWebDriver @this, string setting, object value) => InvokeMethod(@this, values: new[] {setting, value});
        public static void StartActivity(this RemoteWebDriver @this, string appPackage, string appActivity, string appWaitPackage = "", string appWaitActivity = "", bool stopApp = true) => InvokeMethod(@this, values: new object[] {appPackage, appActivity, appWaitPackage, appWaitActivity, stopApp});
        public static void StartActivityWithIntent(this RemoteWebDriver @this, string appPackage, string appActivity, string intentAction, string appWaitPackage = "", string appWaitActivity = "", string intentCategory = "", string intentFlags = "", string intentOptionalArgs = "", bool stopApp = true) => InvokeMethod(@this, values: new object[] {appPackage, appActivity, intentAction, appWaitPackage, appWaitActivity, intentCategory, intentFlags, intentOptionalArgs, stopApp});
        public static void ToggleAirplaneMode(this RemoteWebDriver @this) => InvokeMethod(@this);
        public static void ToggleData(this RemoteWebDriver @this) => InvokeMethod(@this);
        public static void ToggleLocationServices(this RemoteWebDriver @this) => InvokeMethod(@this);
        public static void ToggleWifi(this RemoteWebDriver @this) => InvokeMethod(@this);

        #endregion

        #region IOSDriver

        public static IWebElement FindElementByIosClassChain(this RemoteWebDriver @this, string selector) => FindElementBy(@this, values: new[] {selector});
        public static IWebElement FindElementByIosNsPredicate(this RemoteWebDriver @this, string selector) => FindElementBy(@this, values: new[] {selector});
        public static IWebElement FindElementByIosUIAutomation(this RemoteWebDriver @this, string selector) => FindElementBy(@this, values: new[] {selector});
        public static IReadOnlyCollection<IWebElement> FindElementsByIosClassChain(this RemoteWebDriver @this, string selector) => FindElementsBy(@this, values: new[] {selector});
        public static IReadOnlyCollection<IWebElement> FindElementsByIosNsPredicate(this RemoteWebDriver @this, string selector) => FindElementsBy(@this, values: new[] {selector});
        public static IReadOnlyCollection<IWebElement> FindElementsByIosUIAutomation(this RemoteWebDriver @this, string selector) => FindElementsBy(@this, values: new[] {selector});


        public static void HideKeyboard(this RemoteWebDriver @this, string key, string strategy = null) => InvokeMethod(@this, values: new[] {key, strategy});
        public static void Lock(this RemoteWebDriver @this, int seconds) => InvokeMethod(@this, values: new[] {seconds});
        public static void PerformTouchID(this RemoteWebDriver @this, bool match) => InvokeMethod(@this, values: new[] {match});
        public static void ShakeDevice(this RemoteWebDriver @this) => InvokeMethod(@this);

        #endregion

        private static void InvokeMethod(RemoteWebDriver @this, [CallerMemberName] string method = "", params object[] values)
        {
            var methods = @this.GetType().GetMethods().Where(m => m.Name == method);
            if (methods == null || !methods.Any()) throw new NotImplementedException(method);
            foreach (var item in methods)
            {
                try
                {
                    item.Invoke(@this, values);
                    break;
                }
                catch (Exception)
                {
                    // ignore
                }
            }
        }

        private static T InvokeMethod<T>(RemoteWebDriver @this, [CallerMemberName] string method = "", params object[] values)
        {
            var result = default(T);
            var methods = @this.GetType().GetMethods().Where(m => m.Name == method);
            if (methods == null || !methods.Any()) throw new NotImplementedException(method);
            foreach (var item in methods)
            {
                try
                {
                    result = (T) item.Invoke(@this, values);
                    break;
                }
                catch (Exception)
                {
                    // ignore
                }
            }

            return result;
        }

        private static IWebElement FindElementBy(RemoteWebDriver @this, [CallerMemberName] string method = "", params object[] values)
        {
            return InvokeMethod<IWebElement>(@this, method, values);
        }

        private static IReadOnlyCollection<IWebElement> FindElementsBy(RemoteWebDriver @this, [CallerMemberName] string method = "", params object[] values)
        {
            return InvokeMethod<IReadOnlyCollection<IWebElement>>(@this, method, values);
        }
    }

}

#endif