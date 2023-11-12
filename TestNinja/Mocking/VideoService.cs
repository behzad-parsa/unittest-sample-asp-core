using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IVideoRepository _videoRepository;
        public VideoService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public VideoService(IFileReader fileReader, IVideoRepository videoRepository) : this(fileReader)
        {
            _videoRepository = videoRepository;
        }
        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }
        public string GetUnprocessedVideoAsCsv()
         {
            var videos = _videoRepository.GetUnprocessedVideo();
            var videoIds = new List<int>();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return string.Join(",", videoIds);
        }

    }
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
