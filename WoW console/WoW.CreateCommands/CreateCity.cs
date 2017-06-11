using WoWPostgreData;
using WoW_Postgre.Models;

namespace WoW.CreateCommands
{
    public class CreateCity
    {
        private readonly IWoWDbPostgreContext dbContext;

        public CreateCity(IWoWDbPostgreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetCity(string cityName, int countriesId)
        {
            var city = new Cities()
            {
                Name = cityName,
                CountriesId = countriesId
            };

            this.dbContext.Cities.Add(city);
        }
    }
}
