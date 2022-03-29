using FindGames.Framework.Utils;
using NUnit.Framework;

namespace FindGames.Framework.BaseTest
{
    internal abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            BrowserUtil.GoToUrl(ConfigUtil.GetValueByName("TestURL"));
        }

        //[TearDown]
        //public void CloseBrowser()
        //{
        //    BrowserUtil.Quit();
        //}
    }
}