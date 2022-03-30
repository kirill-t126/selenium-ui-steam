using NLog;

namespace FindGames.Framework.Utils
{
    internal static class LoggerUtil
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }
    }
}
