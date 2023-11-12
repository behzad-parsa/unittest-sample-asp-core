using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IDownloader _downloader;
        public InstallerHelper(IDownloader downloader)
        {
            _downloader = downloader;
        }
        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _downloader.DownloadFile(string.Format("http://example.com/{0}/{1}",
                        customerName,installerName),
                        _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}