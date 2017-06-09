using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateRace
    {
        private readonly IWoWDbContext dbContext;

        public CreateRace(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetNpcs(string name, string language, string location, string capital, string mount)
        {
            var race = new Races()
            {
                Name = name,
                Language=language,
                Location=location,
                Capital=capital,
                Mount=mount
            };

            this.dbContext.Races.Add(race);
        }
    }
}
