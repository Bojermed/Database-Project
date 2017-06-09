using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateZones
    {
        private readonly IWoWDbContext dbContext;

        public CreateZones(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetZone(string zoneName, int continentId)
        {
            var zone = new Zones()
            {
                Name = zoneName,
                ContinentId = continentId
            };

            this.dbContext.Zones.Add(zone);
        }
    }
}
