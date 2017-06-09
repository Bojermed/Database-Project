using Database;
using System;
using System.Linq;
using WoW.CreateCommands;

namespace WoW_console
{
    class Program
    {
        static void Main()
        {
            var dbContext = new WoWDbContext();
            var planet = new CreatePlanet(dbContext);
            planet.GetPlanets("Draenor");
            dbContext.SaveChanges();
            var planetForSearch = dbContext.Planets
                .Where(p => p.Name == "Draenor")
            //.Find(0);
                .ToList();
            planetForSearch
                .ForEach(p => Console.WriteLine(p.Name));
        }
    }
}
