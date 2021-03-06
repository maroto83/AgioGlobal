﻿using System;
using System.IO;
using AgioGlobal.Tool.FileReader.Helpers;

namespace AgioGlobal.Tool.FileReader.Managers
{
    public static class FileReaderManager
    {
        #region Properties

        public static string FileContent { get; set; }
        public static string FilePath { get; set; }
        public static string FileExtension => Path.GetExtension(FilePath);
        public static FileReaderHelper.RolType RolType { get; set; }

        #endregion

        /// <summary>  
        ///  Read text file or XML file
        /// </summary>  
        /// <param name="filePath">path of the filename</param>
        /// <param name="isEncrypted">Set if the file is encrypted or not. By default the file is not encrypted</param>
        /// <param name="rolType">Rol type: Admin or No Admin. By default is No Admin</param>
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        public static string ReadFile(string filePath, bool isEncrypted = false, FileReaderHelper.RolType rolType = FileReaderHelper.RolType.NoAdmin)
        {
            FilePath = filePath;
            RolType = rolType;
            FileContent = string.Empty;
            try
            {
                // Check if exist the file
                if (File.Exists(FilePath))
                {
                    ManageFile();

                    if (!string.IsNullOrWhiteSpace(FileContent) && isEncrypted)
                    {
                        DecryptedFile();
                    }
                }

                return FileContent;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Decrypted the file content
        /// </summary>
        private static void DecryptedFile()
        {
            var charArray = FileContent.ToCharArray();
            Array.Reverse(charArray);
            FileContent = new string(charArray);
        }

        /// <summary>
        /// Manage a file
        /// </summary>
        private static void ManageFile()
        {
            if (FileExtension!= null)
            {
                // If the rol is no Admin and you are trying to read Txt or XML file, we thrown an error
                if ((FileExtension.Equals(FileReaderHelper.TxtExtension)
                        || FileExtension.Equals(FileReaderHelper.XMLExtension)
                        || FileExtension.Equals(FileReaderHelper.JsonExtension))
                    && RolType.Equals(FileReaderHelper.RolType.NoAdmin))
                {
                    throw new Exception(string.Format(FileReaderHelper.NoAdminErrorMessage, FilePath));
                }

                switch (FileExtension)
                {
                    // Read a text file
                    case FileReaderHelper.TxtExtension:
                        ReadTextFile();
                        break;
                    // Read a XML file
                    case FileReaderHelper.XMLExtension:
                        ReadXMLFile();
                        break;
                    case FileReaderHelper.EncryptedExtension:
                        ReadEncryptedFile();
                        break;
                    case FileReaderHelper.JsonExtension:
                        ReadJsonFile();
                        break;
                }
            }
        }

        /// <summary>  
        ///  Read a text file  
        /// </summary>  
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        private static void ReadTextFile()
        {
            FileContent = string.Empty;

            // Check if exist the file
            if (File.Exists(FilePath))
            {
                // Read the file
                FileContent = File.ReadAllText(FilePath);
            }
        }

        /// <summary>  
        ///  Read a XML file  
        /// </summary>  
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        private static void ReadXMLFile()
        {
            FileContent = string.Empty;

            // Check if exist the file
            if (File.Exists(FilePath))
            {
                // Read the file
                FileContent = File.ReadAllText(FilePath);
            }
        }

        /// <summary>  
        ///  Read a encrypted file  
        /// </summary>  
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        private static void ReadEncryptedFile()
        {
            FileContent = string.Empty;

            // Check if exist the file
            if (File.Exists(FilePath))
            {
                // Read the file
                FileContent = File.ReadAllText(FilePath);
            }
        }

        /// <summary>  
        ///  Read a encrypted file  
        /// </summary>  
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        private static void ReadJsonFile()
        {
            FileContent = string.Empty;

            // Check if exist the file
            if (File.Exists(FilePath))
            {
                // Read the file
                FileContent = File.ReadAllText(FilePath);
                FileContent = Newtonsoft.Json.JsonConvert.DeserializeObject(FileContent).ToString();
            }
        }
    }
}
