namespace TxtStarter.Handlers
{
    using TxtStarter.Infrastructure.Handlers;
    using TxtStarter.ViewModels;
    using TxtStarter.ViewModels.Pages;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Handler for mapping news item page instances to the news item page view model
    /// </summary>
    public class NewsItemPageHandler : BaseHandler, IHandler<IPublishedContent, NewsItemPageViewModel>
    {
        public NewsItemPageHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        /// <summary>
        /// Processes the mapping from the source page to the page view model
        /// </summary>
        /// <param name="source">Current page as <see cref="IPublishedContent"/></param>
        /// <param name="to">Page view model to map to</param>
        public void Handle(IPublishedContent source, NewsItemPageViewModel to)
        {
            Mapper.Map(source, to);
        }
    }
}
