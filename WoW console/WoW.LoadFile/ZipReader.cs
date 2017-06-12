using System;
using System.IO;
using Ionic.Zip;

namespace WoW.LoadFile
{
    public class ZipReader : IZipReader
    {
        private const string ExtractFolder = "..\\..\\ExtractedFiles";

        public void ReadZip(string Location)
        {
            using (var zip = ZipFile.Read(Location))
            {
                var entries = zip.Entries;
                foreach (var entry in entries)
                {
                    if (File.Exists(ExtractFolder + $"/{entry.FileName}"))
                    {
                        break;
                    }

                    if (!entry.IsDirectory)
                    {
                        entry.Extract(ExtractFolder);
                        //writer
                        Console.WriteLine(entry.FileName + " has been extracted");
                    }
                }
            }
        }
    }
}

