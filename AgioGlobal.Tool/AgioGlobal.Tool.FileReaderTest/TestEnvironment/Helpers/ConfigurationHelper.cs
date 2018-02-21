using System.Configuration;

namespace AgioGlobal.Tool.FileReaderTest.TestEnvironment.Helpers
{
    public static class ConfigurationHelper
    {
        private static string BasePath => ConfigurationManager.AppSettings["BasePath"];
        private static string TxtFileName => ConfigurationManager.AppSettings["TxtFileName"];

        public static string TextFilePath => BasePath + TxtFileName;
    }
}
