using Database;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WoW.LoadFile.Contracts;
using WoWPostgreData;
using WoW_console;
using WoW_Postgre.Models;


namespace WoW.LoadFile
{
    public class Importer : IImporter
    {
        private readonly string resourceFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Resources.json";
        private readonly string factionsFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Factions.json";
        private readonly string professionsFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Professions.json";
        private readonly string classesFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Classes.json";
        private readonly string racesFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Races.json";
        private readonly string countriesFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Countries.json";
        private readonly string citiesFile = "..\\..\\..\\WoW.LoadFile\\ExtractedFiles\\Cities.json";

        private readonly IWoWDbContext dbContext;
        private readonly IWoWDbPostgreContext dbPostgreContext;

        public Importer(IWoWDbContext context)
        {
            this.dbContext = context;
        }

        public Importer(IWoWDbPostgreContext context)
        {
            this.dbPostgreContext = context;
        }

        public IWoWDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        public IWoWDbPostgreContext DbPostgreContext
        {
            get
            {
                return this.dbPostgreContext;
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

            this.DbContext.SaveChanges();
        }

        private void CountriesDeserializeJSON()
        {
            if (!File.Exists(countriesFile))
            {
                throw new FileNotFoundException("JsonFile not found!", countriesFile);
            }

            string parsedJson = File.ReadAllText(countriesFile);

            IEnumerable<Countries> countriesModel = JsonConvert.DeserializeObject<IEnumerable<Countries>>(parsedJson).ToList();

            foreach (var item in countriesModel)
            {
                   var newCountries = new Countries()
                {
                    Name = item.Name,
                };
                this.DbPostgreContext.Countries.Add(newCountries);             
            }

            this.DbPostgreContext.SaveChanges();
        }

        private void CitesDeserializeJSON()
        {
            if (!File.Exists(citiesFile))
            {
                throw new FileNotFoundException("JsonFile not found!", citiesFile);
            }

            string parsedJson = File.ReadAllText(citiesFile);

            IEnumerable<Cities> citiesModel = JsonConvert.DeserializeObject<IEnumerable<Cities>>(parsedJson).ToList();

            foreach (var item in citiesModel)
            {
                var newCity = new Cities()
                {
                    Name = item.Name,
                    CountriesId = item.CountriesId
                };
                this.DbPostgreContext.Cities.Add(newCity);
            }

            this.DbPostgreContext.SaveChanges();
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
    }
}
