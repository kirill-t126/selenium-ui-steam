using FindGames.Framework.Utils;
using NUnit.Framework;

namespace FindGames.Framework.BaseTest
{
    internal abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            LoggerUtil.Info($"Go to test url: {ConfigUtil.GetValueByName("TestURL")}");
            BrowserUtil.GoToUrl(ConfigUtil.GetValueByName("TestURL"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            LoggerUtil.Info("Close browser");
            BrowserUtil.Quit();
        }
    }
}