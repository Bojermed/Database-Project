using Database;
using System;
using System.Collections.Generic;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreatePlayer : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreatePlayer(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IWoWDbContext DbContext
        {
            get { return this.dbContext; }
        }

        public void CreateEntity(IList<string> entityCharacteristics)
        {
            Server parsedServer;
            Enum.TryParse<Server>(entityCharacteristics[2], true, out parsedServer);

            var entity = new Players()
            {
                Username = entityCharacteristics[0],
                PasswordHash = entityCharacteristics[1],
                Servers = parsedServer

            };

            this.DbContext.Players.Add(entity);
            this.DbContext.SaveChanges();
        }
    }
}