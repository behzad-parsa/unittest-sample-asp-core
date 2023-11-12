using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public class Program
    {
        public static void Main()
        {
            var service = new VideoService(new FileReader(),new VideoRepository());
            var title = service.ReadVideoTitle();
            var videos = service.GetUnprocessedVideoAsCsv();
        }

    }
}
