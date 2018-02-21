using System.Configuration;

namespace AgioGlobal.Tool.FileReaderTest.TestEnvironment.Helpers
{
    public static class ConfigurationHelper
    {
        #region Public Properties

        public static string TextFilePath => BasePath + TxtFileName;
        public static string XMLFilePath => BasePath + XMLFileName;

        #endregion

        #region private fields

        private static string BasePath => ConfigurationManager.AppSettings["BasePath"];
        private static string TxtFileName => ConfigurationManager.AppSettings["TxtFileName"];
        private static string XMLFileName => ConfigurationManager.AppSettings["XMLFileName"];

        #endregion

        
    }
}
