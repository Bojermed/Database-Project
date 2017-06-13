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
        private readonly string resourceFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Resources.json";
        private readonly string factionsFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Factions.json";
        private readonly string professionsFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Professions.json";
        private readonly string classesFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Classes.json";
        private readonly string racesFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Races.json";

        private readonly IWoWDbContext dbContext;

        public Importer(IWoWDbContext context)
        {
            this.dbContext = context;
        }

        public IWoWDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        private void ResourcesDeserializeJSON()
        {
            if (!File.Exists(resourceFile))
            {
                throw new FileNotFoundException("JsonFile not found!", resourceFile);
            }

            var result = new List<Resources>();

            string parsedJson = File.ReadAllText(resourceFile);

            IEnumerable<Resources> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<Resources>>(parsedJson).ToList();

            foreach (var item in resourcesModel)
            {
                this.DbContext.Resources.Add(item);
            }
            this.DbContext.SaveChanges();
        }

        private void FactionsDeserializeJSON()
        {
            if (!File.Exists(factionsFile))
            {
                throw new FileNotFoundException("JsonFile not found!", factionsFile);
            }

            string parsedJson = File.ReadAllText(factionsFile);

            IEnumerable<Factions> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<Factions>>(parsedJson).ToList();

            foreach (var item in resourcesModel)
            {
                this.DbContext.Factions.Add(item);
            }

            this.DbContext.SaveChanges();
        }

        private void ProfessionsDeserializeJSON()
        {
            if (!File.Exists(professionsFile))
            {
                throw new FileNotFoundException("JsonFile not found!", professionsFile);
            }

            string parsedJson = File.ReadAllText(professionsFile);

            IEnumerable<Professions> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<Professions>>(parsedJson).ToList();

            foreach (var item in resourcesModel)
            {
                this.DbContext.Professions.Add(item);
            }

            this.DbContext.SaveChanges();
        }

        private void ClassesDeserializeJSON()
        {
            if (!File.Exists(classesFile))
            {
                throw new FileNotFoundException("JsonFile not found!", classesFile);
            }

            string parsedJson = File.ReadAllText(classesFile);

            IEnumerable<ClassesJsonModel> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<ClassesJsonModel>>(parsedJson).ToList();

            foreach (var item in resourcesModel)
            {
                var newClass = new Classes()
                {
                    Name = item.Name,
                    ResourceId = item.ResourceId,
                    Lore = item.Lore
                };
                this.DbContext.Classes.Add(newClass);
            }

            this.DbContext.SaveChanges();
        }

        private void RacesDeserializeJSON()
        {
            if (!File.Exists(racesFile))
            {
                throw new FileNotFoundException("JsonFile not found!", racesFile);
            }

            string parsedJson = File.ReadAllText(racesFile);

            IEnumerable<RacesJsonModel> resourcesModel = JsonConvert.DeserializeObject<IEnumerable<RacesJsonModel>>(parsedJson).ToList();

            foreach (var item in resourcesModel)
            {
                var newRace = new Races()
                {
                    Name = item.Name,
                    FactionId = item.FactionId,
                    Language = item.Language,
                    Capital = item.Capital,
                    Mount = item.Mount
                };
                this.DbContext.Races.Add(newRace);
            }

            this.DbContext.SaveChanges();
        }

        private void ConnectRacesClassesDeserializeJSON()
        {
            if (!File.Exists(racesFile) || !File.Exists(classesFile))
            {
                throw new FileNotFoundException("JsonFile not found!");
            }

            string racesJson = File.ReadAllText(racesFile);
            string classesJson = File.ReadAllText(classesFile);

            var racesIndex = JsonConvert.DeserializeObject<IEnumerable<RacesJsonModel>>(racesJson).Select(x => x.Name).ToList();
            var racesModel = JsonConvert.DeserializeObject<IEnumerable<RacesJsonModel>>(racesJson).Select(x => x.Classes).ToList();
            var classesIndex = JsonConvert.DeserializeObject<IEnumerable<ClassesJsonModel>>(classesJson).Select(x => x.Name).ToList();
            var classesModel = JsonConvert.DeserializeObject<IEnumerable<ClassesJsonModel>>(classesJson).Select(x => x.Races).ToList();

            for (int i = 0; i < racesIndex.Count; i++)
            {
                for (int u = 0; u < racesModel[i].Count; u++)
                {
                    var raceName = racesIndex[i];
                    var className = racesModel[i][u];
                    var inputClass = this.dbContext.Classes.Where(c => c.Name == className).FirstOrDefault();

                    this.DbContext.Races
                        .Where(r => r.Name == raceName)
                        .FirstOrDefault()
                        .Classes
                        .Add(inputClass);
                }
            }

            //for (int i = 0; i < classesIndex.Count; i++)
            //{
            //    for (int u = 0; u < racesIndex.Count; u++)
            //    {
            //        var className = classesIndex[i];
            //        var raceName = racesIndex[u];
            //        var inputRace = this.dbContext.Races.Where(c => c.Name == raceName).FirstOrDefault();

            //        this.DbContext.Classes
            //            .Where(c => c.Name == className)
            //            .FirstOrDefault()
            //            .Races
            //            .Add(inputRace);
            //    }
            //}

            this.DbContext.SaveChanges();
        }

        public void SeedDatabase()
        {
            bool racesSeeded = false;
            bool classesSeeded = false;
            if (!this.DbContext.Resources.Any())
            {
                this.ResourcesDeserializeJSON();
            }
            if (!this.DbContext.Professions.Any())
            {
                this.ProfessionsDeserializeJSON();
            }
            if (!this.DbContext.Factions.Any())
            {
                this.FactionsDeserializeJSON();
            }
            if (!this.DbContext.Races.Any())
            {
                this.RacesDeserializeJSON();
                racesSeeded = true;
            }
            if (!this.DbContext.Classes.Any())
            {
                this.ClassesDeserializeJSON();
                classesSeeded = true;
            }
            if (racesSeeded && classesSeeded)
            {
                this.ConnectRacesClassesDeserializeJSON();
            }

        }

//        public IEnumerable<Characters> DeserializeJSON()
//        {
//            if (!File.Exists(FileName))
//            {
//                throw new FileNotFoundException("JsonFile not found!", FileName);
//            }
//;
//            var result = new List<Characters>();

//            foreach (string file in Directory.EnumerateFiles(inputPath, "*.json"))
//            {
//                string parsedJson = File.ReadAllText(file);

//                IEnumerable<CharacterJsonModel> characterJsonModels = JsonConvert.DeserializeObject<IEnumerable<CharacterJsonModel>>(parsedJson).ToList();

//                var characterJsonModel = new CharacterJsonModel();

//                foreach (var item in characterJsonModels)
//                {
//                    result.Add(characterJsonModel.FromJsonModel(item, new WoW_console.WoWDbContext()));
//                }
//            }

//            return result;
//        }


//        public IEnumerable<Characters> DeserializeXML()
//        {
//            if (!File.Exists(FileName))
//            {
//                throw new FileNotFoundException("XMLFile not found!", FileName);
//            }
//            IEnumerable<Characters> result = null;

//            foreach (string file in Directory.EnumerateFiles(inputPath, "*.xml"))
//            {
//                var serializer = new XmlSerializer(typeof(List<Characters>), new XmlRootAttribute(RootElement));

//                using (var fs = new FileStream(FileName, FileMode.Open))
//                {
//                    result = (IEnumerable<Characters>)serializer.Deserialize(fs);
//                }

//            }
//            return result;
//        }
    }
}
