namespace UmbracoMapperified.Web.Handlers
{
    using UmbracoMapperified.Web.Infrastructure.Handlers;
    using UmbracoMapperified.Web.ViewModels;
    using UmbracoMapperified.Web.ViewModels.Pages;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Handler for mapping home page instances to the home page view model
    /// </summary>
    public class HomePageHandler : BaseHandler, IHandler<IPublishedContent, HomePageViewModel>
    {
        public HomePageHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        /// <summary>
        /// Processes the mapping from the source page to the page view model
        /// </summary>
        /// <param name="source">Current page as <see cref="IPublishedContent"/></param>
        /// <param name="to">Page view model to map to</param>
        public void Handle(IPublishedContent source, HomePageViewModel to)
        {
            Mapper.Map(source, to);
        }
    }
}
