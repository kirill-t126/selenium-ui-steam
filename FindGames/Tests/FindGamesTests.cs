using FindGames.Framework.BaseTest;
using FindGames.Framework.Utils;
using FindGames.Pages;
using NUnit.Framework;
using System;

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
                LoggerUtil.Info("Navigate to main page");
                var mainPage = new MainPage();
                var testGame = ConfigUtil.GetValueByName("FindGame");
                Assert.IsTrue(mainPage.PageIsDisplayed(), "Main page is not opened");
                LoggerUtil.Info($"Enter in the search bar '{testGame}'");
                mainPage.InputTestText(testGame);
                LoggerUtil.Info("Click on the search button");
                mainPage.ClickSearchButton();
                var searchPage = new SearchPage();
                Assert.IsTrue(searchPage.PageIsDisplayed(), "Search page is not opened");
                LoggerUtil.Info("Search expected game in the test result");
                Assert.IsFalse(searchPage.IsGameInSearchResults(testGame), $"{testGame} is released!!!");
            }

            [Test]
            public void FindGameWithSearchFiltersTest()
            {
                LoggerUtil.Info("Navigate to main page");
                var mainPage = new MainPage();
                Assert.IsTrue(mainPage.PageIsDisplayed(), "Main page is not opened");
                LoggerUtil.Info("Move pointer to 'New & noteworthy' at page's menu");
                mainPage.MoveToNewAndNoteworthy();
                LoggerUtil.Info("Click on 'Top sellers' button");
                mainPage.ClickTopSellersButton();
                var searchPage = new SearchPage();
                Assert.IsTrue(searchPage.PageIsDisplayed(), "Search page is not opened");
                Assert.IsTrue(searchPage.IsTopSellersOnThePage(), "Search page doesn't contain information about top sellers");
                LoggerUtil.Info("Select the checkbox 'Windows' in the rigth menu");
                var osCheckbox = ConfigUtil.GetValueByName("OsCheckbox");
                searchPage.ClickCheckBox(ConfigUtil.GetValueByName("MenuOs"), osCheckbox);
                Assert.IsTrue(searchPage.IsCheckboxSelected(ConfigUtil.GetValueByName("OsCheckbox")), $"Checkbox {osCheckbox}  is not selected");
                LoggerUtil.Info("Select the checkbox 'Single-player' int the right menu");
                var numberOfPlayersCheckbox = ConfigUtil.GetValueByName("NumberOfPlayersCheckbox");
                searchPage.ClickCheckBox(ConfigUtil.GetValueByName("MenuNumberOfPlayers"), numberOfPlayersCheckbox);
                Assert.IsTrue(searchPage.IsCheckboxSelected(ConfigUtil.GetValueByName("NumberOfPlayersCheckbox")), $"Checkbox {numberOfPlayersCheckbox} is not selected");
                LoggerUtil.Info("Set the slider in the 'Price' block in the position '$30'");
                searchPage.SetUpPrice(Int32.Parse(ConfigUtil.GetValueByName("PriceLimit")));
                Assert.IsTrue(searchPage.IsPriceChanged(ConfigUtil.GetValueByName("PriceLimit")), "Price filter is not changed");
                LoggerUtil.Info("Get the first product title, price and release date");
                var expectedGame = searchPage.GetGameModelFromSearchResult(Int32.Parse(ConfigUtil.GetValueByName("NumberOfGameFromSearchResult")));
                LoggerUtil.Info("Click on the first search result");
                searchPage.ClickConreteSearchResult(Int32.Parse(ConfigUtil.GetValueByName("NumberOfGameFromSearchResult")));
                var productPage = new ProductPage();
                var actualGame = productPage.GetGameModel();
                Assert.AreEqual(expectedGame, actualGame, "Games from Search page and Product page are not equal");
            }
        }
    }
}