namespace TxtStarter.Controllers
{
    using System.Web.Mvc;
    using TxtStarter.ViewModels;
    using TxtStarter.ViewModels.Pages;
    using TxtStarter.ViewModels.Partials;

    /// <summary>
    /// Route hijacks requests for pages based on the document type UmbHomePage and provides action methods for associated partial views
    /// </summary>
    public class UmbHomePageController : BasePageController
    {
        /// <summary>
        /// Route hijacks requests for pages based on the document type UmbHomePage, builds the view model and passes to the view
        /// </summary>
        public ActionResult UmbHomePage()
        {
            var vm = ViewModelBuilder.BuildPage<HomePageViewModel>(CurrentPage);
            return View(vm);
        }

        /// <summary>
        /// Renders the partial for the social links presented on the home page
        /// </summary>
        [ChildActionOnly]
        public PartialViewResult SocialLinks()
        {
            var vm = ViewModelBuilder.Build<SocialLinksViewModel>();
            return PartialView("umbSocial", vm);
        }
    }
}
