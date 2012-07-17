using System;

namespace ServiceLocatorPattern
{
    public static class ServiceProviderLocator
    {
        public static void SetProvider(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");
            Current = serviceProvider;
        }

        public static void ClearProvider()
        {
            Current = null;
        }

        public static IServiceProvider Current { get; private set; }
    }
}
