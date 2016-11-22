namespace UmbracoMapperified.Web.Controllers
{
    using System.Web.Mvc;
    using UmbracoMapperified.Web.ViewModels;
    using UmbracoMapperified.Web.ViewModels.Pages;

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
