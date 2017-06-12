using System;
using System.Collections.Generic;
using WoW.CreateCommands;
using WoW.CreateCommands.Contracts;
using WoW_console.Contracts;

namespace WoW_console.Controllers
{
    public class CreateCharacterController : ICreationController
    {
        private const string PROMPT_MESSAGE = "Enter a {0} of your choice for your new character:";
        private const string UNSUCCESSEFUL_CREATION = "Character creation was unsucesseful. Please try again...";
        private const string SUCCESSEFUL_CREATION = "Character of name {0} successfully created!";
        private const string INVALID_RACE = "Your race should be one of the list";

        private readonly ICreateEntity entityCreator;
        private readonly IReader reader;
        private readonly IWriter writer;
        private IList<string> entityCharacteristics;

        public CreateCharacterController(ICreateEntity characterCreator, IReader reader, IWriter writer)
        {
            this.entityCreator = characterCreator;
            this.reader = reader;
            this.writer = writer;
            this.entityCharacteristics = new List<string>();

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
        

        public void GuideUser()
        {
            this.Writer.WriteLine(string.Format(PROMPT_MESSAGE, "name"));
            var characterName = this.Reader.ReadLine();
            EntityCharacteristics.Add(characterName);

            var racesInGame = new List<string> { "Draenei", "Dwarf", "Gnome", "Human", "Night elf", "Pandaren", "Worgen",
                                                 "Blood elf", "Forsaken", "Goblin","Orc", "Pandaren", "Tauren", "Troll" };     
            this.Writer.WriteLine(string.Format(PROMPT_MESSAGE+" Possible races:", "race"));
            var characterRace = this.Reader.ReadLine();
            EntityCharacteristics.Add(characterRace);
            
            foreach (var race in racesInGame)
            {
                this.Writer.WriteLine(race+" ");
            }

            bool raceCheck = false;
            foreach (var race in racesInGame)
            {
                if (characterRace == race)
                {
                    raceCheck = true;
                    break;
                }
            }

            if (!raceCheck)
            {
                throw new Exception(INVALID_RACE);
            }     

            this.Writer.WriteLine(string.Format(PROMPT_MESSAGE, "class"));
            var characterClass = this.Reader.ReadLine();
            EntityCharacteristics.Add(characterClass);

            this.Writer.WriteLine(string.Format(PROMPT_MESSAGE, "faction"));
            var characterFaction = this.Reader.ReadLine();
            EntityCharacteristics.Add(characterFaction);

            this.Writer.WriteLine(string.Format(PROMPT_MESSAGE, "profession"));
            var characterProfession = this.Reader.ReadLine();
            EntityCharacteristics.Add(characterProfession);


            foreach (var entity in EntityCharacteristics)
            {
                try
                {
                    this.EntityCreator.CreateEntity(this.EntityCharacteristics);
                    this.Writer.WriteLine(string.Format(SUCCESSEFUL_CREATION, entity));
                }
                catch (Exception ex)
                {
                    Writer.WriteLine(UNSUCCESSEFUL_CREATION);
                }
            }
        }
    }
}
