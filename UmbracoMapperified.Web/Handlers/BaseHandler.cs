namespace UmbracoMapperified.Web.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UmbracoMapperified.Web.Helpers;
    using UmbracoMapperified.Web.Infrastructure.Mapping;
    using UmbracoMapperified.Web.ViewModels;
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Abstract base class from which all handlers derive, providing access to common properties and functions
    /// </summary>
    public abstract class BaseHandler
    {
        private IPublishedContent _routeNode;

        protected BaseHandler(IUmbracoMapper mapper)
            : this(mapper, null)
        {
        }

        protected BaseHandler(IUmbracoMapper mapper, IPublishedContent rootNode)
        {
            Mapper = mapper;
            Mapper.AddCustomMapping(typeof(MediaFile).FullName, MediaFileMapping.Map);

            Umbraco = new UmbracoHelper(UmbracoContext.Current);

            _routeNode = rootNode;
        }

        /// <summary>
        /// Gets the configured instance of the Umbraco Mapper
        /// </summary>
        protected IUmbracoMapper Mapper { get; }

        /// <summary>
        /// Gets the Umbraco Helper
        /// </summary>
        protected UmbracoHelper Umbraco { get; }

        /// <summary>
        /// Gets the root node (home page) of the site
        /// </summary>
        protected IPublishedContent RootNode
        {
            get
            {
                _routeNode = _routeNode ?? Umbraco.TypedContentAtRoot().FirstOrDefault();
                return _routeNode;
            }
        }

        /// <summary>
        /// Helper to get the single instance of the news overview page
        /// </summary>
        protected IPublishedContent GetNewsOverviewPage()
        {
            return RootNode?.Descendants("umbNewsOverview")
                .FirstOrDefault();
        }

        /// <summary>
        /// Helper to create a paged collection of strongly typed items for a list
        /// </summary>
        /// <typeparam name="T">Type of list item</typeparam>
        /// <param name="items">Source items as <see cref="IPublishedContent"/></param>
        /// <param name="pagingDetail">Page number and size details</param>
        /// <param name="pagedItems">Paged list of items provided to caller in out parameter</param>
        /// <returns>Instance of <see cref="PagedCollection"/></returns>
        protected PagedCollection<T> CreatePagedCollection<T>(IList<IPublishedContent> items, PagingDetail pagingDetail, out IEnumerable<IPublishedContent> pagedItems)
        {
            var totalItems = items.Count;
            var totalPages = (int)Math.Ceiling(totalItems / (decimal)pagingDetail.PageSize);
            var pageNumber = Math.Max(1, Math.Min(pagingDetail.PageNumber, totalPages));

            pagedItems = items
                .MostRecent()
                .Skip((pageNumber - 1) * pagingDetail.PageSize)
                .Take(pagingDetail.PageSize);

            return new PagedCollection<T>
            {
                PageNumber = pageNumber,
                PageSize = pagingDetail.PageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
            };
        }

        /// <summary>
        /// Helper to create the dictionary of property mapping overrides for when we have a body text field on a page that we want to truncate.
        /// </summary>
        /// <remarks>
        /// Note that the majority over overrides to the conventions for <see cref="UmbracoMapper"/> are provided via attributes.  
        /// The dictionary of property mappings is an alternative (mostly legacy) method that is still required for overrides that can't be provides
        /// as attributes.  StringValueFormatter - provided as a Func rather than a constant value - is one of these.
        /// </remarks>
        /// <returns>Dictionary of property mappings</returns>
        protected static Dictionary<string, PropertyMapping> TruncatedBodyTextMappingForPage()
        {
            return TruncatedBodyTextMapping(StringValueFormatters.TruncatePageText);
        }

        /// <summary>
        /// Helper to create the dictionary of property mapping overrides for when we have a body text field on a news page that we want to truncate.
        /// </summary>
        /// <returns>Dictionary of property mappings</returns>
        protected static Dictionary<string, PropertyMapping> TruncatedBodyTextMappingForNewsPage()
        {
            return TruncatedBodyTextMapping(StringValueFormatters.TruncateNewsPageText);
        }

        /// <summary>
        /// Private helper to create the dictionary of property mapping overrides when truncating a body text field
        /// </summary>
        /// <param name="stringFormatter">Function to provide to property mapping</param>
        /// <returns>Dictionary of property mappings</returns>
        private static Dictionary<string, PropertyMapping> TruncatedBodyTextMapping(Func<string, string> stringFormatter)
        {
            return new Dictionary<string, PropertyMapping>
            {
                {
                    "TruncatedBodyText",
                    new PropertyMapping
                    {
                        SourceProperty = "BodyText",
                        StringValueFormatter = stringFormatter
                    }
                }
            };
        }
    }
}
