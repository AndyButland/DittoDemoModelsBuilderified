namespace TxtStarter.Handlers
{
    using TxtStarter.Infrastructure.Handlers;
    using TxtStarter.ViewModels.Partials;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Handler for mapping the <see cref="SocialLinksViewModel"/> partial view model
    /// </summary>
    public class SocialLinksHandler : BaseHandler, IHandler<SocialLinksViewModel>
    {
        public SocialLinksHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        public SocialLinksHandler(IUmbracoMapper mapper, IPublishedContent rootNode)
            : base(mapper, rootNode)
        {
        }

        /// <summary>
        /// Processes the mapping from the content to to the partial page view model
        /// </summary>
        /// <param name="to">Partial page view model to map to</param>
        public void Handle(SocialLinksViewModel to)
        {
            if (RootNode == null)
            {
                return;
            }

            Mapper.Map(RootNode, to);
        }
    }
}
