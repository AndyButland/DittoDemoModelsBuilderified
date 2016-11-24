namespace UmbracoMapperified.Tests.Handlers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using UmbracoMapperified.Web.Handlers;
    using UmbracoMapperified.Web.ViewModels.Partials;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    [TestClass]
    public class NewsOverviewWidgetHandlerTests : BaseNewsPageHandlerTests
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void NewsOverviewWidgetHandler_CanMapFromContent()
        {
            // Arrange
            var mapper = new UmbracoMapper();
            var rootNode = MockContent();
            var handler = new NewsOverviewWidgetHandler(mapper, rootNode.Object);
            var model = new NewsOverviewWidgetViewModel();

            // Act
            handler.Handle(model);

            // Assert
            Assert.AreEqual("News overview title", model.Title);
            Assert.AreEqual("Story 3", model.FeaturedItem.Title);
            Assert.AreEqual("/news/story-3/", model.FeaturedItem.Url);
            Assert.AreEqual("Story sub-header", model.FeaturedItem.SubHeader);
            Assert.AreEqual("/media/1.jpg", model.FeaturedItem.ImageUrl);
            Assert.AreEqual(new DateTime(2016, 11, 23).ToString("d-MMM-yyyy"), model.FeaturedItem.DateTime.ToString("d-MMM-yyyy"));
            Assert.AreEqual(new string('*', 197) + "...", model.FeaturedItem.TruncatedBodyText);
        }

        private Mock<IPublishedContent> MockContent()
        {
            var contentMock = new Mock<IPublishedContent>();
            contentMock.Setup(c => c.Id).Returns(1000);
            contentMock.Setup(c => c.Name).Returns("Home");
            contentMock.Setup(c => c.Url).Returns("/");
            contentMock.Setup(c => c.DocumentTypeAlias).Returns("umbHomeage");
            contentMock.Setup(c => c.Children).Returns(new List<IPublishedContent>
            {
                MockNewsOverviewPage().Object,
            });
            return contentMock;
        }
    }
}
