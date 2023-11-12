using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.Mocking
{
    public interface IDownloader
    {
        void DownloadFile(string url, string path);
    }
}
