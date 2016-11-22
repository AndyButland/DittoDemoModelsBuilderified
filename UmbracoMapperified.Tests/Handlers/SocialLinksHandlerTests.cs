namespace TxtStarter.Tests.Handlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TxtStarter.Handlers;
    using TxtStarter.ViewModels.Pages;
    using TxtStarter.ViewModels.Partials;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    [TestClass]
    public class SocialLinksHandlerTests : BaseHandlerTests
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void SocialLinksHandler_CanMapFromContent()
        {
            // Arrange
            var mapper = new UmbracoMapper();
            var rootNode = MockHomePageContent();
            var handler = new SocialLinksHandler(mapper, rootNode.Object);
            var model = new SocialLinksViewModel();

            // Act
            handler.Handle(model);

            // Assert
            Assert.AreEqual("www.facebook.com", model.FacebookLink);
            Assert.AreEqual("www.twitter.com", model.TwitterLink);
            Assert.AreEqual("www.linkedin.com", model.LinkedinLink);
            Assert.AreEqual("www.google.com", model.GoogleLink);
            Assert.AreEqual("www.site.com/rss", model.RssLink);
            Assert.AreEqual("www.dribble.com", model.DribbleLink);
        }

        private Mock<IPublishedContent> MockHomePageContent()
        {
            var facebookLinkPropertyMock = new Mock<IPublishedProperty>();
            facebookLinkPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("facebookLink");
            facebookLinkPropertyMock.Setup(c => c.Value).Returns("www.facebook.com");

            var twitterLinkPropertyMock = new Mock<IPublishedProperty>();
            twitterLinkPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("twitterLink");
            twitterLinkPropertyMock.Setup(c => c.Value).Returns("www.twitter.com");

            var linkedinLinkPropertyMock = new Mock<IPublishedProperty>();
            linkedinLinkPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("linkedinLink");
            linkedinLinkPropertyMock.Setup(c => c.Value).Returns("www.linkedin.com");

            var googleLinkPropertyMock = new Mock<IPublishedProperty>();
            googleLinkPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("googleLink");
            googleLinkPropertyMock.Setup(c => c.Value).Returns("www.google.com");

            var rssLinkPropertyMock = new Mock<IPublishedProperty>();
            rssLinkPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("rssLink");
            rssLinkPropertyMock.Setup(c => c.Value).Returns("www.site.com/rss");

            var dribbleLinkPropertyMock = new Mock<IPublishedProperty>();
            dribbleLinkPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("dribbleLink");
            dribbleLinkPropertyMock.Setup(c => c.Value).Returns("www.dribble.com");

            var contentMock = new Mock<IPublishedContent>();
            contentMock.Setup(c => c.Id).Returns(1001);
            contentMock.Setup(c => c.Name).Returns("Home");
            contentMock.Setup(c => c.Url).Returns("/");
            contentMock.Setup(c => c.DocumentTypeAlias).Returns("umbHomeage");
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "facebookLink"), It.IsAny<bool>())).Returns(facebookLinkPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "twitterLink"), It.IsAny<bool>())).Returns(twitterLinkPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "linkedinLink"), It.IsAny<bool>())).Returns(linkedinLinkPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "googleLink"), It.IsAny<bool>())).Returns(googleLinkPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "rssLink"), It.IsAny<bool>())).Returns(rssLinkPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "dribbleLink"), It.IsAny<bool>())).Returns(dribbleLinkPropertyMock.Object);
            return contentMock;
        }
    }
}
