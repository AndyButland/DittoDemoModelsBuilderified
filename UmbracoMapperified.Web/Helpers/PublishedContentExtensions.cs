namespace UmbracoMapperified.Web.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Umbraco.Core.Models;
    using Umbraco.Web;

    /// <summary>
    /// Provides some common extensions to <see cref="IPublishedContent"/> instances and collections
    /// </summary>
    public static class PublishedContentExtensions
    {
        /// <summary>
        /// Orders a list of <see cref="IPublishedContent"/> that contains publish date fields most recent first
        /// </summary>
        /// <param name="content">Content collection</param>
        /// <returns>Ordered content collection</returns>
        public static IEnumerable<IPublishedContent> MostRecent(this IEnumerable<IPublishedContent> content)
        {
            return content
                .OrderByDescending(x => x.GetPropertyValue<DateTime?>("publishDate"))
                .ThenByDescending(x => x.CreateDate);
        }

        /// <summary>
        /// Orders a list of <see cref="IPublishedContent"/> that contains publish date fields most recent first and returns a set number of them
        /// </summary>
        /// <param name="content">Content collection</param>
        /// <param name="number">Number to return</param>
        /// <returns>Limitted and ordered content collection</returns>
        public static IEnumerable<IPublishedContent> MostRecent(this IEnumerable<IPublishedContent> content, int number)
        {
            return content
                .MostRecent()
                .Take(number);
        }
    }
}