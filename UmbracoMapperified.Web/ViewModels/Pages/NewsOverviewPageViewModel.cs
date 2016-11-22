namespace UmbracoMapperified.Web.ViewModels.Pages
{
    using System;
    using Zone.UmbracoMapper;

    public class NewsOverviewPageViewModel : BasePageViewModel
    {
        public NewsOverviewPageViewModel()
        {
            NewsItemsPage = new PagedCollection<NewsItem>();
        }

        public PagedCollection<NewsItem> NewsItemsPage { get; set; }

        public class NewsItem
        {
            [PropertyMapping(SourcePropertiesForCoalescing = new [] { "title", "Name" })]
            public string Title { get; set; }

            [PropertyMapping(SourcePropertiesForCoalescing = new[] { "publishDate", "CreateDate" })]
            public DateTime PublishDate { get; set; }

            public string Url { get; set; }

            public string SubHeader { get; set; }

            [PropertyMapping(SourceProperty = "image")]
            public string ImageUrl { get; set; }

            public string TruncatedBodyText { get; set; }
        }
    }
}