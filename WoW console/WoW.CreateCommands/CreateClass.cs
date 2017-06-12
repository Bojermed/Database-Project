using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateClass : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreateClass(IWoWDbContext dbContext)
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
            var entity = new Classes()
            {
                Name = entityCharacteristics[0],
                ResourceId = int.Parse(entityCharacteristics[1]),
                Lore = entityCharacteristics[2]
            };

            this.DbContext.Classes.Add(entity);
            this.DbContext.SaveChanges();
        }
    }
}
