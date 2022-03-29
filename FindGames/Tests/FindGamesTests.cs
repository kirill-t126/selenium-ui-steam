using FindGames.Framework.BaseTest;
using FindGames.Framework.Utils;
using FindGames.Pages;
using NUnit.Framework;

namespace FindGames.Tests
{
    internal class FindGamesTests
    {
        [TestFixture]
        public class SteamTests : BaseTest
        {
            [Test]
            public void IsGameReleased()
            {
                var mainPage = new MainPage();
                var testGame = ConfigUtil.GetValueByName("FindGame");
                Assert.IsTrue(mainPage.PageIsDisplayed(), "Main page is not opened");
                mainPage.InputTestText(testGame);
                mainPage.ClickSearchButton();
                var searchPage = new SearchPage();
                Assert.IsTrue(searchPage.PageIsDisplayed(), "SearchPage is not opened");
                Assert.IsFalse(searchPage.IsGameInSearchResults(testGame), $"{testGame} is realized!!!");
            }

            [Test]
            public void FindGameWithSearchFilters()
            {
                var mainPage = new MainPage();
                Assert.IsTrue(mainPage.PageIsDisplayed(), "Main page is not opened");
                mainPage.MoveToNewAndNoteworthy();
                mainPage.ClickTopSellersButton();
            }
        }
    }
}