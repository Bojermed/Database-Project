using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateContinet : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreateContinet(IWoWDbContext dbContext)
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
            var continent = new Continents()
            {
                Name = entityCharacteristics[0],
                PlanetId = int.Parse(entityCharacteristics[1])
            };

            this.DbContext.Continents.Add(continent);
            this.DbContext.SaveChanges();
        }
    }
}
