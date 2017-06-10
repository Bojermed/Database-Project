using WoWPostgreData;
using WoW_Postgre.Models;

namespace WoW.CreateCommands
{
    public class CreateCountry
    {

        private readonly IWoWDbPostgreContext dbContext;

        public CreateCountry(IWoWDbPostgreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetCountry(string countryNamed)
        {
            var country = new Countries()
            {
                Name = countryNamed,               
            };

            this.dbContext.Countries.Add(country);
        }
    }
}
