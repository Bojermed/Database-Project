using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateRace : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreateRace(IWoWDbContext dbContext)
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
            var race = new Races()
            {
                Name = entityCharacteristics[0],
                Language = entityCharacteristics[1],
                Location = entityCharacteristics[2],
                Capital = entityCharacteristics[3],
                Mount = entityCharacteristics[4]
            };

            this.DbContext.Races.Add(race);
            this.DbContext.SaveChanges();
        }
    }
}
