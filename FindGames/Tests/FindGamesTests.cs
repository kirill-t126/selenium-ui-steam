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
            public void IsGameReleasedTest()
            {
                var mainPage = new MainPage();
                var testGame = ConfigUtil.GetValueByName("FindGame");
                Assert.IsTrue(mainPage.PageIsDisplayed(), "Main page is not opened");
                mainPage.InputTestText(testGame);
                mainPage.ClickSearchButton();
                var searchPage = new SearchPage();
                Assert.IsTrue(searchPage.PageIsDisplayed(), "Search page is not opened");
                Assert.IsFalse(searchPage.IsGameInSearchResults(testGame), $"{testGame} is realized!!!");
            }

            [Test]
            public void FindGameWithSearchFiltersTest()
            {
                var mainPage = new MainPage();
                Assert.IsTrue(mainPage.PageIsDisplayed(), "Main page is not opened");
                mainPage.MoveToNewAndNoteworthy();
                mainPage.ClickTopSellersButton();
                var searchPage = new SearchPage();
                Assert.IsTrue(searchPage.PageIsDisplayed(), "Search page is not opened");
                Assert.IsTrue(searchPage.IsTopSellersOnThePage(), "Search page doesn't contain information about top sellers");

                searchPage.ClickCheckBox("Narrow by OS", "Windows");
                Assert.IsTrue(searchPage.IsCheckboxSelected("Windows"), "Checkbox is not selected");
                searchPage.ClickCheckBox("Narrow by number of players", "Single-player");
                Assert.IsTrue(searchPage.IsCheckboxSelected("Single-player"), "Checkbox is not selected");
                searchPage.SetUpPrice(30);

                var expectedGame = searchPage.GetGameModelFromSearchResult(1);
                searchPage.ClickConreteSearchResult(1);

                var productPage = new ProductPage();
                var actualGame = productPage.GetGameModel();
                Assert.AreEqual(expectedGame, actualGame, "Games are not equal");
            }
        }
    }
}