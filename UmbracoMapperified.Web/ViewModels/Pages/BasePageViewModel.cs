namespace UmbracoMapperified.Web.ViewModels.Pages
{
    using System.Collections.Generic;
    using System.Web;
    using Zone.UmbracoMapper;

    public abstract class BasePageViewModel : BaseNodeViewModel
    {
        [PropertyMapping(SourcePropertiesForCoalescing = new[] { "title", "Name" })]
        public string Title { get; set; }

        [PropertyMapping(MapRecursively = true)]
        public string SiteName { get; set; }

        [PropertyMapping(SourceProperty = "byline", MapRecursively = true)]
        public string ByLine { get; set; }

        public IEnumerable<MenuItem> TopNavigationItems { get; set; }

        [PropertyMapping(MapRecursively = true)]
        public string AboutTitle { get; set; }

        [PropertyMapping(MapRecursively = true)]
        public IHtmlString AboutText { get; set; }

        [PropertyMapping(MapRecursively = true)]
        public string Copyright { get; set; }
    }
}
