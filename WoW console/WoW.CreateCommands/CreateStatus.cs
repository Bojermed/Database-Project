using Database;
using System.Collections.Generic;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateStatus
    {
        private readonly IWoWDbContext dbContext;

        public CreateStatus(IWoWDbContext dbContext)
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
            var status = new Statuses()
            {
                Name = entityCharacteristics[0]
            };

            this.DbContext.Statuses.Add(status);
            this.DbContext.SaveChanges();
        }
    }
}
