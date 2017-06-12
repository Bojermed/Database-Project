using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateFaction : ICreateEntity
{
        private readonly IWoWDbContext dbContext;

        public CreateFaction(IWoWDbContext dbContext)
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
            var entity = new Factions()
            {
                Name = entityCharacteristics[0]
            };

            this.DbContext.Factions.Add(entity);
            this.DbContext.SaveChanges();
        }
    }
}