using System;
using AgioGlobal.Tool.FileReader;
using AgioGlobal.Tool.FileReaderTest.TestEnvironment.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgioGlobal.Tool.FileReaderTest
{
    [TestClass]
    public class FileReaderManagerTest
    {
        #region ReadTextFile

        [TestMethod]
        public void ReadTextFile_WhenExistFile_CheckResultOk()
        {
            var fileContent = FileReaderManager.ReadTextFile(ConfigurationHelper.TextFilePath);

            Assert.AreNotEqual(fileContent, String.Empty);
        }

        [TestMethod]
        public void ReadTextFile_WhenNotExistFile_CheckEmptyContent()
        {
            var fileContent = FileReaderManager.ReadTextFile(ConfigurationHelper.TextFilePath + "123");

            Assert.AreEqual(fileContent, String.Empty);
        }

        #endregion
    }
}
