using Database;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateGender : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreateGender(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IWoWDbContext DbContext
        {
            get { return this.dbContext; }
        }

        public void CreateEntity(IList<string> entityCharacteristics)
        {
            var gender = new Genders()
            {
                Name = entityCharacteristics[0]
            };

            this.DbContext.Genders.Add(gender);
            this.DbContext.SaveChanges();
        }
    }
}
