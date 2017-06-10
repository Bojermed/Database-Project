using WoWPostgreData;
using WoW_Postgre.Models;

namespace WoW.CreateCommands
{
    public class CreateUser
    {
        private readonly IWoWDbPostgreContext dbContext;

        public CreateUser(IWoWDbPostgreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetPlayer(string playerName, string passwordHash, int cityId)
        {
            var entity = new Users()
            {
                Username = playerName,
                PasswordHash = passwordHash,
                CitiesId = cityId

            };

            this.dbContext.Users.Add(entity);
        }

    }
}
