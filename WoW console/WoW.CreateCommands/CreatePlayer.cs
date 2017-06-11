using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreatePlayer
    {
        private readonly IWoWDbContext dbContext;

        public CreatePlayer(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetPlayer(string playerName, string passwordHash, Server server)
        {
            var entity = new Players()
            {
                Username = playerName,
                PasswordHash = passwordHash,
                Servers = server

            };

            this.dbContext.Players.Add(entity);
        }
    }
}