using Database;
using Newtonsoft.Json;
using System;
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
        private readonly string FileNameFactions = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Factions.json";
        private readonly string FileNameClasses = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Classes.json";
        private readonly string FileNameProfession = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Classes.json";
        private readonly string FileNameRaces = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Classes.json";
        private readonly string FileNameResources = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Classes.json";

        private readonly string inputFolFileNameRacesderPath = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles";
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

        public void DeserializeFactionJson()
        {
            if (!File.Exists(FileNameFactions))
            {
                throw new FileNotFoundException("JsonFile not found!", FileNameFactions);
            }

            string parsedJson = File.ReadAllText(FileNameFactions);

            IEnumerable<Factions> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<Factions>>(parsedJson).ToList();

            foreach (var f in resourcesModel)
            {
                this.dbContext.Factions.Add(f);
            }

            dbContext.SaveChanges();
        }

        public void DeserializeClassesJson()
        {
            if (!File.Exists(FileNameClasses))
            {
                throw new FileNotFoundException("JsonFile not found!", FileNameClasses);
            }

            string parsedJson = File.ReadAllText(FileNameClasses);

            IEnumerable<Classes> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<Classes>>(parsedJson).ToList();

            foreach (var c in resourcesModel)
            {
                this.dbContext.Classes.Add(c);
            }

            dbContext.SaveChanges();
        }

        public void DeserializeResourcesJson()
        {
            if (!File.Exists(FileNameResources))
            {
                throw new FileNotFoundException("JsonFile not found!", FileNameResources);
            }

            string parsedJson = File.ReadAllText(FileNameResources);

            IEnumerable<Resources> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<Resources>>(parsedJson).ToList();

            foreach (var c in resourcesModel)
            {
                this.dbContext.Resources.Add(c);
            }

            dbContext.SaveChanges();
        }

        public void DeserializeRacesJson()
        {
            if (!File.Exists(FileNameRaces))
            {
                throw new FileNotFoundException("JsonFile not found!", FileNameRaces);
            }

            string parsedJson = File.ReadAllText(FileNameRaces);

            IEnumerable<Races> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<Races>>(parsedJson).ToList();

            foreach (var c in resourcesModel)
            {
                this.dbContext.Races.Add(c);
            }

            dbContext.SaveChanges();
        }

        public void DeserializeProfessionJson()
        {
            if (!File.Exists(FileNameProfession))
            {
                throw new FileNotFoundException("JsonFile not found!", FileNameProfession);
            }

            string parsedJson = File.ReadAllText(FileNameProfession);

            IEnumerable<Professions> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<Professions>>(parsedJson).ToList();

            foreach (var c in resourcesModel)
            {
                this.dbContext.Professions.Add(c);
            }

            dbContext.SaveChanges();
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
