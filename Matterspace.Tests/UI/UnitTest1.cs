using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.PhantomJS;

namespace Matterspace.Tests.UI
{
    [TestClass]
    public class UnitTest1
    {
        private static PhantomJSDriver _driver;

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("http://matterspace.azurewebsites.net/Account/Register");
            _driver.FindElementByCssSelector("#Email").SendKeys("email8@email.com");
            _driver.FindElementByCssSelector("#Password").SendKeys("1234qwerREWQ$#@!");
            _driver.FindElementByCssSelector("#ConfirmPassword").SendKeys("1234qwerREWQ$#@!");
            _driver.FindElementByCssSelector("body > form > div > div > div.card-block > div:nth-child(4) > div > button").Click();
            Assert.AreEqual(_driver.FindElementByCssSelector("body > div.container.app-container > div > div.col-4.side-bar-column > div:nth-child(1) > p").Text, "Posts you are subscribed to");
        }

        [TestInitialize]
        public void TestUp()
        {
            _driver = new PhantomJSDriver();
        }

        [TestCleanup]
        public void TestDown()
        {

        }
    }
}
