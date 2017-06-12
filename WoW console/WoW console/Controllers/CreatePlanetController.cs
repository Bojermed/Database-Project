using System;
using System.Collections.Generic;
using System.Drawing;
using WoW.CreateCommands;
using WoW.CreateCommands.Contracts;
using WoW_console.Contracts;

namespace WoW_console.Controllers
{
    public class CreatePlanetController : ICreationController
    {
        private const string NAME_PROMPT_MESSAGE = "Enter a planet name of your choice:";
        private const string UNSUCCESSEFUL_CREATION = "Planet creation was unsucesseful. Please try again...";
        private const string SUCCESSEFUL_CREATION = "Planet of name {0} successfully created!";

        private readonly ICreateEntity entityCreator;
        private readonly IReader reader;
        private readonly IWriter writer;
        private IList<string> entityCharacteristics;        

        public CreatePlanetController(ICreateEntity planetCreator, IReader reader, IWriter writer)
        {
            this.entityCreator = planetCreator;
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

        public void GuideUser(string username)
        {
            this.Writer.WriteLineInfo(NAME_PROMPT_MESSAGE);
            var planetName = this.Reader.ReadLine();
            EntityCharacteristics.Add(planetName);

            try
            {
                this.EntityCreator.CreateEntity(this.EntityCharacteristics);
                this.Writer.WriteLineSuccess(string.Format(SUCCESSEFUL_CREATION, EntityCharacteristics[0]));
            }
            catch(Exception ex)
            {                
                Writer.WriteLineError(UNSUCCESSEFUL_CREATION);
            }
        }
    }
}
