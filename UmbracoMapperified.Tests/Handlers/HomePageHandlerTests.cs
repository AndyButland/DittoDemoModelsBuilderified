namespace TxtStarter.Tests.Handlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TxtStarter.Handlers;
    using TxtStarter.ViewModels.Pages;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    [TestClass]
    public class HomePageHandlerTests : BaseHandlerTests
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void HomePageHandler_CanMapFromContent()
        {
            // Arrange
            var mapper = new UmbracoMapper();
            var handler = new HomePageHandler(mapper);
            var content = MockHomePageContent();
            var model = new HomePageViewModel();

            // Act
            handler.Handle(content.Object, model);

            // Assert
            Assert.AreEqual("My site", model.SiteName);
            Assert.AreEqual("My site byline", model.ByLine);
            Assert.AreEqual("My company", model.Copyright);
            Assert.AreEqual("About us", model.AboutTitle);
            Assert.AreEqual("<p>About</p>", model.AboutText.ToString());
            Assert.IsFalse(model.HideBanner);
            Assert.AreEqual("Banner header", model.BannerHeader);
            Assert.AreEqual("Banner sub-header", model.BannerSubheader);
            Assert.AreEqual("Banner link text", model.BannerLinkText);
            Assert.AreEqual("/media/1.jpg", model.BannerBackgroundImageUrl);
            Assert.AreEqual("/news/", model.BannerLinkUrl);
        }

        private Mock<IPublishedContent> MockHomePageContent()
        {
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

            var aboutTitlePropertyMock = new Mock<IPublishedProperty>();
            aboutTitlePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("aboutTitle");
            aboutTitlePropertyMock.Setup(c => c.Value).Returns("About us");

            var aboutTextPropertyMock = new Mock<IPublishedProperty>();
            aboutTextPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("aboutText");
            aboutTextPropertyMock.Setup(c => c.Value).Returns("<p>About</p>");

            var hideBannerPropertyMock = new Mock<IPublishedProperty>();
            hideBannerPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("hideBanner");
            hideBannerPropertyMock.Setup(c => c.Value).Returns(false);

            var bannerHeaderPropertyMock = new Mock<IPublishedProperty>();
            bannerHeaderPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("bannerHeader");
            bannerHeaderPropertyMock.Setup(c => c.Value).Returns("Banner header");

            var bannerSubHeaderPropertyMock = new Mock<IPublishedProperty>();
            bannerSubHeaderPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("bannerSubheader");
            bannerSubHeaderPropertyMock.Setup(c => c.Value).Returns("Banner sub-header");

            var bannerLinkTextPropertyMock = new Mock<IPublishedProperty>();
            bannerLinkTextPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("bannerLinkText");
            bannerLinkTextPropertyMock.Setup(c => c.Value).Returns("Banner link text");

            var bannerBackgroundImagePropertyMock = new Mock<IPublishedProperty>();
            bannerBackgroundImagePropertyMock.Setup(c => c.PropertyTypeAlias).Returns("bannerBackgroundImage");
            bannerBackgroundImagePropertyMock.Setup(c => c.Value).Returns("/media/1.jpg");

            var bannerLinkPropertyMock = new Mock<IPublishedProperty>();
            bannerLinkPropertyMock.Setup(c => c.PropertyTypeAlias).Returns("bannerLink");
            bannerLinkPropertyMock.Setup(c => c.Value).Returns(MockNewsOverviewPage().Object);

            var contentMock = new Mock<IPublishedContent>();
            contentMock.Setup(c => c.Id).Returns(1001);
            contentMock.Setup(c => c.Name).Returns("Home");
            contentMock.Setup(c => c.Url).Returns("/");
            contentMock.Setup(c => c.DocumentTypeAlias).Returns("umbHomePage");
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "siteName"), It.Is<bool>(x => true))).Returns(siteNamePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "byline"), It.Is<bool>(x => true))).Returns(bylinePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "copyright"), It.Is<bool>(x => true))).Returns(copyrightPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "image"), It.IsAny<bool>())).Returns(imagePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "aboutTitle"), It.IsAny<bool>())).Returns(aboutTitlePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "aboutText"), It.IsAny<bool>())).Returns(aboutTextPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "hideBanner"), It.IsAny<bool>())).Returns(hideBannerPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "bannerHeader"), It.IsAny<bool>())).Returns(bannerHeaderPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "bannerSubheader"), It.IsAny<bool>())).Returns(bannerSubHeaderPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "bannerLinkText"), It.IsAny<bool>())).Returns(bannerLinkTextPropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "bannerBackgroundImage"), It.IsAny<bool>())).Returns(bannerBackgroundImagePropertyMock.Object);
            contentMock.Setup(c => c.GetProperty(It.Is<string>(x => x == "bannerLink"), It.IsAny<bool>())).Returns(bannerLinkPropertyMock.Object);
            return contentMock;
        }

        private Mock<IPublishedContent> MockNewsOverviewPage()
        {
            var contentMock = new Mock<IPublishedContent>();
            contentMock.Setup(c => c.Id).Returns(1002);
            contentMock.Setup(c => c.Name).Returns("News");
            contentMock.Setup(c => c.Url).Returns("/news/");
            contentMock.Setup(c => c.DocumentTypeAlias).Returns("umbNewsOverview");
            return contentMock;
        }
    }
}
