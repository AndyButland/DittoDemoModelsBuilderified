namespace UmbracoMapperified.Web.Infrastructure.Handlers
{
    using System.Collections.Generic;
    using UmbracoMapperified.Web.ViewModels;
    using Umbraco.Core.Models;
    using UmbracoMapperified.Web.ViewModels.Pages;

    public interface IHandlerResolver
    {
        /// <summary>
        /// Resolves the typed handler for the population of a view model with content input queried from the Umbraco context
        /// </summary>
        /// <typeparam name="TTo">Type of model to populate</typeparam>
        IHandler<TTo> Resolve<TTo>();

        /// <summary>
        /// Resolves the typed handler for the population of a view model from the provided source content
        /// </summary>
        /// <typeparam name="TSource">Content source to populate from</typeparam>
        /// <typeparam name="TTo">Type of model to populate</typeparam>
        IHandler<TSource, TTo> Resolve<TSource, TTo>();

        /// <summary>
        /// Resolves the typed handler for the population of a view model from the provided source content and additional data 
        /// (such as that provided from a form post or querystring input)
        /// </summary>
        /// <typeparam name="TSource">Content source to populate from</typeparam>
        /// <typeparam name="TTo">Type of model to populate</typeparam>
        /// <typeparam name="TData">Type of additional data</typeparam>
        IHandler<TSource, TTo, TData> Resolve<TSource, TTo, TData>();

        /// <summary>
        /// Resolves the set of base page handlers for population of common properties on the base view model
        /// </summary>
        IEnumerable<IHandler<IPublishedContent, BasePageViewModel>> ResolveBasePageHandlers();
    }
}
