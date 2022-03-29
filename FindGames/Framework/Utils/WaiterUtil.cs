using System;
using FindGames.Framework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FindGames.Framework.Utils
{
    internal static class WaiterUtil
    {
        public static void UseExplicitWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Singleton.GetInstance(), TimeSpan.FromSeconds(Convert.ToDouble(ConfigUtil.GetValueByName("WebDriverWaitInSeconds"))));
            wait.Until(e => e.FindElement(locator));
        }
    }
}