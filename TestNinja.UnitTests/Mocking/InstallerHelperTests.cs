using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IDownloader> _downloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _downloader = new Mock<IDownloader>();
            _installerHelper = new InstallerHelper(_downloader.Object);
        }


        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            _downloader.Setup(d => d.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            var result = _installerHelper.DownloadInstaller("customer","installer");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadSucceed_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);

        }

    }
}
