using System;
using System.Collections.Generic;
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
            this.EntityCreator = planetCreator;
            this.Reader = reader;
            this.Writer = writer;
            this.EntityCharacteristics = new List<string>();

        }

        public ICreateEntity EntityCreator { get; private set; }

        public IReader Reader { get; private set; }

        public IWriter Writer { get; set; }

        public IList<string> EntityCharacteristics { get; set; }

        public void GuideUser()
        {
            this.Writer.WriteLine(NAME_PROMPT_MESSAGE);
            var planetName = this.Reader.ReadLine();
            EntityCharacteristics.Add(planetName);

            try
            {
                this.EntityCreator.CreateEntity(this.EntityCharacteristics);
                this.Writer.WriteLine(string.Format(SUCCESSEFUL_CREATION, EntityCharacteristics[0]));
            }
            catch(Exception ex)
            {
                Writer.WriteLine(UNSUCCESSEFUL_CREATION);
            }
        }
    }
}
