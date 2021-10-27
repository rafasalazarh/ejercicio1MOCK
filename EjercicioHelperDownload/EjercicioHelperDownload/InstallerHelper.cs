using System;

namespace EjercicioHelperDownload
{
    public class InstallerHelper
    {
        private IMyWebClient _myWebClient;
        private string _setupDestinationFile;

        public InstallerHelper(IMyWebClient myWebClient = null)
        {
            _myWebClient = myWebClient ?? new MyWebClient();
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _myWebClient.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
