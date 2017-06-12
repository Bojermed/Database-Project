using System;
using System.IO;
using Ionic.Zip;
//using WoW_console.Contracts;

namespace WoW.LoadFile
{
    public class ZipReader : IZipReader
    {
        private const string ExtractFolder = "..\\..\\WoW.LoadFiles\\ExtractedFiles";
        //private readonly IWriter writer;


        //public ZipReader(IWriter writer)
        //{
        //    this.writer = writer;
        //}

        //public IWriter Writer
        //{
        //    get
        //    {
        //        return this.writer;
        //    }
        //}

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
                        //writer.WriteLine(entry.FileName + " has been extracted");
                        Console.WriteLine(entry.FileName + " has been extracted");
                    }
                }
            }
        }
    }
}

