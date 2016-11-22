namespace UmbracoMapperified.Web.Controllers
{
    using System.Web.Mvc;
    using UmbracoMapperified.Web.ViewModels;
    using UmbracoMapperified.Web.ViewModels.Pages;
    using UmbracoMapperified.Web.ViewModels.Partials;

    /// <summary>
    /// Route hijacks requests for pages based on the document type UmbNewsOverview and provides action methods for associated partial views
    /// </summary>
    public class UmbNewsOverviewController : BasePageController
    {
        /// <summary>
        /// Route hijacks requests for pages based on the document type UmbNewsItem, builds the view model and passes to the view
        /// </summary>
        /// <param name="p">Page number for news list</param>
        /// <returns></returns>
        public ActionResult UmbNewsOverview(int p = 1)
        {
            const int PageSize = 2;
            var vm = ViewModelBuilder.BuildPage<NewsOverviewPageViewModel, PagingDetail>(CurrentPage, new PagingDetail(p, PageSize));
            return View(vm);
        }

        /// <summary>
        /// Renders the partial for the news overview widget presented on the home page
        /// </summary>
        [ChildActionOnly]
        public PartialViewResult NewsOverviewWidget()
        {
            var vm = ViewModelBuilder.Build<NewsOverviewWidgetViewModel>();
            return PartialView("umbNewsOverviewWidget", vm);
        }

        /// <summary>
        /// Renders the partial for the latest news widget presented on the side-bar of various pages
        /// </summary>
        [ChildActionOnly]
        public PartialViewResult LatestNewsWidget()
        {
            var vm = ViewModelBuilder.Build<LatestNewsWidgetViewModel>();
            return PartialView("umbLatestNewsWidget", vm);
        }
    }
}
