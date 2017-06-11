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

        public void GetPlayer(string playerName, string passwordHash, int cityId, string email)
        {
            var entity = new Users()
            {
                Username = playerName,
                PasswordHash = passwordHash,
                CitiesId = cityId,
                Email = email

            };

            this.dbContext.Users.Add(entity);
        }

    }
}
