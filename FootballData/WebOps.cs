using FootballData.Entities;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FootballData
{
    internal static class WebOps
    {
        internal static async Task<DateTime> GetLastModifiedTime(string url)
        {
            Uri uri = new Uri(url);

            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Head;

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.LastModified;
                }
                else
                {
                    throw new Exception("Unable to establish the last modified date of the supplied URL.");
                }
            }
        }

        internal static async Task<CsvFile> GetCsvFile(string url)
        {
            Uri uri = new Uri(url);

            var request = (HttpWebRequest)WebRequest.Create(uri);
            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var lastModifiedTime = response.LastModified;
                    var outputStream = new MemoryStream();

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        responseStream.CopyTo(outputStream);
                        return new CsvFile() { File = outputStream, LastModified = lastModifiedTime };
                    }
                }
                else
                {
                    throw new Exception("There was a problem downloading the file from the server.");
                }
            }
        }
    }
}
