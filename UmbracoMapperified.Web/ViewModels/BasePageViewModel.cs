namespace UmbracoMapperified.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Web;
    using Zone.UmbracoMapper;

    public abstract class BasePageViewModel : BaseNodeViewModel
    {
        private string _title;

        public string Title
        {
            get
            {
                return string.IsNullOrEmpty(_title) ? Name : _title;
            }

            set
            {
                _title = value;
            }
        }

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
