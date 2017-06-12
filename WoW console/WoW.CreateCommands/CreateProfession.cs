using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateProfession : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreateProfession(IWoWDbContext dbContext)
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
            var profession = new Professions()
            {
                Name = entityCharacteristics[0],
                ProfessionTypeId = int.Parse(entityCharacteristics[1])
            };

            this.DbContext.Professions.Add(profession);
            this.DbContext.SaveChanges();

        }
    }
}
