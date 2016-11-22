namespace UmbracoMapperified.Web.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using UmbracoMapperified.Web.Infrastructure.Handlers;
    using UmbracoMapperified.Web.ViewModels;
    using UmbracoMapperified.Web.ViewModels.Pages;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;

    public class NewsOverviewPageHandler : BaseHandler, IHandler<IPublishedContent, NewsOverviewPageViewModel, PagingDetail>
    {
        /// <summary>
        /// Handler for mapping news overview page instances to the news overview page view model
        /// </summary>
        public NewsOverviewPageHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        /// <summary>
        /// Processes the mapping from the source page to the page view model
        /// </summary>
        /// <param name="source">Current page as <see cref="IPublishedContent"/></param>
        /// <param name="to">Page view model to map to</param>
        /// <param name="data">Page number and size details</param>
        public void Handle(IPublishedContent source, NewsOverviewPageViewModel to, PagingDetail data)
        {
            Mapper.Map(source, to);

            var newsItems = GetAllNewsItems(source);

            MapPageOfNewsItems(newsItems, to, data);
        }

        /// <summary>
        /// Helper to retieve all news items
        /// </summary>
        /// <param name="source">Instance of news overview page</param>
        /// <returns>List of news content items</returns>
        private IList<IPublishedContent> GetAllNewsItems(IPublishedContent source)
        {
            return source.Descendants("umbNewsItem")
                .ToList();
        }

        /// <summary>
        /// Helper to map a page of news items
        /// </summary>
        /// <param name="newsItems">List of news content items</param>
        /// <param name="to">Page view model to map to</param>
        /// <param name="pagingDetail">Page number and size details</param>
        private void MapPageOfNewsItems(IList<IPublishedContent> newsItems, NewsOverviewPageViewModel to, PagingDetail pagingDetail)
        {
            IEnumerable<IPublishedContent> pagedItems;
            to.NewsItemsPage = CreatePagedCollection<NewsOverviewPageViewModel.NewsItem>(newsItems, pagingDetail, out pagedItems);
            Mapper.MapCollection(pagedItems, to.NewsItemsPage.Items, TruncatedBodyTextMappingForNewsPage());
        }
    }
}
