#if XAMARIN_UITEST
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Xamarin.UITest;

namespace Shared
{
    public abstract class Initializer
    {
        private static IApp s_app;
        public static IApp App
        {
            get
            {
                if (s_app == null)
                    throw new NullReferenceException("'App' not set. Call 'StartApp()' before trying to access it.");
                return s_app;
            }
        }

        private static Platform? s_platform;
        public static Platform Platform
        {
            get
            {
                if (s_platform == null)
                    throw new NullReferenceException("'Platform' not set.");
                return s_platform.Value;
            }

            set => s_platform = value;
        }

        private static IConfiguration s_configuration;
        public static IConfiguration Configuration{
            get
            {
                if (s_configuration == null)
                    throw new NullReferenceException("'Configuration' not set.");
                return s_configuration;
            }

            set => s_configuration = value;
        }

        public Initializer()
        {
            s_configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine("appsettings.json"), false, true)
#if DEBUG
                .AddJsonFile(Path.Combine("appsettings.Development.json"), false, true)
#endif
                .Build();
        }

        public static void StartApp()
        {
#if !ENABLE_TEST_CLOUD
            var apkFile = Configuration["Android:RemoteFilePath"];
            var ipaFile = Configuration["iOS:RemoteFilePath"];
#endif

            if (Platform == Platform.Android)
            {
                s_app = ConfigureApp
                    .Android
#if !ENABLE_TEST_CLOUD
                    .ApkFile(apkFile)
#endif
                    .StartApp();
            }
            else
            {
                s_app = ConfigureApp
                    .iOS
#if !ENABLE_TEST_CLOUD
                    .AppBundle(ipaFile)
#endif
                    .StartApp();
            }
        }
    }
}
#endif
