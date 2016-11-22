namespace TxtStarter.Tests.Handlers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TxtStarter.Handlers;
    using TxtStarter.ViewModels.Partials;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    [TestClass]
    public class LatestNewsWidgetHandlerTests : BaseNewsPageHandlerTests
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void LatestNewsWidgetHandler_CanMapFromContent()
        {
            // Arrange
            var mapper = new UmbracoMapper();
            var rootNode = MockContent();
            var handler = new LatestNewsWidgetHandler(mapper, rootNode.Object);
            var model = new LatestNewsWidgetViewModel();

            // Act
            handler.Handle(model);

            // Assert
            Assert.AreEqual("/news/", model.NewsOverviewUrl);
            Assert.AreEqual(3, model.NewsItems.Count);
            Assert.AreEqual("Story 3", model.NewsItems[0].Title);
            Assert.AreEqual("/news/story-3/", model.NewsItems[0].Url);
            Assert.AreEqual(new DateTime(2016, 11, 23).ToString("d-MMM-yyyy"), model.NewsItems[0].DateTime.ToString("d-MMM-yyyy"));
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
