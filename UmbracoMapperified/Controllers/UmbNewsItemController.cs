namespace TxtStarter.Controllers
{
    using System.Web.Mvc;
    using TxtStarter.ViewModels;
    using TxtStarter.ViewModels.Pages;

    /// <summary>
    /// Route hijacks requests for pages based on the document type UmbNewsItem
    /// </summary>
    public class UmbNewsItemController : BasePageController
    {
        /// <summary>
        /// Route hijacks requests for pages based on the document type UmbNewsItem, builds the view model and passes to the view
        /// </summary>
        public ActionResult UmbNewsItem()
        {
            var vm = ViewModelBuilder.BuildPage<NewsItemPageViewModel>(CurrentPage);
            return View(vm);
        }
    }
}
