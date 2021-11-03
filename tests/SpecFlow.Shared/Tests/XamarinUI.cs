#if XAMARIN_UITEST
using NUnit.Framework;
using Xamarin.UITest;

namespace Shared.Tests
{
    public abstract class Generic
    {
        public Generic(Platform platform)
        {
            Initializer.Platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Initializer.StartApp();
        }
    }
}
#endif
