using System;
using System.IO;
using Ionic.Zip;

namespace WoW.LoadFile
{
    public static class ZipReader
    {
        private const string ExtractFolder = "../../ExtractedFiles";

        public static void Read(string Location)
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
                        Console.WriteLine(entry.FileName + " has been extracted");
                    }
                }
            }
        }
    }
}

