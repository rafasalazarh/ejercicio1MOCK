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
        public void FileDownloader_EmptyPath_ReturnTrue()
        {
            _fileDownloader.Setup(fr => fr.DownloadFile("", null));

            _installerHelper = new InstallerHelper(_fileDownloader.Object);

            var result = _installerHelper.DownloadInstaller(null, null);

            Assert.AreEqual(result, true);
        }
    }
}