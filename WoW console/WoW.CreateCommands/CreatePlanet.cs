using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreatePlanet : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreatePlanet(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IWoWDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        public void CreateEntity(IList<string> entityCharacteristics)
        {
            var planet = new Planets()
            {
                Name = entityCharacteristics[0]
            };

            this.DbContext.Planets.Add(planet);
            this.DbContext.SaveChanges();
        }
    }
}
