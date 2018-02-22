using System.Configuration;

namespace AgioGlobal.Tool.FileReaderTest.TestEnvironment.Helpers
{
    public static class ConfigurationHelper
    {
        #region Public Properties

        public static string TextFilePath => BasePath + TxtFileName;
        public static string XMLFilePath => BasePath + XMLFileName;
        public static string EncryptedFilePath => BasePath + EncryptedFileName;

        #endregion

        #region private fields

        private static string BasePath => ConfigurationManager.AppSettings["BasePath"];
        private static string TxtFileName => ConfigurationManager.AppSettings["TxtFileName"];
        private static string XMLFileName => ConfigurationManager.AppSettings["XMLFileName"];
        private static string EncryptedFileName => ConfigurationManager.AppSettings["EncryptedFileName"];

        #endregion

        public const string EncryptedText = "encrypted text sample";
    }
}
