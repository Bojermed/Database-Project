using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateStatus
    {
        private readonly IWoWDbContext dbContext;

        public CreateStatus(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetStatus(string name)
        {
            var status = new Statuses()
            {
                Name = name
            };

            this.dbContext.Statuses.Add(status);
        }
    }
}
