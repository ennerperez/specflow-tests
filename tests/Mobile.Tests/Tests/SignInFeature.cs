#if XAMARIN_UITEST
#if NUNIT
using NUnit.Framework;
#endif

using Xamarin.UITest;

namespace Mobile.Tests.Features
{
#if NUNIT
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
#endif
    public partial class SignInFeature : Shared.Tests.Generic
    {
        public SignInFeature(Platform platform) : base(platform)
        {
        }
    }
}
#endif
