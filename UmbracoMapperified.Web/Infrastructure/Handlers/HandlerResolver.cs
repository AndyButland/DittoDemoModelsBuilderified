namespace UmbracoMapperified.Web.Infrastructure.Handlers
{
    using System.Collections.Generic;
    using UmbracoMapperified.Web.Infrastructure.IoC;
    using UmbracoMapperified.Web.ViewModels;
    using Umbraco.Core.Models;
    using UmbracoMapperified.Web.ViewModels.Pages;

    public class HandlerResolver : IHandlerResolver
    {
        /// <summary>
        /// Resolves the typed handler for the population of a view model with content input queried from the Umbraco context, 
        /// using the Ninject IoC container
        /// </summary>
        /// <typeparam name="TTo">Type of model to populate</typeparam>
        public IHandler<TTo> Resolve<TTo>()
        {
            return NinjectWebCommon.GetBinding<IHandler<TTo>>();
        }

        /// <summary>
        /// Resolves the typed handler for the population of a view model from the provided source content, 
        /// using the Ninject IoC container
        /// </summary>
        /// <typeparam name="TSource">Content source to populate from</typeparam>
        /// <typeparam name="TTo">Type of model to populate</typeparam>
        public IHandler<TSource, TTo> Resolve<TSource, TTo>()
        {
            return NinjectWebCommon.GetBinding<IHandler<TSource, TTo>>();
        }

        /// <summary>
        /// Resolves the typed handler for the population of a view model from the provided source content and additional data 
        /// (such as that provided from a form post or querystring input), using the Ninject IoC container
        /// </summary>
        /// <typeparam name="TSource">Content source to populate from</typeparam>
        /// <typeparam name="TTo">Type of model to populate</typeparam>
        /// <typeparam name="TData">Type of additional data</typeparam>
        public IHandler<TSource, TTo, TData> Resolve<TSource, TTo, TData>()
        {
            return NinjectWebCommon.GetBinding<IHandler<TSource, TTo, TData>>();
        }

        /// <summary>
        /// Resolves the set of base page handlers for population of common properties on the base view model, using the Ninject IoC container
        /// </summary>
        public IEnumerable<IHandler<IPublishedContent, BasePageViewModel>> ResolveBasePageHandlers()
        {
            return NinjectWebCommon.GetAllBindings<IHandler<IPublishedContent, BasePageViewModel>>();
        }
    }
}
