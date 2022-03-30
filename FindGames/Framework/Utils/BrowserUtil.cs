using FindGames.Framework.Driver;

namespace FindGames.Framework.Utils
{
    internal static class BrowserUtil
    {
        public static void GoToUrl(string url) => Singleton.GetInstance().Navigate().GoToUrl(url);
        public static void Quit()
        {
            Singleton.GetInstance().Quit();
            Singleton.CloseDriver();
        }
    }
}