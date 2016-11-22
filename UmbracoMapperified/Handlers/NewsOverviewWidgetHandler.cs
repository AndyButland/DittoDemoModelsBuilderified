namespace TxtStarter.Handlers
{
    using System.Linq;
    using TxtStarter.Helpers;
    using TxtStarter.Infrastructure.Handlers;
    using TxtStarter.ViewModels.Partials;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Handler for mapping the <see cref="NewsOverviewWidgetViewModel"/> partial view model
    /// </summary>
    public class NewsOverviewWidgetHandler : BaseHandler, IHandler<NewsOverviewWidgetViewModel>
    {
        public NewsOverviewWidgetHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        public NewsOverviewWidgetHandler(IUmbracoMapper mapper, IPublishedContent rootNode)
            : base(mapper, rootNode)
        {
        }

        /// <summary>
        /// Processes the mapping from the content to to the partial page view model
        /// </summary>
        /// <param name="to">Partial page view model to map to</param>
        public void Handle(NewsOverviewWidgetViewModel to)
        {
            var newsOverviewPage = GetNewsOverviewPage();
            if (newsOverviewPage == null)
            {
                return;
            }

            Mapper.Map(newsOverviewPage, to);

            var mostRecentNewsItem = GetMostRecentNewsItem(newsOverviewPage);
            if (mostRecentNewsItem == null)
            {
                return;
            }

            to.FeaturedItem = new NewsOverviewWidgetViewModel.FeaturedNewsItem();
            Mapper.Map(mostRecentNewsItem, to.FeaturedItem, TruncatedBodyTextMappingForNewsPage());
        }

        /// <summary>
        /// Helper to get the most recent news item
        /// </summary>
        private IPublishedContent GetMostRecentNewsItem(IPublishedContent newsOverviewPage)
        {
            return newsOverviewPage.Descendants("umbNewsItem")
                .MostRecent()
                .FirstOrDefault();
        }
    }
}
