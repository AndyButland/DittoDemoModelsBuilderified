namespace UmbracoMapperified.Web.ViewModels.Pages
{
    using Zone.UmbracoMapper;

    public class HomePageViewModel : BasePageViewModel
    {
        public bool HideBanner { get; set; }

        public string BannerHeader { get; set; }

        public string BannerSubheader { get; set; }

        [PropertyMapping(SourceProperty = "bannerBackgroundImage")]
        public string BannerBackgroundImageUrl { get; set; }
        
        [PropertyMapping(SourceProperty = "bannerLink", SourceRelatedProperty = "Url")]
        public string BannerLinkUrl { get; set; }

        public string BannerLinkText { get; set; }
    }
}