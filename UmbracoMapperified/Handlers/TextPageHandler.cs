namespace TxtStarter.Handlers
{
    using TxtStarter.Infrastructure.Handlers;
    using TxtStarter.ViewModels.Pages;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Handler for mapping text page instances to the text page view model
    /// </summary>
    public class TextPageHandler : BaseHandler, IHandler<IPublishedContent, TextPageViewModel>
    {
        public TextPageHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        /// <summary>
        /// Processes the mapping from the source page to the page view model
        /// </summary>
        /// <param name="source">Current page as <see cref="IPublishedContent"/></param>
        /// <param name="to">Page view model to map to</param>
        public void Handle(IPublishedContent source, TextPageViewModel to)
        {
            Mapper.Map(source, to);
        }
    }
}
