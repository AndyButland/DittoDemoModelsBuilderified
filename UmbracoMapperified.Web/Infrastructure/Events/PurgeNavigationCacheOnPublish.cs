namespace UmbracoMapperified.Web.Infrastructure.Events
{
    using System.Linq;
    using Umbraco.Core;
    using Umbraco.Core.Events;
    using Umbraco.Core.Models;
    using Umbraco.Core.Publishing;
    using Umbraco.Core.Services;

    public class PurgeNavigationCacheOnPublish : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentService.Published += ContentServicePublished;
        }

        private void ContentServicePublished(IPublishingStrategy sender, PublishEventArgs<IContent> args)
        {
            if (args.PublishedEntities.Any(IsNavigationItem))
            {
                ClearNavigationCache();
            }
        }

        private static bool IsNavigationItem(IContent node)
        {
            return node.Level == 2;
        }

        private void ClearNavigationCache()
        {
            ApplicationContext.Current.ApplicationCache.RuntimeCache.ClearCacheByKeySearch("Navigation_");
        }
    }
}