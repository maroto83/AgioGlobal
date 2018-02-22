namespace AgioGlobal.Tool.FileReader.Helpers
{
    public static class FileReaderHelper
    {
        public const string TxtExtension = ".txt";
        public const string XMLExtension = ".xml";
        public const string EncryptedExtension = ".enc";
        public const string NoAdminErrorMessage = "You need be an admin user to read the file {0}";

        /// <summary>
        /// Rol type
        /// </summary>
        public enum RolType
        {
            Admin,
            NoAdmin
        }
    }
}
