namespace UmbracoMapperified.Web.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using UmbracoMapperified.Web.Helpers;
    using UmbracoMapperified.Web.Infrastructure.Handlers;
    using UmbracoMapperified.Web.ViewModels;
    using UmbracoMapperified.Web.ViewModels.Partials;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Handler for mapping the <see cref="LatestNewsWidgetViewModel"/> partial view model
    /// </summary>
    public class LatestNewsWidgetHandler : BaseHandler, IHandler<LatestNewsWidgetViewModel>
    {
        public LatestNewsWidgetHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        public LatestNewsWidgetHandler(IUmbracoMapper mapper, IPublishedContent rootNode)
            : base(mapper, rootNode)
        {
        }

        /// <summary>
        /// Processes the mapping from the content to to the partial page view model
        /// </summary>
        /// <param name="to">Partial page view model to map to</param>
        public void Handle(LatestNewsWidgetViewModel to)
        {
            var newsOverviewPage = GetNewsOverviewPage();

            if (newsOverviewPage == null)
            {
                return;
            }

            Mapper.Map(newsOverviewPage, to);

            var newsItems = GetLatestNewsItems(newsOverviewPage);

            Mapper.MapCollection(newsItems, to.NewsItems);
        }

        /// <summary>
        /// Helper to retrieve the latest news items
        /// </summary>
        /// <param name="newsOverviewPage">News overview page instance</param>
        /// <returns>List of latest news content items</returns>
        private static IEnumerable<IPublishedContent> GetLatestNewsItems(IPublishedContent newsOverviewPage)
        {
            return newsOverviewPage.Descendants("umbNewsItem")
                .MostRecent(5)
                .ToList();
        }
    }
}
