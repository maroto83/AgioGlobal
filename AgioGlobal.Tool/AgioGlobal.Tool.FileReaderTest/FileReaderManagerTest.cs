using System;
using AgioGlobal.Tool.FileReader;
using AgioGlobal.Tool.FileReaderTest.TestEnvironment.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgioGlobal.Tool.FileReaderTest
{
    [TestClass]
    public class FileReaderManagerTest
    {
        #region Test for Text File

        [TestMethod]
        public void ReadTextFile_WhenExistFile_CheckResultOk()
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
        public void ReadXMLFile_WhenExistFile_CheckResultOk()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.XMLFilePath);

            Assert.AreNotEqual(fileContent, String.Empty);
        }

        [TestMethod]
        public void ReadXMLFile_WhenNotExistFile_CheckEmptyContent()
        {
            var fileContent = FileReaderManager.ReadFile(ConfigurationHelper.XMLFilePath + "123");

            Assert.AreEqual(fileContent, String.Empty);
        }

        #endregion
    }
}
