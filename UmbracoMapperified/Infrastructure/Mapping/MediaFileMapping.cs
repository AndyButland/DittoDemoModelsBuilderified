namespace TxtStarter.Infrastructure.Mapping
{
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Zone.UmbracoMapper;

    /// <summary>
    /// Defines custom mapping for media files
    /// </summary>
    /// <remarks>
    /// The mapping function defined in this class isn't currently used in the application but has been left in as an example of how such
    /// custom mapping operations on complex types in the view model can be supported.
    /// </remarks>
    public class MediaFileMapping
    {
        /// <summary>
        /// Defines a custom mapping to a complex type on a view model of type <see cref="MediaFile"/> 
        /// </summary>
        /// <param name="mapper">Instance of <see cref="UmbracoMapper"/></param>
        /// <param name="contentToMapFrom">Instance of <see cref="IPublishedContent"/> to map from</param>
        /// <param name="propertyAlias">Property alias</param>
        /// <param name="recursive">Flag for mapping recursively</param>
        /// <returns>Mapped instance of <see cref="MediaFile"/> </returns>
        public static object Map(IUmbracoMapper mapper, IPublishedContent contentToMapFrom, string propertyAlias, bool recursive)
        {
            var value = contentToMapFrom.GetProperty(propertyAlias, recursive).DataValue;
            if (value == null)
            {
                return null;
            }

            int id;
            if (!int.TryParse(value.ToString(), out id) || id <= 0)
            {
                return null;
            }

            var umbraco = new UmbracoHelper(UmbracoContext.Current);
            var media = umbraco.TypedMedia(id);

            var model = new MediaFile();
            mapper.Map(media, model);

            return model;
        }
    }
}
