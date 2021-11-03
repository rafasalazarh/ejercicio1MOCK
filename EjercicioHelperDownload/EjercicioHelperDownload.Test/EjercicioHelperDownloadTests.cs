using Moq;
using NUnit.Framework;
using System;
using System.Net;

namespace EjercicioHelperDownload.Test
{
    public class EjercicioHelperDownloadTests
    {
        private InstallerHelper _installerHelper;
        private Mock<IFileDownloader> _fileDownloader;

        [SetUp]
        public void Setup()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void FileDownloader_Exception_ReturnFalse()
        {
            _fileDownloader.SetupSequence(fr => fr.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            _installerHelper = new InstallerHelper(_fileDownloader.Object);

            var result = _installerHelper.DownloadInstaller("test", "test");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void FileDownloader_ReturnTrue()
        {
            _fileDownloader.Setup(fr => fr.DownloadFile("url", "path"));

            _installerHelper = new InstallerHelper(_fileDownloader.Object);

            var result = _installerHelper.DownloadInstaller("test", "test");

            Assert.AreEqual(result, true);
        }
    }
}