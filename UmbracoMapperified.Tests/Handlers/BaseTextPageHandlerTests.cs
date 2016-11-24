namespace UmbracoMapperified.Tests.Handlers
{
    using Moq;
    using Umbraco.Core.Models;

    public abstract class BaseTextPageHandlerTests : BaseHandlerTests
    {
        protected Mock<IPublishedContent> MockTextPageContent(bool featuredPage = false)
        {
            var titlePropertyMock = new Mock<IPublishedProperty>();
            titlePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("title");
            titlePropertyMock.Setup(c => c.Value).Returns("My text page");

            var siteNamePropertyMock = new Mock<IPublishedProperty>();
            siteNamePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("siteName");
            siteNamePropertyMock.Setup(c => c.Value).Returns("My site");

            var bylinePropertyMock = new Mock<IPublishedProperty>();
            bylinePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("byline");
            bylinePropertyMock.Setup(c => c.Value).Returns("My site byline");

            var copyrightPropertyMock = new Mock<IPublishedProperty>();
            copyrightPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("copyright");
            copyrightPropertyMock.Setup(c => c.Value).Returns("My company");

            var imagePropertyMock = new Mock<IPublishedProperty>();
            imagePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("image");
            imagePropertyMock.Setup(c => c.Value).Returns("/media/1.jpg");

            var bodyTextPropertyMock = new Mock<IPublishedProperty>();
            bodyTextPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("copyright");
            bodyTextPropertyMock.Setup(c => c.Value).Returns("<p>Body</p>");
            bodyTextPropertyMock.Setup(c => c.Value).Returns("<p>" + new string('*', 1000) + "</p>");

            var featuredPagePropertyMock = new Mock<IPublishedProperty>();
            featuredPagePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("featuredPage");
            featuredPagePropertyMock.Setup(c => c.Value).Returns(featuredPage);

            var contentMock = new Mock<IPublishedContent>();
            contentMock.Setup(c => c.Id).Returns(1001);
            contentMock.Setup(c => c.Name).Returns("Text page");
            contentMock.Setup(c => c.Url).Returns("/text-page/");
            contentMock.Setup(c => c.DocumentTypeAlias).Returns("umbTextPage");
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "title"), It.IsAny<bool>())).Returns(titlePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "siteName"), It.Is<bool>(x => true))).Returns(siteNamePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "byline"), It.Is<bool>(x => true))).Returns(bylinePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "copyright"), It.Is<bool>(x => true))).Returns(copyrightPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "image"), It.IsAny<bool>())).Returns(imagePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "bodyText"), It.IsAny<bool>())).Returns(bodyTextPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "featuredPage"), It.IsAny<bool>())).Returns(featuredPagePropertyMock.Object);
            return contentMock;
        }
    }
}
