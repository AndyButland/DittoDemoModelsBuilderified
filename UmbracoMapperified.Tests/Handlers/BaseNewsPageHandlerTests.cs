namespace UmbracoMapperified.Tests.Handlers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Umbraco.Core.Models;

    [TestClass]
    public abstract class BaseNewsPageHandlerTests : BaseHandlerTests
    {
        protected Mock<IPublishedContent> MockNewsOverviewPage()
        {
            var titlePropertyMock = new Mock<IPublishedProperty>();
            titlePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("title");
            titlePropertyMock.Setup(c => c.Value).Returns("News overview title");

            var contentMock = new Mock<IPublishedContent>();
            contentMock.Setup(c => c.Id).Returns(1001);
            contentMock.Setup(c => c.Name).Returns("News");
            contentMock.Setup(c => c.Url).Returns("/news/");
            contentMock.Setup(c => c.DocumentTypeAlias).Returns("umbNewsOverview");
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "title"), It.IsAny<bool>())).Returns(titlePropertyMock.Object);
            contentMock.Setup(c => c.Children).Returns(new List<IPublishedContent>
            {
                MockNewsItemPage(1002, "Story 1", "/news/story-1/", new DateTime(2016, 11, 21)).Object,
                MockNewsItemPage(1003, "Story 2", "/news/story-2/", new DateTime(2016, 11, 22)).Object,
                MockNewsItemPage(1004, "Story 3", "/news/story-3/", new DateTime(2016, 11, 23)).Object,
            });
            return contentMock;
        }

        protected Mock<IPublishedContent> MockNewsItemPage(int id, string name, string url, DateTime publishDate)
        {
            var titlePropertyMock = new Mock<IPublishedProperty>();
            titlePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("title");
            titlePropertyMock.Setup(c => c.Value).Returns(name);

            var subHeaderPropertyMock = new Mock<IPublishedProperty>();
            subHeaderPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("subHeader");
            subHeaderPropertyMock.Setup(c => c.Value).Returns("Story sub-header");

            var publishDatePropertyMock = new Mock<IPublishedProperty>();
            publishDatePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("publishDate");
            publishDatePropertyMock.Setup(c => c.Value).Returns(publishDate);

            var imagePropertyMock = new Mock<IPublishedProperty>();
            imagePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("image");
            imagePropertyMock.Setup(c => c.Value).Returns("/media/1.jpg");

            var bodyTextPropertyMock = new Mock<IPublishedProperty>();
            bodyTextPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("copyright");
            bodyTextPropertyMock.Setup(c => c.Value).Returns("<p>" + new string('*', 1000) + "</p>");

            var contentMock = new Mock<IPublishedContent>();
            contentMock.Setup(c => c.Id).Returns(id);
            contentMock.Setup(c => c.Name).Returns(name);
            contentMock.Setup(c => c.Url).Returns(url);
            contentMock.Setup(c => c.DocumentTypeAlias).Returns("umbNewsItem");
            contentMock.Setup(c => c.CreateDate).Returns(publishDate);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "title"), It.IsAny<bool>())).Returns(titlePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "subHeader"), It.IsAny<bool>())).Returns(subHeaderPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "publishDate"), It.IsAny<bool>())).Returns(publishDatePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "image"), It.IsAny<bool>())).Returns(imagePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "bodyText"), It.IsAny<bool>())).Returns(bodyTextPropertyMock.Object);

            return contentMock;
        }
    }
}
