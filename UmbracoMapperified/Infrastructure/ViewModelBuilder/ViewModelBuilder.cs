namespace TxtStarter.Infrastructure.ViewModelBuilder
{
    using TxtStarter.Infrastructure.Handlers;
    using TxtStarter.ViewModels;
    using Umbraco.Core.Models;

    public class ViewModelBuilder : IViewModelBuilder
    {
        private readonly IHandlerResolver _handlerResolver;

        public ViewModelBuilder(IHandlerResolver handlerResolver)
        {
            _handlerResolver = handlerResolver;
        }

        /// <summary>
        /// Populates a view model with content input queried from the Umbraco context
        /// </summary>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <returns>View model instance</returns>
        public TModel Build<TModel>()
            where TModel : new()
        {
            var create = new TModel();
            var handler = _handlerResolver.Resolve<TModel>();
            handler.Handle(create);
            return create;
        }

        /// <summary>
        /// Populates a view model from the provided source content
        /// </summary>
        /// <typeparam name="TSource">Content source to populate from</typeparam>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <returns>View model instance</returns>
        public TModel Build<TSource, TModel>(TSource source)
            where TModel : new()
        {
            var create = new TModel();
            var handler = _handlerResolver.Resolve<TSource, TModel>();
            handler.Handle(source, create);
            return create;
        }

        /// <summary>
        /// Populates a view model from the provided source content and additional data 
        /// (such as that provided from a form post or querystring input)
        /// </summary>
        /// <typeparam name="TSource">Content source to populate from</typeparam>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <typeparam name="TData">Type of additional data</typeparam>
        /// <returns>View model instance</returns>
        public TModel Build<TSource, TModel, TData>(TSource source, TData data) 
            where TModel : new()
        {
            var create = new TModel();
            var handler = _handlerResolver.Resolve<TSource, TModel, TData>();
            handler.Handle(source, create, data);
            return create;
        }

        /// <summary>
        /// Populates a full page view model from the provided source content
        /// </summary>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <param name="source">Source content</param>
        /// <returns>View model instance</returns>
        public TModel BuildPage<TModel>(IPublishedContent source)
            where TModel : BasePageViewModel, new()
        {
            var create = Build<IPublishedContent, TModel>(source);
            CallBasePageHandlers(source, create);
            return create;
        }

        /// <summary>
        /// Populates a full page view model from the provided source content and additional data 
        /// (such as that provided from a form post or querystring input)
        /// </summary>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <typeparam name="TData">Type of additional data</typeparam>
        /// <param name="source">Source content</param>
        /// <param name="data">Additional data</param>
        /// <returns>View model instance</returns>
        public TModel BuildPage<TModel, TData>(IPublishedContent source, TData data)
            where TModel : BasePageViewModel, new()
        {
            var create = Build<IPublishedContent, TModel, TData>(source, data);
            CallBasePageHandlers(source, create);
            return create;
        }

        /// <summary>
        /// Helper to resolve and call handlers for the base page
        /// </summary>
        /// <typeparam name="TModel">Type of model to populate</typeparam>
        /// <param name="source">Source content</param>
        /// <param name="model">View model instance to populate</param>
        private void CallBasePageHandlers<TModel>(IPublishedContent source, TModel model)
            where TModel : BasePageViewModel, new()
        {
            var handlers = _handlerResolver.ResolveBasePageHandlers();
            foreach (var handler in handlers)
            {
                handler.Handle(source, model);
            }
        }
    }

}
