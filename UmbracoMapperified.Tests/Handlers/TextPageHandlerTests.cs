namespace TxtStarter.Tests.Handlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TxtStarter.Handlers;
    using TxtStarter.ViewModels.Pages;
    using Umbraco.Core.Models;
    using Zone.UmbracoMapper;

    [TestClass]
    public class TextPageHandlerTests : BaseTextPageHandlerTests
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestMethod]
        public void TextPageHandler_CanMapFromContent()
        {
            // Arrange
            var mapper = new UmbracoMapper();
            var handler = new TextPageHandler(mapper);
            var content = MockTextPageContent();
            var model = new TextPageViewModel();

            // Act
            handler.Handle(content.Object, model);

            // Assert
            Assert.AreEqual("My text page", model.Title);
            Assert.AreEqual("My site", model.SiteName);
            Assert.AreEqual("My site byline", model.ByLine);
            Assert.AreEqual("My company", model.Copyright);
            Assert.AreEqual("/media/1.jpg", model.ImageUrl);
            Assert.AreEqual("<p>" + new string('*', 1000) + "</p>", model.BodyText.ToString());
        }
    }
}
