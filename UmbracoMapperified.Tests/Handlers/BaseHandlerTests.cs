namespace UmbracoMapperified.Tests.Handlers
{
    using System.Linq;
    using System.Web;
    using Moq;
    using Umbraco.Core;
    using Umbraco.Core.Configuration.UmbracoSettings;
    using Umbraco.Core.Logging;
    using Umbraco.Core.Profiling;
    using Umbraco.Web;
    using Umbraco.Web.Routing;
    using Umbraco.Web.Security;

    public abstract class BaseHandlerTests
    {
        public virtual void Initialize()
        {
            var applicationContext = new ApplicationContext(
                CacheHelper.CreateDisabledCacheHelper(),
                new ProfilingLogger(Mock.Of<ILogger>(), Mock.Of<IProfiler>())
            );
            UmbracoContext.EnsureContext(
                Mock.Of<HttpContextBase>(),
                applicationContext,
                new WebSecurity(Mock.Of<HttpContextBase>(), applicationContext),
                Mock.Of<IUmbracoSettingsSection>(),
                Enumerable.Empty<IUrlProvider>(),
                true
            );
        }
    }
}
