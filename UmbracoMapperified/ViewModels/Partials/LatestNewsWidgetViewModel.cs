namespace TxtStarter.ViewModels.Partials
{
    using System;
    using System.Collections.Generic;
    using Zone.UmbracoMapper;

    public class LatestNewsWidgetViewModel
    {
        public LatestNewsWidgetViewModel()
        {
            NewsItems = new List<NewsItem>();
        }

        public IList<NewsItem> NewsItems { get; set; }

        [PropertyMapping(SourceProperty = "Url")]
        public string NewsOverviewUrl { get; set; }

        public class NewsItem
        {
            [PropertyMapping(SourcePropertiesForCoalescing = new [] { "title", "Name" })]
            public string Title { get; set; }

            public string Url { get; set; }

            [PropertyMapping(SourcePropertiesForCoalescing = new[] { "publishDate", "CreateDate" })]
            public DateTime DateTime { get; set; }
        }
    }
}