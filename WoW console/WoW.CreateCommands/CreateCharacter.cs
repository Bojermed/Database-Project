using Database;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateCharacter
    {
        private readonly IWoWDbContext dbContext;

        public CreateCharacter(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetCharacter(string characterName, int playerId, int raceId, int classId, int factionId, int professionId)
        {
            var entity = new Characters()
            {
                Name = characterName,
                PlayerId = playerId,
                RaceId = raceId,
                ClassId = classId,
                FactionId = factionId,
                ProfessionId = professionId

            };

            this.dbContext.Characters.Add(entity);
        }
    }
}