using WoWPostgreData;
using WoW_Postgre.Models;

namespace WoW.CreateCommands
{
    public class CreateCharacterPostgre
    {
        private readonly IWoWDbPostgreContext dbContext;

        public CreateCharacterPostgre(IWoWDbPostgreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetCharacterPostgre(string characterName)
        {
            var entity = new Characters()
            {
                Name = characterName,
            };

            this.dbContext.Characters.Add(entity);
        }
    }
}