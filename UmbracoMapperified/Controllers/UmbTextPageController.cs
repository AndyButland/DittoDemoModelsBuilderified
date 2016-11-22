namespace TxtStarter.Controllers
{
    using System.Web.Mvc;
    using TxtStarter.ViewModels;
    using TxtStarter.ViewModels.Pages;
    using TxtStarter.ViewModels.Partials;

    /// <summary>
    /// Route hijacks requests for pages based on the document type UmbTextPage and provides action methods for associated partial views
    /// </summary>
    public class UmbTextPageController : BasePageController
    {
        /// <summary>
        /// Route hijacks requests for pages based on the document type UmbTextPage, builds the view model and passes to the view
        /// </summary>
        /// <returns></returns>
        public ActionResult UmbTextPage()
        {
            var vm = ViewModelBuilder.BuildPage<TextPageViewModel>(CurrentPage);
            return View(vm);
        }

        /// <summary>
        /// Renders the partial for the featured pages presented on various pages
        /// </summary>
        [ChildActionOnly]
        public PartialViewResult FeaturedPages()
        {
            var vm = ViewModelBuilder.Build<FeaturedPagesViewModel>();
            return PartialView("umbFeatures", vm);
        }
    }
}
