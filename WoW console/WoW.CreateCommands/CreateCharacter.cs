using Database;
using System.Collections.Generic;
using System.Linq;
using WoW.CreateCommands.Contracts;
using WoW_console;

namespace WoW.CreateCommands
{
    public class CreateCharacter : ICreateEntity
    {
        private readonly IWoWDbContext dbContext;

        public CreateCharacter(IWoWDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IWoWDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        public void CreateEntity(IList<string> entityCharacteristics)
        {
            var entity = new Characters()
            {
                Name = entityCharacteristics[0],
                PlayerId = int.Parse(entityCharacteristics[1]),
                RaceId = int.Parse(entityCharacteristics[2]),
                ClassId = int.Parse(entityCharacteristics[3]),
                FactionId = int.Parse(entityCharacteristics[4]),
                ProfessionId = int.Parse(entityCharacteristics[5])

            };

            this.DbContext.Characters.Add(entity);
            this.DbContext.SaveChanges();
        }
    }
}