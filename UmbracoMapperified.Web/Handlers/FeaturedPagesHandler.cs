namespace UmbracoMapperified.Web.Handlers
{
    using System.Linq;
    using UmbracoMapperified.Web.Infrastructure.Handlers;
    using UmbracoMapperified.Web.ViewModels.Partials;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Handler for mapping the <see cref="FeaturedPagesViewModel"/> partial view model
    /// </summary>
    public class FeaturedPagesHandler : BaseHandler, IHandler<FeaturedPagesViewModel>
    {
        public FeaturedPagesHandler(IUmbracoMapper mapper)
            : base(mapper)
        {
        }

        public FeaturedPagesHandler(IUmbracoMapper mapper, IPublishedContent rootNode)
            : base(mapper, rootNode)
        {
        }

        /// <summary>
        /// Processes the mapping from the content to to the partial page view model
        /// </summary>
        /// <param name="to">Partial page view model to map to</param>
        public void Handle(FeaturedPagesViewModel to)
        {
            if (RootNode == null)
            {
                return;
            }

            var featuredPages = RootNode.Descendants("umbTextPage")
                .Where(x => x.GetPropertyValue<bool>("featuredPage"))
                .ToList();
            Mapper.MapCollection(featuredPages, to.Pages, TruncatedBodyTextMappingForPage());
        }
    }
}
