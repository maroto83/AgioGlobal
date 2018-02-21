using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using AgioGlobal.Tool.FileReader.Helpers;

namespace AgioGlobal.Tool.FileReader
{
    public static class FileReaderManager
    {
        /// <summary>  
        ///  Read text file or XML file
        /// </summary>  
        /// <param name="filePath">path of the filename</param>  
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        public static string ReadFile(string filePath)
        {
            var fileContent = string.Empty;
            try
            {
                // Check if exist the file
                if (File.Exists(filePath))
                {
                    fileContent = ManageFile(filePath, fileContent);
                }

                return fileContent;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return fileContent;
            }
        }

        private static string ManageFile(string filePath, string fileContent)
        {
            // Get the file extension 
            var extension = Path.GetExtension(filePath);

            if (extension != null)
            {
                switch (extension)
                {
                    // Read a text file
                    case FileReaderHelper.TxtExtension:
                        fileContent = ReadTextFile(filePath);
                        break;
                    // Read a XML file
                    case FileReaderHelper.XMLExtension:
                        fileContent = ReadXMLFile(filePath);
                        break;
                }
            }

            return fileContent;
        }

        /// <summary>  
        ///  Read a text file  
        /// </summary>  
        /// <param name="filePath">path of the filename</param>  
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        private static string ReadTextFile(string filePath)
        {
            var fileContent = string.Empty;

            // Check if exist the file
            if (File.Exists(filePath))
            {
                // Read the file
                fileContent = File.ReadAllText(filePath);
            }

            return fileContent;
        }

        /// <summary>  
        ///  Read a XML file  
        /// </summary>  
        /// <param name="filePath">path of the filename</param>  
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        private static string ReadXMLFile(string filePath)
        {
            var fileContent = string.Empty;

            // Check if exist the file
            if (File.Exists(filePath))
            {
                // Read the file
                fileContent = File.ReadAllText(filePath);
            }

            return fileContent;
        }
    }
}
