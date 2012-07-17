using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;

namespace ServiceLocatorPattern
{
    public static class ServiceProviderLocatorFacts
    {
        [TestClass]
        public class TheSetProviderMethod
        {
            [TestMethod]
            public void ThrowsArgumentNullException_WhenArgIsNull()
            {
                ArgumentNullException exception = null;
                try
                {
                    ServiceProviderLocator.SetProvider(null);
                }
                catch (ArgumentNullException ex)
                {
                    exception = ex;
                }

                exception.ShouldNotBeNull();
                // ReSharper disable PossibleNullReferenceException
                exception.ParamName.ShouldEqual("serviceProvider");
                // ReSharper restore PossibleNullReferenceException
            }

            [TestMethod]
            public void SetsCurrentProperty_ToNonNullArg()
            {
                var serviceProvider = new Mock<IServiceProvider>();
                ServiceProviderLocator.SetProvider(serviceProvider.Object);
                ServiceProviderLocator.Current.ShouldNotBeNull();
                ServiceProviderLocator.Current.ShouldEqual(serviceProvider.Object);
                ServiceProviderLocator.ClearProvider();
            }
        }

        [TestClass]
        public class TheClearProviderMethod
        {
            [TestMethod]
            public void SetsCurrentProperty_ToNull()
            {
                var serviceProvider = new Mock<IServiceProvider>();
                ServiceProviderLocator.SetProvider(serviceProvider.Object);
                ServiceProviderLocator.Current.ShouldNotBeNull();
                ServiceProviderLocator.Current.ShouldEqual(serviceProvider.Object);
                ServiceProviderLocator.ClearProvider();
                ServiceProviderLocator.Current.ShouldBeNull();
            }
        }

        [TestClass]
        public class TheCurrentProperty
        {
            [TestMethod]
            public void ReturnsNull_WhenNotSet()
            {
                ServiceProviderLocator.Current.ShouldBeNull();
            }

            [TestMethod]
            public void ReturnsServiceProvider_WhenSet()
            {
                var serviceProvider = new Mock<IServiceProvider>();
                ServiceProviderLocator.SetProvider(serviceProvider.Object);
                ServiceProviderLocator.Current.ShouldNotBeNull();
                ServiceProviderLocator.Current.ShouldEqual(serviceProvider.Object);
                ServiceProviderLocator.ClearProvider();
            }
        }
    }
}
