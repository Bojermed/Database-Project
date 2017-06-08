using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreatePlanet
    {
        private readonly IWoWDbContext dbContext;

        public CreatePlanet(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetPlanets(string inputName)
        {
            var planet = new Planets()
            {
                Name = inputName
            };

            this.dbContext.Planets.Add(planet);
        }
    }
}
