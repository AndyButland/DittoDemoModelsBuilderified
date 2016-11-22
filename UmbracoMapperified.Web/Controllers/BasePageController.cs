namespace UmbracoMapperified.Web.Controllers
{
    using System.Web.Mvc;
    using UmbracoMapperified.Web.Infrastructure.IoC;
    using UmbracoMapperified.Web.Infrastructure.ViewModelBuilder;
    using Umbraco.Web.Models;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// Base controller for all route hijacked pages on the site.
    /// </summary>
    /// <remarks>
    /// Note that this controller INHERITS from <see cref="SurfaceController"/>  and IMPLEMENTS <see cref="IRenderMvcController"/>.  This means
    /// it can act as both a SurfaceController (e.g. for handling form posts) and an RenderMvcController (for route hijacking)
    /// </remarks>
    public abstract class BasePageController : SurfaceController, IRenderMvcController
    {
        protected BasePageController()
        {
            ViewModelBuilder = NinjectWebCommon.GetBinding<IViewModelBuilder>();
        }

        /// <summary>
        /// Gets an instance of <see cref="IViewModelBuilder"/> available to all derived controllers
        /// </summary>
        protected IViewModelBuilder ViewModelBuilder { get; }

        /// <summary>
        /// Implements the necessary methods on <see cref="IRenderMvcController"/>
        /// </summary>
        public ActionResult Index(RenderModel model)
        {
            return CurrentTemplate(model);
        }

        /// <summary>
        /// Implements the necessary methods on <see cref="IRenderMvcController"/>
        /// </summary>
        protected ActionResult CurrentTemplate<T>(T model)
        {
            return View(ControllerContext.RouteData.Values["action"].ToString(), model);
        }
    }
}
