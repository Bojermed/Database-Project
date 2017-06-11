using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateZones : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreateZones(IWoWDbContext dbContext)
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
            var zone = new Zones()
            {
                Name = entityCharacteristics[0],
                ContinentId = int.Parse(entityCharacteristics[1])
            };

            this.DbContext.Zones.Add(zone);
            this.DbContext.SaveChanges();
        }
    }
}
