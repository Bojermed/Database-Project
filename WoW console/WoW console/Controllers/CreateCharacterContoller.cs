using System;
using System.Collections.Generic;
using System.Linq;
using WoW.CreateCommands.Contracts;
using WoW_console.Contracts;

namespace WoW_console.Controllers
{
    public class CreateCharacterController : ICreationController
    {
        private const string PROMPT_MESSAGE = "Enter a {0} of your choice:";
        private const string UNSUCCESSEFUL_CREATION = "Character creation was unsucesseful. Please try again...";
        private const string SUCCESSEFUL_CREATION = "Character of name {0} successfully created!";
        private const string INVALID_INPUT = "Your {0} should be contained in the above list. Please create a new character...";

        private readonly IWoWDbContext dbContext;
        private readonly ICreateEntity entityCreator;
        private readonly IReader reader;
        private readonly IWriter writer;
        private IList<string> entityCharacteristics;

        private IList<string> factionsInGame;
        private IList<string> racesInGame;
        private IList<string> professionsInGame;
        private IList<string> classesInGame;

        public CreateCharacterController(IWoWDbContext dbContext, ICreateEntity characterCreator, IReader reader, IWriter writer)
        {
            this.dbContext = dbContext;
            this.entityCreator = characterCreator;
            this.reader = reader;
            this.writer = writer;
            this.entityCharacteristics = new List<string>();

            this.FactionsInGame = new List<string>();
            this.RacesInGame = new List<string>();
            this.ProfessionsInGame = new List<string>();
            this.ClassesInGame = new List<string>();

        }

        public IWoWDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        public ICreateEntity EntityCreator
        {
            get
            {
                return this.entityCreator;
            }
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }
        }

        public IList<string> EntityCharacteristics
        {
            get
            {
                return this.entityCharacteristics;
            }
        }

        public IList<string> FactionsInGame
        {
            get
            {
                return this.factionsInGame;
            }

            set
            {
                this.factionsInGame = value;
            }
        }

        public IList<string> RacesInGame
        {
            get
            {
                return this.racesInGame;
            }

            set
            {
                this.racesInGame = value;
            }
        }

        public IList<string> ProfessionsInGame
        {
            get
            {
                return this.professionsInGame;
            }

            set
            {
                this.professionsInGame = value;
            }
        }

        public IList<string> ClassesInGame
        {
            get
            {
                return this.classesInGame;
            }

            set
            {
                this.classesInGame = value;
            }
        }

        public void GuideUser(string username)
        {                       
            // Retrieve name
            this.Writer.WriteLineInfo(string.Format(PROMPT_MESSAGE, "name"));
            var characterName = this.Reader.ReadLine();

            // Retrieve faction
            this.FactionsInGame = this.DbContext.Factions.Select(f => f.Name).ToList();
            this.Writer.WriteLineInfo("~Available factions:");
            foreach (var faction in this.FactionsInGame)
            {
                this.Writer.WriteLine(faction);
            }
            this.Writer.WriteLineInfo(string.Format(PROMPT_MESSAGE, "faction"));
            var characterFaction = this.Reader.ReadLine().ToLower();
            if (!this.FactionsInGame.Any(f => f.ToLower() == characterFaction))
            {
                this.Writer.WriteLineError(string.Format(INVALID_INPUT, "faction"));
                return;
            }
            var getFactionId = this.DbContext.Factions.Where(f => f.Name.ToLower() == characterFaction).FirstOrDefault().Id;

            // Retrieve race
            this.RacesInGame = this.DbContext.Factions
                .Where(f => f.Id == getFactionId)
                .FirstOrDefault()
                .Races.ToList()
                .Select(r => r.Name)
                .ToList();
            this.Writer.WriteLineInfo("~Available races:");
            foreach (var race in this.RacesInGame)
            {
                this.Writer.WriteLine(race);
            }
            this.Writer.WriteLineInfo(string.Format(PROMPT_MESSAGE, "race"));
            var characterRace = this.Reader.ReadLine().ToLower();
            if (!this.RacesInGame.Any(r => r.ToLower() == characterRace))
            {
                this.Writer.WriteLineError(string.Format(INVALID_INPUT, "race"));
                return;
            }
            var getRaceId = this.DbContext.Races.Where(r => r.Name.ToLower() == characterRace).FirstOrDefault().Id;

            // Retrieve class
            this.ClassesInGame = this.DbContext.Races
                .Where(r => r.Id == getRaceId)
                .FirstOrDefault()
                .Classes
                .ToList()
                .Select(p => p.Name)
                .ToList();
            this.Writer.WriteLineInfo("~Available classes:");
            foreach (var gameClass in this.ClassesInGame)
            {
                this.Writer.WriteLine(gameClass);
            }
            this.Writer.WriteLineInfo(string.Format(PROMPT_MESSAGE, "class"));
            var characterClass = this.Reader.ReadLine().ToLower();
            if (!this.ClassesInGame.Any(c => c.ToLower() == characterClass))
            {
                this.Writer.WriteLineError(string.Format(INVALID_INPUT, "class"));
                return;
            }

            // Retrieve profession
            this.ProfessionsInGame = this.DbContext.Professions.Select(p => p.Name).ToList();
            this.Writer.WriteLineInfo("~Available professions:");
            foreach (var profession in this.ProfessionsInGame)
            {
                this.Writer.WriteLine(profession);
            }
            this.Writer.WriteLineInfo(string.Format(PROMPT_MESSAGE, "profession"));
            var characterProfession = this.Reader.ReadLine().ToLower();
            if (!this.ProfessionsInGame.Any(p => p.ToLower() == characterProfession))
            {
                this.Writer.WriteLineError(string.Format(INVALID_INPUT, "profession"));
                return;
            }

            var getPlayerId = this.DbContext.Players.Where(p => p.Username == username).FirstOrDefault().Id;            
            var getClassId = this.DbContext.Classes.Where(c => c.Name.ToLower() == characterClass).FirstOrDefault().Id;
            var getProfessionId = this.DbContext.Professions.Where(p => p.Name.ToLower() == characterProfession).FirstOrDefault().Id;

            EntityCharacteristics.Add(characterName);
            EntityCharacteristics.Add(getPlayerId.ToString());
            EntityCharacteristics.Add(getRaceId.ToString());
            EntityCharacteristics.Add(getClassId.ToString());
            EntityCharacteristics.Add(getFactionId.ToString());
            EntityCharacteristics.Add(getProfessionId.ToString());

            try
            {
                this.EntityCreator.CreateEntity(this.EntityCharacteristics);
                this.Writer.WriteLineSuccess(string.Format(SUCCESSEFUL_CREATION, EntityCharacteristics[0]));
            }
            catch (Exception ex)
            {
                Writer.WriteLineError(UNSUCCESSEFUL_CREATION);
            }
        }
    }
}
