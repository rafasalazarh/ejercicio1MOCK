using System.Net;

namespace EjercicioHelperDownload
{
    public interface IMyWebClient
    {
        void DownloadFile(string address, string fileName);
    }

    public class MyWebClient : IMyWebClient
    {
        public void DownloadFile(string address, string fileName)
        {
            var client = new WebClient();

            client.DownloadFile(address, fileName);
        }
    }
}
