using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateFaction
    {
        private readonly IWoWDbContext dbContext;

        public CreateFaction(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetFactions(string factionName)
        {
            var entity = new Factions()
            {
                Name = factionName
            };

            this.dbContext.Professions.Add(entity);
        }
    }
}