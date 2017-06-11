using Database;
using System;
using System.Linq;
using WoW.CreateCommands;
using WoWPostgreData;
using WoW_Postgre.Data;
using WoW_console.Providers;
using Ninject;
using WoW_console.Container;

namespace WoW_console
{
    class Startup
    {
        static void Main()
        {
            var kernel = new StandardKernel(new WoWNinjectModule());
            var engine = kernel.Get<Engine>();
            engine.Start();

            //var dbContext = new WoWDbContext();
            //var planet = new CreatePlanet(dbContext);
            //planet.GetPlanets("Draenor");
            //dbContext.SaveChanges();s
            //var planetForSearch = dbContext.Planets
            //    .Where(p => p.Name == "Draenor")
            ////.Find(0);
            //    .ToList();
            //planetForSearch
            //    .ForEach(p => Console.WriteLine(p.Name));

            //var dbContext = new WoWDbPostgreContext();
            //var country = new CreateCountry(dbContext);
            //var city = new CreateCity(dbContext);
            ////country.GetCountries("Bulgaria");
            //city.GetCity("Burgas",1);
            //dbContext.SaveChanges();

        }
    }
}
