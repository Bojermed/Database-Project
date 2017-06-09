using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateProfession
    {
        private readonly IWoWDbContext dbContext;

        public CreateProfession(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetProfession(string professionName, int professionTypeId)
        {
            var profession = new Professions()
            {
                Name = professionName,
                ProfessionTypeId = professionTypeId
            };

            this.dbContext.Professions.Add(profession);
        }
    }
}
