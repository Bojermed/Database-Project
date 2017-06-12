using Database;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using WoW.FileLoader;
using WoW.LoadFile.Contracts;
using WoW_console;


namespace WoW.LoadFile
{
    public class Importer : IImporter
    {
        private readonly string RootElement = "Characters";
        private readonly string FileName = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Characters.json";

        private readonly string inputFolderPath = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles";
        private readonly string inputPath = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles";

        private IWoWDbContext dbContext;
        //private readonly IWriter writer;

        public Importer(IWoWDbContext context)
        {
            this.dbContext = context;
        }

        public IEnumerable<Characters> DeserializeJSON()
        {
            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException("JsonFile not found!", FileName);
            }
;
            var result = new List<Characters>();

            foreach (string file in Directory.EnumerateFiles(inputPath, "*.json"))
            {
                string parsedJson = File.ReadAllText(file);

                IEnumerable<CharacterJsonModel> characterJsonModels = JsonConvert.DeserializeObject<IEnumerable<CharacterJsonModel>>(parsedJson).ToList();

                var characterJsonModel = new CharacterJsonModel();

                foreach (var item in characterJsonModels)
                {
                    result.Add(characterJsonModel.FromJsonModel(item, new WoW_console.WoWDbContext()));
                }
            }

            return result;
        }


        public IEnumerable<Characters> DeserializeXML()
        {
            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException("XMLFile not found!", FileName);
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
