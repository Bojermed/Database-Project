using Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;


namespace WoW.LoadFile
{
    public class ParseData
    {
        private const string RootElement = "Players";
        private const string FileName = "../../XmlToImport.xml";

        private const string inputFolderPath = "../../WoW.LoadFile";
        private const string inputPath = "../../WoW.LoadFile/ExtractedFiles";

        public ParseData()
        {
            
        }

        public void ReadFiles()
        {
            var zipReader = new ZipReader();

            foreach (string file in Directory.EnumerateFiles(inputFolderPath, "*.zip"))
            {
                zipReader.ReadZip(file);
            }

        }

        public IEnumerable<Characters> Deserialize<TModel>()
        {
            IEnumerable<Characters> result = null;

            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException("File not found!", FileName);
            }


            foreach (string file in Directory.EnumerateFiles(inputPath, "*.json"))
            {
                string parsedJson = File.ReadAllText(file);

                result= JsonConvert.DeserializeObject<IEnumerable<Characters>>(parsedJson).ToList();

                //characters = carJsonModels.Select(Characters.FromJsonModel);
            }

            return result;
        }


        public IEnumerable<Characters> DeserializeXML()
        {
            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException("File not found!", FileName);
            }
            IEnumerable<Characters> result = null;

            foreach (string file in Directory.EnumerateFiles(inputPath, "*.xml"))
            { 
                 var serializer = new XmlSerializer(typeof(List<Characters>), new XmlRootAttribute(RootElement));

                 using (var fs = new FileStream(FileName, FileMode.Open))
                 {
                     result = (IEnumerable<Characters>)serializer.Deserialize(fs);
                 }
  
            }
            return result;
        }
    }
}
