using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateClass
    {
        private readonly IWoWDbContext dbContext;

        public CreateClass(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetClass(string className, int resourceId, string lore)
        {
            var entity = new Classes()
            {
                Name = className,
                ResourceId = resourceId,
                Lore = lore
            };

            this.dbContext.Professions.Add(entity);
        }
    }
}
