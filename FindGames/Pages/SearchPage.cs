using FindGames.Framework.Base;
using FindGames.Framework.Driver;
using FindGames.Framework.Elements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FindGames.Pages
{
    internal class SearchPage : BaseForm
    {
        //private IList<ILabel> ProjectTestsLabel => ElementFactory.FindElements<ILabel>(By.XPath($"{testTableRecordsLabelXpath}"), "Project tests");
        //private ILabel TableColumnLabel(int column) => ElementFactory.GetLabel(By.XPath($"{tableColumns}[{column}]"), "Table column");
        //private Label SearchResults(string gameName) => new Label(By.XPath($"//div[@id='search_result_container']//span[@class='title' and text()='{gameName}']"), "Search results");
        private ReadOnlyCollection<IWebElement> GameInSearchResults(string gameName) => Singleton.GetInstance().FindElements(By.XPath($"//div[@id='search_result_container']//span[@class='title' and text()='{gameName}']"));


        public SearchPage() : base(By.XPath("//div[@id='search_results']"), "Search Page")
        {
        }

        public bool IsGameInSearchResults(string gameName)
        {
            return GameInSearchResults(gameName).Count == 1;
        }
    }
}