using Database;
using WoW_console;
using System;

namespace WoW.CreateCommands
{
    public class CreateContinet
    {
        private readonly IWoWDbContext dbContext;

        public CreateContinet(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetContinent(string continentName, int planetId)
        {
            var continent = new Continents()
            {
                Name = continentName,
                PlanetId = planetId
            };

            this.dbContext.Continents.Add(continent);
        }

       //private int FindPlanet(string planetName)
       //{
       //    int planetId;
       //    var planet = dbContext.Planets
       //        .Where(p => p.Name == planetName)
       //        .ToList();
       //
       //    if (planet!=null)
       //    {
       //        planetId = planet[0].Id;
       //        return planetId;
       //    }
       //
       //    else
       //    {
       //        var newPlanet= new CreatePlanet(dbContext);
       //        newPlanet.GetPlanets(planetName);
       //        var selectedPlanet = dbContext.Planets
       //        .Where(p => p.Name == planetName)
       //        .ToList();
       //        return selectedPlanet[0].Id;
       //    }
       //}
    }
}
