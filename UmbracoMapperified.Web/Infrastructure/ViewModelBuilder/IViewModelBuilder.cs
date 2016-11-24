namespace UmbracoMapperified.Web.Infrastructure.ViewModelBuilder
{
    using UmbracoMapperified.Web.ViewModels;
    using Umbraco.Core.Models;
    using UmbracoMapperified.Web.ViewModels.Pages;

    /// <summary>
    /// Defines builder methods for instantiating and populating a view model
    /// </summary>
    public interface IViewModelBuilder
    {
        /// <summary>
        /// Populates a view model with content input queried from the Umbraco context
        /// </summary>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <returns>View model instance</returns>
        TModel Build<TModel>()
            where TModel : new();

        /// <summary>
        /// Populates a view model from the provided source content
        /// </summary>
        /// <typeparam name="TSource">Content source to populate from</typeparam>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <returns>View model instance</returns>
        TModel Build<TSource, TModel>(TSource source)
            where TModel : new();

        /// <summary>
        /// Populates a view model from the provided source content and additional data 
        /// (such as that provided from a form post or querystring input)
        /// </summary>
        /// <typeparam name="TSource">Content source to populate from</typeparam>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <typeparam name="TData">Type of additional data</typeparam>
        /// <returns>View model instance</returns>
        TModel Build<TSource, TModel, TData>(TSource source, TData data)
            where TModel : new();

        /// <summary>
        /// Populates a full page view model from the provided source content
        /// </summary>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <param name="source">Source content</param>
        /// <returns>View model instance</returns>
        TModel BuildPage<TModel>(IPublishedContent source)
            where TModel : BasePageViewModel, new();

        /// <summary>
        /// Populates a full page view model from the provided source content and additional data 
        /// (such as that provided from a form post or querystring input)
        /// </summary>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <typeparam name="TData">Type of additional data</typeparam>
        /// <param name="source">Source content</param>
        /// <param name="data">Additional data</param>
        /// <returns>View model instance</returns>
        TModel BuildPage<TModel, TData>(IPublishedContent source, TData data)
            where TModel : BasePageViewModel, new();
    }
}
