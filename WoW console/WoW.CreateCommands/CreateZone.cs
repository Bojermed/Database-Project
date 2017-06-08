using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
