namespace TxtStarter.ViewModels.Partials
{
    using System;
    using Zone.UmbracoMapper;

    public class NewsOverviewWidgetViewModel
    {
        public string Title { get; set; }

        public FeaturedNewsItem FeaturedItem { get; set; }

        public class FeaturedNewsItem
        {
            public string Title { get; set; }

            public string SubHeader { get; set; }

            [PropertyMapping(SourcePropertiesForCoalescing = new[] { "publishDate", "CreateDate" })]
            public DateTime DateTime { get; set; }

            [PropertyMapping(SourceProperty = "image")]
            public string ImageUrl { get; set; }

            public string Url { get; set; }

            public string TruncatedBodyText { get; set; }
        }
    }
}