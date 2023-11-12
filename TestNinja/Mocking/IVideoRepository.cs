using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        List<Video> GetUnprocessedVideo();
    }
}
