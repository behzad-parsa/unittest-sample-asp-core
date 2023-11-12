using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TestNinja.Mocking
{
    class VideoRepository : IVideoRepository
    {
        public List<Video> GetUnprocessedVideo()
        {
            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();
                return videos;
            }
        }
    }

}
