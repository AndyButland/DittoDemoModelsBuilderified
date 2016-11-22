namespace TxtStarter.ViewModels.Pages
{
    using System.Web;
    using Zone.UmbracoMapper;

    public class TextPageViewModel : BasePageViewModel
    {
        [PropertyMapping(SourceProperty = "image")]
        public string ImageUrl { get; set; }

        public IHtmlString BodyText { get; set; }
    }
}