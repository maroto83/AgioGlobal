using System;
using AgioGlobal.Tool.FileReader;
using AgioGlobal.Tool.FileReader.Helpers;
using AgioGlobal.Tool.FileReader.Managers;
using AgioGlobal.Tool.FileReaderTest.TestEnvironment.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgioGlobal.Tool.FileReaderTest
{
    [TestClass]
    public class FileReaderManagerTest
    {
        #region Test for Text File

        [TestMethod]
        public void ReadTextFile_WhenExistFileAndRolIsAdmin_CheckResultOk()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.TextFilePath, rolType:FileReaderHelper.RolType.Admin);

            Assert.AreNotEqual(fileContent, String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReadTextFile_WhenExistFileAndRolIsNoAdmin_CheckException()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.TextFilePath);

            Assert.AreNotEqual(fileContent, String.Empty);
        }

        [TestMethod]
        public void ReadTextFile_WhenNotExistFile_CheckEmptyContent()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.TextFilePath + "123");

            Assert.AreEqual(fileContent, String.Empty);
        }

        #endregion

        #region Test for XML File

        [TestMethod]
        public void ReadXMLFile_WhenExistFileAndRolIsAdmin_CheckResultOk()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.XMLFilePath, rolType: FileReaderHelper.RolType.Admin);

            Assert.AreNotEqual(fileContent, String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReadXMLFile_WhenExistFileAndRolIsNoAdmin_CheckException()
        {
            FileReaderManager.ReadFile(ConfigurationHelper.XMLFilePath);
        }

        [TestMethod]
        public void ReadXMLFile_WhenNotExistFile_CheckEmptyContent()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.XMLFilePath + "123");

            Assert.AreEqual(fileContent, String.Empty);
        }

        #endregion

        #region Test for Encrypted File

        [TestMethod]
        public void ReadEncryptedFile_WhenExistFile_CheckResultOk()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.EncryptedFilePath, true);

            Assert.AreEqual(fileContent, ConfigurationHelper.EncryptedText);
        }

        [TestMethod]
        public void ReadEncryptedFile_WhenNotExistFile_CheckEmptyContent()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.EncryptedFilePath + "123", true);

            Assert.AreEqual(fileContent, String.Empty);
        }

        #endregion

        #region Test for Json File

        [TestMethod]
        public void ReadJsonFile_WhenExistFile_CheckResultOk()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.JsonFilePath, rolType: FileReaderHelper.RolType.Admin);

            Assert.AreNotEqual(fileContent, String.Empty);
        }
        
        [TestMethod]
        public void ReadJsonFile_WhenNotExistFile_CheckEmptyContent()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.JsonFilePath + "123");

            Assert.AreEqual(fileContent, String.Empty);
        }

        #endregion
    }
}
