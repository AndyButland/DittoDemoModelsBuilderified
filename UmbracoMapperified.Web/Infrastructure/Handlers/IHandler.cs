namespace UmbracoMapperified.Web.Infrastructure.Handlers
{
    /// <summary>
    /// Defines a handler for the population of a view model with content input queried from the Umbraco context
    /// </summary>
    /// <typeparam name="TTo">Type of model to populate</typeparam>
    public interface IHandler<in TTo>
    {
        void Handle(TTo destination);
    }

    /// <summary>
    /// Defines a handler for the population of a view model from the provided source content
    /// </summary>
    /// <typeparam name="TSource">Content source to populate from</typeparam>
    /// <typeparam name="TTo">Type of model to populate</typeparam>
    public interface IHandler<in TSource, in TTo>
    {
        void Handle(TSource source, TTo destination);
    }

    /// <summary>
    /// Defines a handler for the population of a view model from the provided source content and additional data 
    /// (such as that provided from a form post or querystring input)
    /// </summary>
    /// <typeparam name="TSource">Content source to populate from</typeparam>
    /// <typeparam name="TTo">Type of model to populate</typeparam>
    /// <typeparam name="TData">Type of additional data</typeparam>
    public interface IHandler<in TSource, in TTo, in TData>
    {
        void Handle(TSource source, TTo destination, TData data);
    }
}
