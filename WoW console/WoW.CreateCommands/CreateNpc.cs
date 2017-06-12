using Database;
using System.Collections.Generic;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateNpc
    {
        private readonly IWoWDbContext dbContext;

        public CreateNpc(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IWoWDbContext DbContext
        {
            get { return this.dbContext; }
        }

        public void CreateEntity(IList<string> entityCharacteristics)
        {
            var npcs = new Npcs()
            {
                Name = entityCharacteristics[0],
                Titles = entityCharacteristics[1],
                Health = int.Parse(entityCharacteristics[2]),
                GenderId = int.Parse(entityCharacteristics[3]),
                RaceId = int.Parse(entityCharacteristics[4]),
                ClassId = int.Parse(entityCharacteristics[5]),
                FactionId = int.Parse(entityCharacteristics[6]),
                StatusId = int.Parse(entityCharacteristics[7]),
                ZoneId = int.Parse(entityCharacteristics[8]),
            };

            this.DbContext.Npcs.Add(npcs);
            this.DbContext.SaveChanges();
        }
    }
}
