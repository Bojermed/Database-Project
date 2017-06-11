using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateResources : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreateResources(IWoWDbContext dbContext)
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
            var resource = new Resources()
            {
                Name = entityCharacteristics[0]
            };

            this.DbContext.Resources.Add(resource);
            this.DbContext.SaveChanges();
        }
    }
}