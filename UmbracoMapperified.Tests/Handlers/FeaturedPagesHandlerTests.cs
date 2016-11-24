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
    public class FeaturedPagesHandlerTests : BaseTextPageHandlerTests
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void FeaturedPagesHandler_CanMapFromContent()
        {
            // Arrange
            var mapper = new UmbracoMapper();
            var rootNode = MockContent();
            var handler = new FeaturedPagesHandler(mapper, rootNode.Object);
            var model = new FeaturedPagesViewModel();

            // Act
            handler.Handle(model);

            // Assert
            Assert.AreEqual(2, model.Pages.Count);
            Assert.AreEqual("Text page", model.Pages[0].Name);
            Assert.AreEqual("/text-page/", model.Pages[0].Url);
            Assert.AreEqual("/media/1.jpg", model.Pages[0].ImageUrl);
            Assert.AreEqual(new string('*', 97) + "...", model.Pages[0].TruncatedBodyText);
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
                MockTextPageContent(true).Object,
                MockTextPageContent(true).Object,
                MockTextPageContent().Object,
            });
            return contentMock;
        }
    }
}
