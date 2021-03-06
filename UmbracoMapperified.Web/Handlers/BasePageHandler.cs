﻿namespace UmbracoMapperified.Web.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UmbracoMapperified.Web.Infrastructure.Handlers;
    using UmbracoMapperified.Web.ViewModels;
    using Umbraco.Core;
    using Umbraco.Core.Models;
    using Umbraco.Core.Cache;
    using Umbraco.Web;
    using UmbracoMapperified.Web.ViewModels.Pages;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Handler used for mapping all pages to common properties found on all page view models
    /// </summary>
    public class BasePageHandler : BaseHandler, IHandler<IPublishedContent, BasePageViewModel>
    {
        public BasePageHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        /// <summary>
        /// Processes the mapping from the source page to the base page view model
        /// </summary>
        /// <param name="source">Current page as <see cref="IPublishedContent"/></param>
        /// <param name="to">Base page view model to map to</param>
        public void Handle(IPublishedContent source, BasePageViewModel to)
        {
            if (RootNode == null)
            {
                return;
            }

            to.TopNavigationItems = ApplicationContext.Current.ApplicationCache.RuntimeCache
                .GetCacheItem<IList<MenuItem>>($"Navigation_{source.Id}",
                    () => GetNavigationItems(source), TimeSpan.FromSeconds(60));
        }

        public class MyObject
        {
            
        }

        /// <summary>
        /// Helper to map the top level navigation items
        /// </summary>
        /// <param name="source">Current page as <see cref="IPublishedContent"/></param>
        /// <returns>Navigation structure</returns>
        private IList<MenuItem> GetNavigationItems(IPublishedContent source)
        {
            var navItems = new List<MenuItem>();

            MapHomePageNavigationItem(navItems);
            MapTopLevelNavigationItems(navItems);
            SetActiveNavItem(source, navItems);
            return navItems;
        }

        /// <summary>
        /// Helper to map the home link to the navigation items
        /// </summary>
        /// <param name="navItems">List of navigation items</param>
        private void MapHomePageNavigationItem(IList<MenuItem> navItems)
        {
            var homeNavItem = new MenuItem();
            Mapper.Map(RootNode, homeNavItem);
            navItems.Add(homeNavItem);
        }

        /// <summary>
        /// Helper to map the top level pages to the navigation items
        /// </summary>
        /// <param name="navItems">List of navigation items</param>
        private void MapTopLevelNavigationItems(IList<MenuItem> navItems)
        {
            var rootNodeChildren = RootNode.Children
                .Where(x => x.IsVisible())
                .ToList();
            Mapper.MapCollection(rootNodeChildren, navItems, clearCollectionBeforeMapping: false);
        }

        /// <summary>
        /// Helper to set which navigation item is active based on the current page
        /// </summary>
        /// <param name="source">Current page as <see cref="IPublishedContent"/></param>
        /// <param name="navItems">List of navigation items</param>
        private static void SetActiveNavItem(IPublishedContent source, IList<MenuItem> navItems)
        {
            navItems.ForEach(x => x.IsActive = x.Id == source.Id);
        }
    }
}
