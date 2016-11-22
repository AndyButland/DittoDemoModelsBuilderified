namespace UmbracoMapperified.Web.ViewModels.Partials
{
    using System.Collections.Generic;
    using Zone.UmbracoMapper;

    public class FeaturedPagesViewModel
    {
        public FeaturedPagesViewModel()
        {
            Pages = new List<FeaturedPage>();
        }

        public IList<FeaturedPage> Pages { get; set; }

        public class FeaturedPage
        {
            public string Name { get; set; }

            [PropertyMapping(SourceProperty = "image")]
            public string ImageUrl { get; set; }

            public string Url { get; set; }

            public string TruncatedBodyText { get; set; }
        }
    }
}