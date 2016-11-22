namespace UmbracoMapperified.Web.ViewModels.Pages
{
    using System.Web;
    using Zone.UmbracoMapper;

    public class NewsItemPageViewModel : BasePageViewModel
    {
        [PropertyMapping(SourceProperty = "image")]
        public string ImageUrl { get; set; }

        public IHtmlString BodyText { get; set; }
    }
}