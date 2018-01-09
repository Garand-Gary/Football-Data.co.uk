using System;
using System.IO;
using System.Net;

namespace FootballData
{
    internal static class WebOps
    {
        internal static DateTime GetLastModifiedTime(string url)
        {
            Uri uri = new Uri(url);

            var request = (HttpWebRequest)WebRequest.Create(uri);
            using (var response = (HttpWebResponse)request.GetResponse())
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

        internal static Stream GetCsvFile(string url, out DateTime lastModifiedTime)
        {
            Uri uri = new Uri(url);

            var request = (HttpWebRequest)WebRequest.Create(uri);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    lastModifiedTime = response.LastModified;
                    var outputStream = new MemoryStream();

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        responseStream.CopyTo(outputStream);
                        return outputStream;
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
