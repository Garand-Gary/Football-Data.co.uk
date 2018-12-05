using System;
using System.IO;

namespace FootballData.Entities
{
    internal class CsvFile
    {
        public Stream File { get; set; }
        public DateTime LastModified { get; set; }
    }
}
