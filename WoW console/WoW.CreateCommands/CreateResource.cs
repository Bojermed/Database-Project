using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateResources
    {
        private readonly IWoWDbContext dbContext;

        public CreateResources(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetResources(string resourceName)
        {
            var resource = new Professions()
            {
                Name = resourceName
            };

            this.dbContext.Professions.Add(resource);
        }
    }
}