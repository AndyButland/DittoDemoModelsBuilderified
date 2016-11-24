namespace UmbracoMapperified.Tests.Handlers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using UmbracoMapperified.Web.Handlers;
    using UmbracoMapperified.Web.ViewModels;
    using UmbracoMapperified.Web.ViewModels.Pages;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    [TestClass]
    public class NewsOverviewPageHandlerTests : BaseNewsPageHandlerTests
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void NewsOverviewPageHandler_CanMapFromContent()
        {
            // Arrange
            var mapper = new UmbracoMapper();
            var handler = new NewsOverviewPageHandler(mapper);
            var content = MockNewsOverviewPage();
            var model = new NewsOverviewPageViewModel();
            var pagingDetail = new PagingDetail(1, 2);

            // Act
            handler.Handle(content.Object, model, pagingDetail);

            // Assert
            Assert.AreEqual("News overview title", model.Title);
            Assert.AreEqual(3, model.NewsItemsPage.TotalItems);
            Assert.AreEqual(2, model.NewsItemsPage.TotalPages);
            Assert.AreEqual(1, model.NewsItemsPage.PageNumber);
            Assert.AreEqual(2, model.NewsItemsPage.PageSize);
            Assert.AreEqual(2, model.NewsItemsPage.Items.Count);
            Assert.AreEqual("Story 3", model.NewsItemsPage.Items[0].Title);
            Assert.AreEqual("/news/story-3/", model.NewsItemsPage.Items[0].Url);
            Assert.AreEqual("Story sub-header", model.NewsItemsPage.Items[0].SubHeader);
            Assert.AreEqual("/media/1.jpg", model.NewsItemsPage.Items[0].ImageUrl);
            Assert.AreEqual(new DateTime(2016, 11, 23).ToString("d-MMM-yyyy"), model.NewsItemsPage.Items[0].PublishDate.ToString("d-MMM-yyyy"));
            Assert.AreEqual(new string('*', 197) + "...", model.NewsItemsPage.Items[0].TruncatedBodyText);
        }
    }
}
