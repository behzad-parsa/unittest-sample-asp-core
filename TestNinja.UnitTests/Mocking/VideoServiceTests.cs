using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoRepository> _videoRepository;


        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideoAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            _videoRepository.Setup(fr => fr.GetUnprocessedVideo()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideoAsCsv();

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetUnprocessedVideoAsCsv_AFewUnprocessedVideo_ReturnAStringWithIdOfUnprocessedVideos()
        {
            _videoRepository.Setup(fr => fr.GetUnprocessedVideo()).Returns(new List<Video>()
            {
                new Video(){ Id = 1 },
                new Video(){ Id = 2 },
                new Video(){ Id = 3 }
            });
            var result = _videoService.GetUnprocessedVideoAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }

    }
}
