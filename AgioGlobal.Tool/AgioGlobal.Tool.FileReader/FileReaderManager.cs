using System;
using System.IO;

namespace AgioGlobal.Tool.FileReader
{
    public static class FileReaderManager
    {
        /// <summary>  
        ///  Read a text file  
        /// </summary>  
        /// <param name="filePath">path of the filename</param>  
        /// <returns>If exist the file, return a string with the file content. In otherwise return an empty string</returns>  
        public static string ReadTextFile(string filePath)
        {  
           var readText = string.Empty;  
           try  
           {                  
               // Check if exist the file
               if (File.Exists(filePath))  
               {  
                   // Read the file
                   readText = File.ReadAllText(filePath);  
               }

               return readText;  
           }  
           catch (Exception e)  
           {  
               Console.WriteLine(e.Message);  
               return string.Empty;  
           }
        }
    }
}
